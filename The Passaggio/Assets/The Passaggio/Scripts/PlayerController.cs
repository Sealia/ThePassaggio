using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //private CameraFollow camera;

    public float acceleration = 1;
    public float maximumSpeed = 20;
    //public bool useCameraViewDirection = false;

    private float horizontal;
    private float vertical;
    private new Rigidbody rigidbody;
    private PlayerStats stats;

    private Vector3 desiredDirection;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        stats = GetComponent<PlayerStats>();
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        desiredDirection = new Vector3(horizontal, 0, vertical).normalized;

        /*
        if (useCameraViewDirection && desiredDirection != Vector3.zero)
        {
            desiredDirection = Quaternion.Euler(0, -(camera.Angle -45), 0) * desiredDirection;

        }*/


        // Death
        if(rigidbody.position.y < -0.5f)
        {
            stats.currentHealth = 0;
            stats.isDead=true;
            stats.Death();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            Dodge();
        }

        


    }

    private void FixedUpdate()
    {
        // Limit acceleration
        float currentSpeed = rigidbody.velocity.magnitude;
        float velocityLimit = Mathf.Abs((currentSpeed / maximumSpeed) - 1);

        // Accelerate
        rigidbody.AddForce(desiredDirection * acceleration * velocityLimit, ForceMode.Force);

        


    }

    void Dodge()
    {
            if(stats.currentStamina>0)
            {
                //unik
                stats.StaminaLoss();
            }
    }
}
