using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public float speed=1f;
    Rigidbody player;
    public float fallingImpulseFactor = 1;
    public float fallingTorqueFactor= 1;

    private void Awake()
    {
        //  Time.timeScale=0.1f;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        if(player.velocity.z > 2f)
        {
            speed = player.velocity.z;

        }
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    public void DestroyTile(GameObject tile)
    {
        Destroy(tile, 2f);
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag == "Tile")
        {
            other.gameObject.GetComponent<Tile>().GetSwallowed(fallingImpulseFactor, fallingTorqueFactor);
        }
    }

}
