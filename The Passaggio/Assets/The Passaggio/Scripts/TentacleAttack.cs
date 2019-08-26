﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleAttack : MonoBehaviour
{
    Animator anim;
    GameObject player;
    PlayerStats death;

    public AudioClip[] impactSounds;

    public AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        death = GetComponent<PlayerStats>();
    }
    // Start is called before the first frame update
    void Start()
    {
        anim.SetTrigger("Attack");
        StartCoroutine(Erease());

    }

    // Update is called once per frame
    void Update()
    {
        
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.parent.tag=="Tile")
        {
           
            other.transform.parent.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
            other.gameObject.transform.gameObject.SetActive(false);


        }

        if(other.gameObject==player)
        {
            death.isDead = true;
        }
    }

    IEnumerator Erease()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

    public void MakeSound()
    {
        int soundIndex = Random.Range(0, impactSounds.Length);
        audioSource.clip = impactSounds[soundIndex];
        audioSource.pitch = Random.Range(0.8f, 1.2f);
        audioSource.volume = Random.Range(0.5f, 0.7f);

        audioSource.Play();
        audioSource.transform.SetParent(null);
    }
}
