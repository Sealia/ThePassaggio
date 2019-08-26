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
        if(other.transform.parent.tag=="Tile")
        {
           
            other.transform.parent.GetChild(0).GetComponent<Rigidbody>().useGravity = true;
            other.gameObject.transform.gameObject.SetActive(false);


        }
    }

    IEnumerator Erease()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
