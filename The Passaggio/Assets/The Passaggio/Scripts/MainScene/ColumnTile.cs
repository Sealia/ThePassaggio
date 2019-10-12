using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnTile : Tile
{
    GameObject destroyer;

    private void Awake()
    {
        destroyer = GameObject.Find("Destroyer");
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    override public void Crush()
    {
        transform.Rotate(new Vector3(Random.Range(0, 5f), Random.Range(0, 5f), Random.Range(0, 5f)));
        transform.Translate(Vector3.back * 0.1f);
    }

    override public void Disassemble(float fallingImpulseForce, float faliingTorqueFactor)
    {

    }

}
