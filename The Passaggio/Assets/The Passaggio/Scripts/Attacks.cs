using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{

    public struct Tentacles
    {
        public Vector3 tran;
        public Quaternion q;

        public Tentacles(Vector3 tran, Quaternion q)
        {
            this.tran = tran;
            this.q = q;
        }

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
        

        for (int i = ten.Count - 1; i >= 0; i--)
        {

                if (ten[i].tran.z < player.transform.position.z - 5)
                {

                    ten.Remove(ten[i]);
                }
        }

    }

    public IEnumerator TentacleSpawn()
    {
        while (true)
        {
            spawnRangeZ = player.transform.position.z;
            int newTentacleCount = Random.Range(1, 4);
            int attempt = 5;

            for (int i = 0; i < newTentacleCount; i++)
            {
                for (int j = 0; j < attempt; j++)
                {
                    Vector3 position;
                    Quaternion rotation;

                    int side = Random.Range(0, 1);
                    float direction = Random.Range(-45, 45);


                    if (side == 0)
                    {
                        spawnPos = new Vector3(Random.Range(bridge.transform.position.x - 3f, bridge.transform.position.x - 5f), -30, Random.Range(spawnRangeZ + 15, spawnRangeZ + 25));
                        if ((spawnPos.x > bridge.transform.position.z - 0.98f || spawnPos.z < bridge.transform.position.z + 1f) && spawnPos.x > 4f)
                        {
                            spawnPos.x -= 1;
                        }
                    }
                    if (side == 1)
                    {
                        spawnPos = new Vector3(Random.Range(bridge.transform.position.x + 3f, bridge.transform.position.x + 5f), -30, Random.Range(spawnRangeZ+15, spawnRangeZ + 25));

                        if ((spawnPos.z > bridge.transform.position.z - 0.98f || spawnPos.z < bridge.transform.position.z + 1f) && spawnPos.x < 4f)
                        {
                            spawnPos.x += 1;
                        }
                        direction += 180;
                    }

                    bool valid = true;

                    for (int k = 0; k < ten.Count; k++)
                    {
                        if (spawnPos.z <= (ten[k].tran.z + 3) + (direction / 45 * 0.7f) && spawnPos.z >= (ten[k].tran.z - 3) - (direction / 45 * 0.7f))
                        {
                            valid = false;
                            break;
                        }
                    }

                    if (valid)
                    {
                        Instantiate(pref, spawnPos, Quaternion.Euler(0f, direction, 0f));
                        if (t.tran.y > player.transform.position.y)
                        {
                            ten.Add(new Tentacles(spawnPos, Quaternion.Euler(0f, direction, 0f)));
                        }
                        break;

                    }
                }

                yield return new WaitForSeconds(2f);
            }

            yield return new WaitForSeconds(3f);
        }
    }
}

