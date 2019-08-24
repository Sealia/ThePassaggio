using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    public GameObject[] Prefabs;

    public float spawnRangeZ;
    public float spawnPosX;

    private float delay = 5;
    private float interval = 4;

    GameObject player;


    // Start is called before the first frame update

    private void Awake()
    { 
        Prefabs = Resources.LoadAll<GameObject>("Prefabs");
        player = GameObject.FindGameObjectWithTag("Player");

    }

    void Start()
    {
        InvokeRepeating("RandomAttack", delay, interval);
    }

    // Update is called once per frame
    void Update()
    {
        spawnRangeZ = player.transform.position.z;
    }

    void RandomAttack()
    {
        int Index = Random.Range(0,Prefabs.Length);

        Vector3 spawnPos = new Vector3(spawnPosX, 0.5f, Random.Range(spawnRangeZ, spawnRangeZ+4));
        if (Prefabs[Index].name=="Sphere")
        {
            int num = Random.Range(1, 3);
            Instantiate(Prefabs[Index], spawnPos, Prefabs[Index].transform.rotation);
            for (int i=0; i<num;i++)
            {
                Instantiate(Prefabs[Index], spawnPos + new Vector3(0, 0, 2), Prefabs[Index].transform.rotation);
            }

        }
        if (Prefabs[Index].name == "Macki")
        {

        }




    }
}
