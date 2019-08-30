using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CreateScene : MonoBehaviour
{
    public GameObject br;
    GameObject player;
    Vector3 spawnPos = new Vector3(0, 0, 10);


    private void Awake()
    {
        br = GameObject.Find("Bridge");
        player = GameObject.FindGameObjectWithTag("Player");
        for(int i=0; i<6; i++)
        {
            AddSection();
        }
    }
    void Start()
    {
       
    }

    void Update()
    {
        if(br.transform.position.z < player.transform.position.z + 50)
        {
            AddSection();
        }      
    }

    void AddSection()
    {
        br = Instantiate(br, spawnPos, br.transform.rotation).GetComponent<Bridge>().gameObject;
        spawnPos += new Vector3(0, 0, 10);
    }
}
