using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RegularTile : Tile
{
    GameObject destroyer;
    Destroyer des_com;
    bool isScheduledForFalling = false;
    RaycastHit hit;
    public GameObject collision;
    Vector3 raydirection;
    public float force;
    public Vector3 torque;

    private void Awake()
    {
        destroyer = GameObject.Find("Destroyer");
        des_com = destroyer.GetComponent<Destroyer>();
        force = Random.Range(0f, 1f);
        torque = new Vector3(Random.Range(-50f, -30f), Random.Range(-3f, 3f), Random.Range(-3f, 3f));
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    override public void GetHit(float force, float faliingTorqueFactor)
    {
        Fall(force, faliingTorqueFactor);
    }

    override public void Fall(float fallingImpulseForce, float faliingTorqueFactor)
    {
        if (!isScheduledForFalling)
        {
            float time = Random.Range(0f, 1.5f);
            isScheduledForFalling = true;
            StartCoroutine(Check(time, fallingImpulseForce, faliingTorqueFactor));
        }               
    }

    IEnumerator Check(float time, float fallingImpulseForce, float faliingTorqueFactor)
    {
        yield return new WaitForSeconds(time);
        raydirection = Vector3.back;
        bool hasFallen = false;
        while (!hasFallen)
        {
            hit = new RaycastHit();
            Ray TileRay = new Ray(transform.position - new Vector3(0, 0.5f, 0), raydirection);
          //  Debug.DrawRay(transform.position, raydirection * 1f);

            if (!(Physics.Raycast(TileRay, out hit, 1f) && hit.collider.gameObject.tag == "Tile") || hit.collider.gameObject.GetComponent<ColumnTile>())
            {
                if(hit.collider!=null && hit.collider.gameObject.GetComponent<ColumnTile>())
                {
                    if(transform.position.x > 0)
                    {
                        raydirection = Vector3.left;
                    }
                    else
                    {
                        raydirection = Vector3.right;
                    }
                }
                else
                { 
                    this.gameObject.transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
                    this.gameObject.transform.GetChild(0).GetComponent<Rigidbody>().AddTorque(torque * faliingTorqueFactor);
                    this.gameObject.transform.GetChild(0).GetComponent<Rigidbody>().AddForce(Vector3.back * force  * fallingImpulseForce, ForceMode.Impulse);                      
                    this.gameObject.GetComponent<MeshCollider>().enabled = false;
                    des_com.DestroyTile(gameObject);
                    hasFallen = true;
                }
              
            }
            yield return new WaitForSeconds(0.01f);
        }             
    }
}

