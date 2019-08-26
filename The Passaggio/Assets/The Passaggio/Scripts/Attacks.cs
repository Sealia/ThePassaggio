using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    public GameObject[] Prefabs= new GameObject[2];

    public float spawnRangeZ;
    public float spawnPosX;

    private float delay = 5;
    private float interval = 2;

    GameObject player;
    PlayerStats stats;
    public GameObject bridge;

    public float spawnX = -2.5f;
    public float spawny = 2;

    Vector3 spawnPos;



    // Start is called before the first frame update

    private void Awake()
    { 
       // Prefabs = Resources.LoadAll<GameObject>("Prefabs");
        player = GameObject.FindGameObjectWithTag("Player");
        stats = player.GetComponent<PlayerStats>();

    }

    void Start()
    {
        //  InvokeRepeating("RandomAttack", delay, interval);
          StartCoroutine(TentacleSpawn());

    }

    // Update is called once per frame
    void Update()
    {
        spawnRangeZ = player.transform.position.z-2;

    }

    public IEnumerator TentacleSpawn()
    {
        while(true)
        {
             int num = Random.Range(0, 1);
            num = 0;
             
             if (num == 0)
             {
                spawnPos = new Vector3(Random.Range(bridge.transform.position.x - 2.5f, bridge.transform.position.x - 4.5f), -30, Random.Range(spawnRangeZ+15, spawnRangeZ + 25));
                if ((spawnPos.z > bridge.transform.position.z - 0.5f || spawnPos.z < bridge.transform.position.z + 0.5f) && spawnPos.x > 3.5f)
                 {
                     spawnPos.x -= 1;
                 }

                 Instantiate(Prefabs[0], spawnPos, Prefabs[0].transform.rotation);
             }
             else if (num == 1)
             {
                spawnPos = new Vector3(Random.Range(bridge.transform.position.x + 2.5f, bridge.transform.position.x + 4.5f), -30, Random.Range(spawnRangeZ, spawnRangeZ + 1));

                if ((spawnPos.z > bridge.transform.position.z - 0.5f || spawnPos.z < bridge.transform.position.z + 0.5f) && spawnPos.x < 3.5f)
                 {
                     spawnPos.x += 1;
                 }
                 Instantiate(Prefabs[0], spawnPos, Quaternion.Euler(0f, 180, 0f) );

             }


            yield return new WaitForSeconds(2);
        }
        
    }
void RandomAttack()
{
/* if(stats.isDead==false)
 {
     int Index = Random.Range(0, Prefabs.Length);

   //  Vector3 spawnPos = new Vector3(spawnPosX, 0.5f, Random.Range(spawnRangeZ, spawnRangeZ + 4));
    /* if (Prefabs[Index].name == "Sphere")
     {
         int num = Random.Range(1, 3);
         Instantiate(Prefabs[Index], spawnPos, Prefabs[Index].transform.rotation);
         for (int i = 0; i < num; i++)
         {
             Instantiate(Prefabs[Index], spawnPos + new Vector3(0, 0, 2), Prefabs[Index].transform.rotation);
         }

     }*/
        //  if (Prefabs[Index].name == "Tentacle")
        // {

        //   int num = Random.Range(0, 1);
        //   if (num == 0)
        //   {
        /*    Vector3 spawnPos = new Vector3(Random.Range(bridge.transform.position.x + 2.5f, bridge.transform.position.x+4.5f), -30, Random.Range(spawnRangeZ, spawnRangeZ + 1));

            if((spawnPos.z>bridge.transform.position.z-0.5f || spawnPos.z<bridge.transform.position.z+0.5f) && spawnPos.x<3.5f)
            {
                spawnPos.x += 1;

            }*/
        Vector3 spawnPos = new Vector3(spawnX, -30, spawny);

        Instantiate(Prefabs[0], spawnPos, Prefabs[0].transform.rotation);
        spawny += 2;
              //  }
               /* if(num == 1)
                {
                    Vector3 spawnPos = new Vector3(Random.Range(bridge.transform.position.x-4.5f, bridge.transform.position.x-2.5f), -30, Random.Range(spawnRangeZ, spawnRangeZ + 4));

                    if ((spawnPos.z > bridge.transform.position.z - 0.5f || spawnPos.z < bridge.transform.position.z + 0.5f) && spawnPos.x < 3.5f)
                    {
                        spawnPos.x -= 1;

                    }
                    Instantiate(Prefabs[Index], spawnPos, Prefabs[Index].transform.rotation);
                }*/
          //  }
     //   }
        




    }
}
