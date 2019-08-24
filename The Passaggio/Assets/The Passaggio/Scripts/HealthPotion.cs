using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    private int hp = 10;
    GameObject player;
    PlayerStats playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerStats>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {

            playerHealth.Heal(hp);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
