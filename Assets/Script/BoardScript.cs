using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardScript : MonoBehaviour
{
    public delegate void BoardDelegate();
    public static event BoardDelegate OnEndGame;
    public static event BoardDelegate OnScored;

    public int width = 8;
    public int height = 8;
    public GameObject spawn;
    private GameObject[,] cubearray;
    public float colorcheck = 0;
    int score = 0;
    int countdown;

    // Start is called before the first frame update
    void OnEnable()
    {
        score = 0;
        PlayerPrefs.SetInt("Score", score);
       
        cubearray = new GameObject[width, height];
        SetUp();
        Invoke("checkColor", 0.2f);
        countdown = 120;
        StartCoroutine("Countdown");



    }
    private void OnDisable()
    {

        DestroyallSpawn();

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {

            int indicetoccox = 0;
            int indicetoccoy = 0;
            bool assegnato = false;
            Touch tocco = Input.GetTouch(0);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {

                    CubeScript scriptcubodest = cubearray[i, j].GetComponentInChildren<CubeScript>();
                    try
                    {
                        bool toccato = scriptcubodest.CubebyTouch(tocco);
                        if (toccato)
                        {
                            indicetoccox = i;
                            indicetoccoy = j;
                            assegnato = true;

                        }
                    }
                    catch
                    {
                        assegnato = false;
                    }

                }

            }
            if (assegnato)
            {
                destroyAreaColor(indicetoccox, indicetoccoy);
            }

        };

    }

    private void SetUp()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Vector2 tempPosition = new Vector2(i, j);
                GameObject spawnbean = Instantiate(spawn, tempPosition, Quaternion.identity);
                spawnbean.transform.parent = this.transform;
                spawnbean.name = "(" + i + "," + j + ")";
                spawnbean.GetComponent<SpawnScript>().index = i;
                spawnbean.GetComponent<SpawnScript>().indey = j;
                cubearray[i, j] = spawnbean;
            }
        }
    }


    public void checkColor()
    {
        colorcheck++;
        float numerocolore;
        int numeromatch = 0;
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {

                CubeScript cubocorrente = cubearray[i, j].GetComponentInChildren<CubeScript>();
                numerocolore = cubocorrente.numerocol;

                if (cubocorrente.indey > 0)
                {
                    if (numerocolore == cubearray[cubocorrente.index, cubocorrente.indey - 1].GetComponentInChildren<CubeScript>().numerocol)
                    {
                        cubocorrente.isIncontact = true;
                        numeromatch++;
                    }
                };

                if (cubocorrente.index > 0)
                {
                    if (numerocolore == cubearray[cubocorrente.index - 1, cubocorrente.indey].GetComponentInChildren<CubeScript>().numerocol)
                    {
                        cubocorrente.isIncontact = true;
                        numeromatch++;
                    }
                };

                if (cubocorrente.index < 7)
                {
                    if (numerocolore == cubearray[cubocorrente.index + 1, cubocorrente.indey].GetComponentInChildren<CubeScript>().numerocol)
                    {
                        cubocorrente.isIncontact = true;
                        numeromatch++;
                    }
                };

                if (cubocorrente.indey < 7)
                {
                    if (numerocolore == cubearray[cubocorrente.index, cubocorrente.indey + 1].GetComponentInChildren<CubeScript>().numerocol)
                    {
                        cubocorrente.isIncontact = true;
                        numeromatch++;
                    }
                };

            };



        }
        if (numeromatch < 1)
        {
            OnEndGame();
        }

    }

    public void destroyAreaColor(int i, int j)
    {
        CubeScript cubocorrente = cubearray[i, j].GetComponentInChildren<CubeScript>();
        float numerocolore = cubocorrente.numerocol;
        List<CubeScript> listacheckcubo = new List<CubeScript>();
        List<CubeScript> listacubitobedestroyed = new List<CubeScript>();
        listacheckcubo.Add(cubocorrente);
        long numerocubidistrutti = 0;

        int contatore = 0;
        while (contatore < listacheckcubo.Count)
        {

            if (cubocorrente.indey > 0)
            {
                if (numerocolore == cubearray[cubocorrente.index, cubocorrente.indey - 1].GetComponentInChildren<CubeScript>().numerocol && !listacheckcubo.Contains(cubearray[cubocorrente.index, cubocorrente.indey - 1].GetComponentInChildren<CubeScript>()))
                {
                    listacheckcubo.Add(cubearray[cubocorrente.index, cubocorrente.indey - 1].GetComponentInChildren<CubeScript>());
                }
            };

            if (cubocorrente.index > 0)
            {
                if (numerocolore == cubearray[cubocorrente.index - 1, cubocorrente.indey].GetComponentInChildren<CubeScript>().numerocol && !listacheckcubo.Contains(cubearray[cubocorrente.index - 1, cubocorrente.indey].GetComponentInChildren<CubeScript>()))
                {
                    listacheckcubo.Add(cubearray[cubocorrente.index - 1, cubocorrente.indey].GetComponentInChildren<CubeScript>());
                }
            };

            if (cubocorrente.index < 7)
            {
                if (numerocolore == cubearray[cubocorrente.index + 1, cubocorrente.indey].GetComponentInChildren<CubeScript>().numerocol && !listacheckcubo.Contains(cubearray[cubocorrente.index + 1, cubocorrente.indey].GetComponentInChildren<CubeScript>()))
                {
                    listacheckcubo.Add(cubearray[cubocorrente.index + 1, cubocorrente.indey].GetComponentInChildren<CubeScript>());
                }
            };

            if (cubocorrente.indey < 7)
            {
                if (numerocolore == cubearray[cubocorrente.index, cubocorrente.indey + 1].GetComponentInChildren<CubeScript>().numerocol && !listacheckcubo.Contains(cubearray[cubocorrente.index, cubocorrente.indey + 1].GetComponentInChildren<CubeScript>()))
                {
                    listacheckcubo.Add(cubearray[cubocorrente.index, cubocorrente.indey + 1].GetComponentInChildren<CubeScript>());
                }
            };

            if (listacheckcubo.Count > 1)
            {
                listacubitobedestroyed.Add(cubocorrente);
            }
            contatore++;
            if (contatore < listacheckcubo.Count)
            {
                cubocorrente = listacheckcubo[contatore];
            }
        }
        numerocubidistrutti = listacubitobedestroyed.Count;

        foreach (CubeScript cuboindistruzione in listacubitobedestroyed)
        {
            cuboindistruzione.destroyCube();
            SpawnScript script = cuboindistruzione.GetComponentInParent<SpawnScript>();
            if (script != null)
            { script.empty = true; }
        }

        //Calcolo Punteggio;
        if (numerocubidistrutti > 0)
        {
            long hitpoint = (numerocubidistrutti - 1) * 80 + ((long)Mathf.Pow(((numerocubidistrutti - 2) / 5), 2));
            if (score == 0)
            {
                score = (int)hitpoint;
                PlayerPrefs.SetInt("Score", score);
            }
            else
            {
                score = score + (int)hitpoint;
                PlayerPrefs.SetInt("Score", score);
             
            }
            OnScored();



            //Calcolo Aggiunta Tempo

            countdown = countdown + (10 + ((int)Mathf.Pow((((int)numerocubidistrutti - 2) / 3), 2)));


        }




    }
    public void DestroyallSpawn()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
               
                Destroy(cubearray[i, j]);



            }
        }

    }
    IEnumerator Countdown()
    {
        PlayerPrefs.SetInt("Time", countdown);
        while (countdown > 0)
        {

            countdown = (countdown - 1);
            yield return new WaitForSeconds(1);
            PlayerPrefs.SetInt("Time", countdown);
        }
        OnEndGame();
    }
}
