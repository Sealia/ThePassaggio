using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CreateScene : MonoBehaviour
{
    public GameObject br;
    GameObject player;
    public long l=6;    //ilość stworzonych
    public long p = 2;  //na którym jest gracz
    public double z = 6;    //gdzie był gracz ostatnio
    Vector3 spawnPos = new Vector3(0, 0, 10);
    public List<GameObject> Sections;
    Bridge bridge;
    GameObject brb;

    private void Awake()
    {
        Sections = new List<GameObject>();
        bridge = GetComponent<Bridge>();
        br = GameObject.Find("Bridge");
        brb = GameObject.Find("Bridge");
        Sections.Add(br);
        player = GameObject.FindGameObjectWithTag("Player");
        for(int i=0; i<6; i++)
        {
            
            Sections.Add(Instantiate(brb, spawnPos, brb.transform.rotation));
            spawnPos += new Vector3(0, 0, 10);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(player.transform.position.z-z>=10)
        {
            p++;
            z = player.transform.position.z;
        }
       if(l-p<4)
        {
            Sections.Add(Instantiate(brb, spawnPos, brb.transform.rotation));
            spawnPos += new Vector3(0, 0, 10);
            l++;
        }           
    }

    public void DestroyNextSection()
    {
        Destroy(Sections[0]);
        Sections.Remove(Sections[0]);
        bridge.GetDestroyed(Sections[0]);

    }
}
