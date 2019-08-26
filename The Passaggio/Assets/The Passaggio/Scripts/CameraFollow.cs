using UnityEngine;
using System.Collections;

[ExecuteInEditMode]

public class CameraFollow : MonoBehaviour {



    public Transform player;

    public float distance=15;
    [Range(0f, 90f)]
    [SerializeField]
    private float angle;
    [SerializeField]
    private float rotation;

    public float Angle
    {
        get
        {
            return angle;
        }
    }

    void Awake ()
    {
        Follow(player);
        transform.LookAt(player);
    }
	
	void Update ()
    {
        if (player != null)
        {
            Follow(player);
#if UNITY_EDITOR
            transform.LookAt(player);
#endif
        }

    }

    void Follow(Transform target)
    {
        transform.position = target.position;
        transform.rotation = Quaternion.Euler(90f - angle, rotation, 0f);
        transform.position -= transform.forward * distance;

    }

}