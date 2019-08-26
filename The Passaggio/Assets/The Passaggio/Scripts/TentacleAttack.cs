using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleAttack : MonoBehaviour
{
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
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
        if(other.gameObject.tag=="Tile")
        {
            other.gameObject.transform.GetChild(0).GetComponent<Rigidbody>().useGravity = true;
            other.gameObject.transform.GetChild(1).gameObject.SetActive(false);


        }
    }

    IEnumerator Erease()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
