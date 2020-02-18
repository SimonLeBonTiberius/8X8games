using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardScript : MonoBehaviour
{
    GameObject scriptprecedentey;
    GameObject scriptprecedentex;
    public int width = 8;
    public int height = 8;
    public GameObject spawn;
    private GameObject[,] cubearray;
    private float numerocolorey =0;
    private float numerocolorex =0;
    public float colorcheck = 0;
    int tocchi = 0;

    // Start is called before the first frame update
    void Start()
    {

        cubearray = new GameObject[width, height];
        SetUp();
        Invoke("checkColor", 0.2f);


    } 
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount>0)
        {
            
            int indicetoccox=0;
            int indicetoccoy=0;
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
                    catch {
                        assegnato = false;
                    }
                
                    }

            }
            if(assegnato) {
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
           for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {

                CubeScript cubocorrente = cubearray[i, j].GetComponentInChildren<CubeScript>();
                 numerocolore = cubocorrente.numerocol;

                if (cubocorrente.indey > 0)
                {
                    if (numerocolore == cubearray[cubocorrente.index, cubocorrente.indey - 1].GetComponentInChildren<CubeScript>().numerocol )
                    {
                        cubocorrente.isIncontact = true;
                    }
                };

                if (cubocorrente.index > 0)
                {
                    if (numerocolore == cubearray[cubocorrente.index - 1, cubocorrente.indey].GetComponentInChildren<CubeScript>().numerocol)
                    {
                        cubocorrente.isIncontact = true;
                    }
                };

                if (cubocorrente.index < 7)
                {
                    if (numerocolore == cubearray[cubocorrente.index + 1, cubocorrente.indey].GetComponentInChildren<CubeScript>().numerocol )
                    {
                        cubocorrente.isIncontact = true;
                    }
                };

                if (cubocorrente.indey < 7)
                {
                    if (numerocolore == cubearray[cubocorrente.index, cubocorrente.indey + 1].GetComponentInChildren<CubeScript>().numerocol)
                    {
                        cubocorrente.isIncontact = true;
                    }
                };

               };

        }
    }

    public void destroyAreaColor(int i, int j) {
        CubeScript cubocorrente = cubearray[i, j].GetComponentInChildren<CubeScript>();
        float numerocolore = cubocorrente.numerocol;
        List<CubeScript> listacheckcubo =new List<CubeScript>();
        List<CubeScript> listacubitobedestroyed =new List<CubeScript>();
        listacheckcubo.Add(cubocorrente);
        
        int contatore = 0;
        while (contatore<listacheckcubo.Count &&contatore <10 ) {

            if (cubocorrente.indey > 0) { 
        if (numerocolore== cubearray[cubocorrente.index, cubocorrente.indey-1].GetComponentInChildren<CubeScript>().numerocol && !listacheckcubo.Contains(cubearray[cubocorrente.index, cubocorrente.indey - 1].GetComponentInChildren<CubeScript>())) {
            listacheckcubo.Add(cubearray[cubocorrente.index, cubocorrente.indey - 1 ].GetComponentInChildren<CubeScript>());
        }
            };

            if(cubocorrente.index > 0){ 
        if (numerocolore == cubearray[cubocorrente.index - 1, cubocorrente.indey].GetComponentInChildren<CubeScript>().numerocol && !listacheckcubo.Contains(cubearray[cubocorrente.index - 1, cubocorrente.indey].GetComponentInChildren<CubeScript>()))
        {
            listacheckcubo.Add(cubearray[cubocorrente.index - 1, cubocorrente.indey].GetComponentInChildren<CubeScript>());
        }
            };

            if (cubocorrente.index < 7) { 
        if (numerocolore == cubearray[cubocorrente.index + 1, cubocorrente.indey].GetComponentInChildren<CubeScript>().numerocol && !listacheckcubo.Contains(cubearray[cubocorrente.index + 1, cubocorrente.indey].GetComponentInChildren<CubeScript>()))
        {
            listacheckcubo.Add(cubearray[cubocorrente.index + 1, cubocorrente.indey].GetComponentInChildren<CubeScript>());
        }
            };

            if (cubocorrente.indey < 7) { 
        if (numerocolore == cubearray[cubocorrente.index, cubocorrente.indey + 1].GetComponentInChildren<CubeScript>().numerocol && !listacheckcubo.Contains(cubearray[cubocorrente.index, cubocorrente.indey + 1].GetComponentInChildren<CubeScript>()))
        {
            listacheckcubo.Add(cubearray[cubocorrente.index, cubocorrente.indey+1].GetComponentInChildren<CubeScript>());
        }
            };

            if ( listacheckcubo.Count > 1) { 
            listacubitobedestroyed.Add(cubocorrente);
            }
            contatore++;
            if (contatore < listacheckcubo.Count) { 
            cubocorrente = listacheckcubo[contatore];
            }
        }

        foreach (CubeScript cuboindistruzione in listacubitobedestroyed) {
            cuboindistruzione.destroyCube();
            SpawnScript script = cuboindistruzione.GetComponentInParent<SpawnScript>();
            if (script != null)
            { script.empty = true; }
        }

        
    }


}
