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
    int num;



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
            int tentaclesNumber = Random.RandomRange(1, 4);
            
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

                    Instantiate(Prefabs[0], spawnPos, Quaternion.Euler(0f, direction, 0f));
                }
                else if (num == 1)
                {
                    spawnPos = new Vector3(Random.Range(bridge.transform.position.x + 2.5f, bridge.transform.position.x + 4.5f), -30, Random.Range(spawnRangeZ, spawnRangeZ + 1));

                    if ((spawnPos.z > bridge.transform.position.z - 0.5f || spawnPos.z < bridge.transform.position.z + 0.5f) && spawnPos.x < 3.5f)
                    {
                        spawnPos.x += 1;
                    }
                    Instantiate(Prefabs[0], spawnPos, Quaternion.Euler(0f, direction + 180f, 0f));

                }

                yield return new WaitForSeconds(0.5f);
            }
             


            yield return new WaitForSeconds(8);
        }
        
    }

    
}
