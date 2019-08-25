using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float speed = 20;
    private float horizontalInput;
    private float forwardInput;

    GameObject player;
    PlayerStats playerStamina;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStamina = player.GetComponent<PlayerStats>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        if(player.transform.position.y<-0.5)
        {
            playerStamina.currentHealth = 0;
            playerStamina.isDead=true;
            playerStamina.Death();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
           // transform.Translate(Vector3.down * Time.deltaTime * speed * 2);
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            Dodge();
        }

            transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

    }

    void Dodge()
    {
            if(playerStamina.currentStamina>0)
            {
                //unik
                playerStamina.StaminaLoss();
            }
    }
}
