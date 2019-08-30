using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleAttack : MonoBehaviour
{
    Animator anim;
    GameObject player;
    PlayerStats death;
    public float fallingImpulseFactor;
    public float fallingTorqueFactor;

    public AudioClip[] impactSounds;

    public AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        death = GetComponent<PlayerStats>();
    }

    void Start()
    {
        anim.SetTrigger("Attack");
        StartCoroutine(Erease());

    }

    void Update()
    {
        fallingImpulseFactor = GameObject.Find("Destroyer").GetComponent<Destroyer>().fallingImpulseFactor;
        fallingTorqueFactor = GameObject.Find("Destroyer").GetComponent<Destroyer>().fallingTorqueFactor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            death.isDead = true;
        }
        else
        if (other.transform.tag=="Tile")
        {
            other.transform.GetComponent<Tile>().GetHit(fallingImpulseFactor, fallingTorqueFactor);
        }


    }

    IEnumerator Erease()
    {
        yield return new WaitForSeconds(5);
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
