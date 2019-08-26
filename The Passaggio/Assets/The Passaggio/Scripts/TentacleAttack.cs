using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleAttack : MonoBehaviour
{
    Animator anim;
    GameObject player;
    PlayerStats death;

    private void Awake()
    {
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
}
