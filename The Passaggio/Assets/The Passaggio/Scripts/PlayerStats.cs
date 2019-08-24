﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    private int startingStamina = 4;
    private int startingHealth = 100;
    private int maxHealth = 100;
    private int maxstamina = 4;
    public int currentHealth;
    public int currentStamina;
    PlayerController playerController;

    bool isDead;
    bool damaged;
    float timer;

    void Awake()
    {
        playerController = GetComponent<PlayerController>();
        currentHealth = startingHealth;
        currentStamina = startingStamina;

    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AddStamina());
    }

    // Update is called once per frame
    void Update()
    {
       // timer += Time.deltaTime;


    }

    public void TakeDamage(int dmg_p)
    {
        currentHealth -= dmg_p;
        if(currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    public void Heal(int hp)
    {
        if(currentHealth+hp >= maxHealth )
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += hp;
        }
       

    }

   public void StaminaLoss()
    {
        currentStamina -= 1;
    }

    IEnumerator AddStamina()
    {
        while(true)
        {
            if(currentStamina<maxstamina)
            {
                currentStamina += 1;
                yield return new WaitForSeconds(2);
            }
            else
            {
                yield return null;
            }
        }
    }
    
    void Death()
    {
       isDead = true;
       playerController.enabled = false;

        // YOU DIED
    }
}