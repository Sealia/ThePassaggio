using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
 
    public struct Tentacles
    {
       public Vector3 tran;
       public Quaternion q;

    }

    public float spawnRangeZ;
    public float spawnPosX;
    public List<Tentacles> ten;
    //public List<Transform> ten;

    GameObject player;
    PlayerStats stats;
    public GameObject bridge;
    public GameObject pref;

    Vector3 spawnPos;
    int num;
    Tentacles t;



    // Start is called before the first frame update

    private void Awake()
    { 
       // Prefabs = Resources.LoadAll<GameObject>("Prefabs");
        player = GameObject.FindGameObjectWithTag("Player");
        stats = player.GetComponent<PlayerStats>();
        ten = new List<Tentacles>();

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
            int tentaclesNumber = Random.Range(1, 4);
            
            for(int i=0; i<tentaclesNumber;i++)
            {
                num = Random.Range(0, 2);
                float direction = Random.Range(-45, 45);
                if (num == 0)
                {
                    spawnPos = new Vector3(Random.Range(bridge.transform.position.x - 2.5f, bridge.transform.position.x - 4.5f), -30, Random.Range(spawnRangeZ + 15, spawnRangeZ + 25));
                    if ((spawnPos.z > bridge.transform.position.z - 0.5f || spawnPos.z < bridge.transform.position.z + 0.5f) && spawnPos.x > 3.5f)
                    {
                        spawnPos.x -= 1;
                    }

                    int check = 0;
                    bool spoko = false ;
                    
                    while(!spoko)
                    {
                        int a = 0;
                        foreach (Tentacles prev in ten)
                        {
                            if (spawnPos.z <= (prev.tran.z + 3) + direction * 5.07f && spawnPos.z >= (prev.tran.z - 3) - direction * 5.07f)
                            {
                                
                                a++;
                                spawnPos = new Vector3(Random.Range(bridge.transform.position.x - 2.5f, bridge.transform.position.x - 4.5f), -30, Random.Range(spawnRangeZ + 15, spawnRangeZ + 25));                              
                            }
                        }
                        check += 1;
                        
                        if(a==0)
                        {
                            spoko = true;
                        }

                        if(check==5)
                        {
                            break;
                        }
                    }
                    
                    if(spoko)
                    {
                        t = new Tentacles();
                        t.q = Quaternion.Euler(0f, direction, 0f);
                        t.tran = spawnPos;
                        ten.Add(t);
                        Instantiate(pref, spawnPos, Quaternion.Euler(0f, direction, 0f));
                    }
                }
                else if (num == 1)
                {
                    spawnPos = new Vector3(Random.Range(bridge.transform.position.x + 2.5f, bridge.transform.position.x + 4.5f), -30, Random.Range(spawnRangeZ, spawnRangeZ + 1));

                    if ((spawnPos.z > bridge.transform.position.z - 0.5f || spawnPos.z < bridge.transform.position.z + 0.5f) && spawnPos.x < 3.5f)
                    {
                        spawnPos.x += 1;
                    }

                    int check = 0;
                    bool spoko = false;

                    while (!spoko)
                    {
                        int a = 0;
                        foreach (Tentacles prev in ten)
                        {
                            if (spawnPos.z <= (prev.tran.z + 3)+direction*5.07f && spawnPos.z >= (prev.tran.z - 3)- direction * 5.07f)
                            {

                                a++;
                                spawnPos = new Vector3(Random.Range(bridge.transform.position.x + 2.5f, bridge.transform.position.x + 4.5f), -30, Random.Range(spawnRangeZ + 15, spawnRangeZ + 25));
                            }
                        }
                        check += 1;

                        if (a == 0)
                        {
                            spoko = true;
                        }

                        if (check == 5)
                        {
                            break;
                        }
                    }

                    if (spoko)
                    {
                        t = new Tentacles();
                        t.q = Quaternion.Euler(0f, direction, 0f);
                        t.tran = spawnPos;
                        ten.Add(t);
                        Instantiate(pref, spawnPos, Quaternion.Euler(0f, direction + 180f, 0f));
                    }
                    

                }
              /*  foreach(Tentacles b in ten)
                {
                    if(b.tran.z > player.transform.position.z-5)
                    {
                        ten.Remove(b);
                    }
                }*/
                yield return new WaitForSeconds(0.5f);
            }
             


            yield return new WaitForSeconds(2f);
        }
        
    }

    
}
