using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundtrack : MonoBehaviour
{

    public AudioSource audioSource;


    private void Awake()
    {
    }
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }



    void Start()
    {
        Play();
    }

    public void Play()
    {
        audioSource.Play();
    }
}
