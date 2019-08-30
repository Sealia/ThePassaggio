using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    private void Awake()
    {

    }

    void Start()
    {

    }

    void Update()
    {
        if(gameObject.transform.childCount <= 10)
        {
            Destroy(gameObject,3f);
        }
    }
}
