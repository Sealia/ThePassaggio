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
        if(this.gameObject.transform.position.y < -30)
        {
            Destroy(this.gameObject);
        }
    }

    override public void GetHit(float force)
    {
        this.transform.rotation = Quaternion.Euler(Random.Range(0,15), Random.Range(0,15), Random.Range(0,15));
    }

    override public void Fall(float fallingImpulseForce)
    {
       /* this.gameObject.transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
        this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
        */
    }

}
