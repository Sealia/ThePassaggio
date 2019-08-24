using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAttack : MonoBehaviour
{
    public int attackDamage = 15;
    public float speed = 5;

    GameObject player;
    PlayerStats playerHealth;
    public bool playerInRange;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerStats>();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
          //  playerInRange = true;
            playerHealth.TakeDamage(attackDamage);
            Destroy(gameObject);
            
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
           // playerInRange = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

            transform.Translate(player.transform.position * Time.deltaTime * speed);

    }



}
