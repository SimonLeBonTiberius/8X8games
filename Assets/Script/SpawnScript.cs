using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{

    [SerializeField]private GameObject cube;
    public bool empty = true;
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
            spawnCube();
            empty = false;
        }

    }

    void spawnCube()
    {
        Instantiate(cube, gameObject.transform.position, gameObject.transform.rotation, gameObject.transform);
    }

}
