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
    // Start is called before the first frame update
    void Start()
    {

        cubearray = new GameObject[width, height];
        SetUp();
        Invoke("checkColor", 1.0f);


    } 
    // Update is called once per frame
    void Update()
    {

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
                cubearray[i, j] = spawnbean;
            }
        }
    }

   
   public void checkColor()
    {
        colorcheck++;
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
               
                GameObject beanSpawny = cubearray[i, j];
                GameObject beanSpawnx = cubearray[j, i];
                
                 
                CubeScript scripty = beanSpawny.GetComponentInChildren<CubeScript>();
                CubeScript scriptx = beanSpawnx.GetComponentInChildren<CubeScript>();
                
                
                    if (numerocolorey != scripty.numerocol )
                {
                    if (j < 7)
                    {
                        numerocolorey = scripty.numerocol;
                        scriptprecedentey = beanSpawny;
                    }
                    else {
                        numerocolorey = 0;
                        scriptprecedentey = null;
                    }

                }
                else
                {
                    scripty.isIncontact = true;
                    scriptprecedentey.GetComponentInChildren<CubeScript>().isIncontact = true;
                    Debug.Log("trovato match colore" + beanSpawny.name+ "colore numero"+scripty.numerocol);
                   
                }
                
                
                
                /*
                 -------------------------------------------------------------------------------------
                 *
                 * if (numerocolorex != scriptx.numerocol)
                 {
                     numerocolorex = scriptx.numerocol;
                 }
                 else
                 {
                     scriptx.isIncontact = true;
                     Debug.Log("trovato match colore" + beanSpawnx.name);

                 }
                 -------------------------------------------------------------------------------
                 */


                if (numerocolorex != scriptx.numerocol)
                {
                    if (j < 7)
                    {
                        numerocolorex = scriptx.numerocol;
                        scriptprecedentex = beanSpawnx;
                    }
                    else
                    {
                        numerocolorex = 0;
                        scriptprecedentex = null;
                    }

                }
                else
                {
                    scriptx.isIncontact = true;
                    scriptprecedentex.GetComponentInChildren<CubeScript>().isIncontact = true;
                    Debug.Log("trovato match colore" + beanSpawnx.name + "colore numero" + scriptx.numerocol);

                }
               
            };

        }
    }
}
