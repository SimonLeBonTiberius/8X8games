using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{

    [SerializeField] private GameObject cube;
    public bool empty = true;
    public int index;
    public int indey;
    // Start is called before the first frame update
    void Start()
    {
        spawnCube();
        empty = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (empty)
        {
            Invoke("spawnCube", 0.1f);
            empty = false;
        }

    }

    void spawnCube()
    {
        GameObject spawncube = Instantiate(cube, gameObject.transform.position, gameObject.transform.rotation, gameObject.transform);
        spawncube.GetComponent<CubeScript>().index = this.index;
        spawncube.GetComponent<CubeScript>().indey = this.indey;
    }

}
