using UnityEngine;
using System.Collections;

[ExecuteInEditMode]

public class CameraFollow : MonoBehaviour {



    private Transform player;

    public float distance=15;
    [Range(0f, 90f)]
    [SerializeField]
    private float angle;
    [SerializeField]
    private float rotation;



    void Awake () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Follow(player);
        transform.LookAt(player);
    }
	
	void Update () {

        Follow(player);
#if UNITY_EDITOR
        transform.LookAt(player);
#endif
    }

    void Follow(Transform target)
    {
        if(target.position.y > 0)
        {
            transform.position = target.position;
            transform.position -= transform.forward * distance;
        }

        transform.rotation = Quaternion.Euler(90f - angle, rotation, 0f);
      
    }

}