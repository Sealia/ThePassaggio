using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{

    private Tile_b[,] tiles;
    GameObject bridge;

    private void Awake()
    {
        tiles = new Tile_b[10, 10];
        Assign();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Assign()
    {

    }
}
