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
    public List<Bridge> Sections;
    public GameObject brb;
    Bridge bridge;
    public int id=0;

    private void Awake()
    {
        Sections = new List<Bridge>();
        br = GameObject.Find("Bridge");
        Sections.Add(br.GetComponent<Bridge>());
        bridge = br.GetComponent<Bridge>();
        player = GameObject.FindGameObjectWithTag("Player");
        for(int i=0; i<6; i++)
        {
            
            Sections.Add(Instantiate(brb, spawnPos, brb.transform.rotation).GetComponent<Bridge>());
            spawnPos += new Vector3(0, 0, 10);
        }
    }
    void Start()
    {
        DestroyNextSection(0);
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
            Sections.Add(Instantiate(brb, spawnPos, brb.transform.rotation).GetComponent<Bridge>());
            spawnPos += new Vector3(0, 0, 10);
            l++;
        }           
    }

    public void RemoveFromList()
    {

        Destroy(Sections[0].gameObject);
        Sections.Remove(Sections[0]);

       /* if (Sections[2].transform.position.z < player.transform.position.z - 15)
        {
            for (int i = Sections.Count - 1; i >= 0; i--)
            {
                if (Sections[i].transform.position.z < player.transform.position.z - 15)
                {
                    Destroy(Sections[i].gameObject);
                    Sections.Remove(Sections[i]);
                }
                DestroyNextSection(i);
            }
        }*/
            


    }

    public void DestroyNextSection(int n)
    {

            Sections[n].StartDestroyingSequence(n);

           

    }


}
