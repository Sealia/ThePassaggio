using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{

    public struct SpawnedTentacleBounds
    {
        public Vector3 position;
        public Quaternion rotation;
        public float z1, z2;

        public SpawnedTentacleBounds(Vector3 position, Quaternion rotation, float z1, float z2)
        {
            this.position = position;
            this.rotation = rotation;
            this.z1 = z1;
            this.z2 = z2;
        }
    }

    public List<SpawnedTentacleBounds> tentacles;

    GameObject player;
    public GameObject tentaclePrefab;

    public float spawnRangeZ;
    public float playerPosition;

    PlayerStats playerStats;
    PlayerController playerController;
    private Rigidbody rigidbody;

    Vector3 spawnPos;
    SpawnedTentacleBounds t;

    public float playersVelocity;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        tentacles = new List<SpawnedTentacleBounds>();
        playerStats = player.GetComponent<PlayerStats>();
        playerController = player.GetComponent<PlayerController>();
        rigidbody = playerController.GetComponent<Rigidbody>();
    }

    void Start()
    {
        StartCoroutine(TentacleSpawn());
    }

    void Update()
    {
        for (int i = tentacles.Count - 1; i >= 0; i--)
        {
            if (tentacles[i].position.z < player.transform.position.z - 10)
            {
                tentacles.Remove(tentacles[i]);
            }
        }
    }

    public IEnumerator TentacleSpawn()
    {
        while (true)
        {
            spawnPos = new Vector3();
            spawnPos.y = -30;
            int newTentacleCount = Random.Range(1, 4);
            int attempt = 5;
            float z1 = 0, z2 = 0, range=0;
            float spawnRange = 1f;

            for (int i = 0; i < newTentacleCount; i++)
            {
                for (int j = 0; j < attempt; j++)
                {
                    spawnRangeZ = player.transform.position.z + 5 + (playersVelocity * 3f);
                    playerPosition = player.transform.position.z;
                    spawnPos.z = Random.Range(player.transform.position.z - 2, player.transform.position.z + 2 + (playersVelocity * 3f));
                    int side = Random.Range(0, 2);
                    float direction = Random.Range(-45, 45);
                    playersVelocity = rigidbody.velocity.magnitude;
                    spawnRange = playersVelocity;

                    if (side == 0)
                    {
                        spawnPos.x = FindXPosition(-0.5f);
                        range = Mathf.Sin(direction * Mathf.Deg2Rad);
                        range = range * 5f * (-1f);
                    }
                    else if (side == 1)
                    {
                        spawnPos.x = FindXPosition(0.5f);                       
                        range = Mathf.Sin(direction * Mathf.Deg2Rad);
                        range = range * 5f;
                        direction += 180f;
                    }

                    if (range > 0)
                    {
                        z1 = spawnPos.z - 1.5f;
                        z2 = spawnPos.z + range + 1.5f;
                    }
                    else if(range < 0)
                    {
                        z2 = spawnPos.z + 1.5f;
                        z1 = spawnPos.z + range - 1.5f;
                    }

                    bool valid = true;

                    for (int k = 0; k < tentacles.Count; k++)
                    {
                        if ( (tentacles[k].z2 >= z1 && z1 >= tentacles[k].z1) || ( z2 >= tentacles[k].z1 && z2 <= tentacles[k].z2) || (z1 <= tentacles[k].z1 && z2 >= tentacles[k].z2) )
                        {
                            valid = false;
                            break;
                        }
                    }

                    if (valid)
                    {
                        Instantiate(tentaclePrefab, spawnPos, Quaternion.Euler(0f, direction, 0f));
                        if (spawnPos.z > player.transform.position.z - 10)
                        {
                            tentacles.Add(new SpawnedTentacleBounds(spawnPos, Quaternion.Euler(0f, direction, 0f), z1, z2));
                        }
                        break;
                    }
                }

               // yield return new WaitForSeconds(0.1f);
            }

            yield return new WaitForSeconds(0.1f);
        }
    }

    float FindXPosition(float startPosition)
    {
        for(float i= startPosition; ; i+= startPosition)
        {
            Collider[] hitColliders = Physics.OverlapSphere(new Vector3(i, -0.5f, spawnPos.z), 0.5f, LayerMask.GetMask("BridgeTile"));
            if(hitColliders.Length == 0)
            {
                return i;
            }
        }
    }
}

