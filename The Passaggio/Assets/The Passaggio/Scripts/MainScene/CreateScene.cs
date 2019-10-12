using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CreateScene : MonoBehaviour
{
    public GameObject lastBridgeSection;
    public GameObject bridgePrefab;
    GameObject player;
    Vector3 spawnPos = new Vector3(0, 0, 10);


    private void Awake()
    {
        lastBridgeSection = GameObject.Find("Bridge");
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
        if (lastBridgeSection)
        {
            if(lastBridgeSection.transform.position.z < player.transform.position.z + 50)
            {
                AddSection();
            }
        }     
    }

    void AddSection()
    {
        lastBridgeSection = Instantiate(bridgePrefab, spawnPos, bridgePrefab.transform.rotation).GetComponent<Bridge>().gameObject;
        spawnPos += new Vector3(0, 0, 10);
    }
}
