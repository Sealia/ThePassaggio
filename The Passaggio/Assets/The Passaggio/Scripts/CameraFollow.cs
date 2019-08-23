using UnityEngine;
using System.Collections;

[ExecuteInEditMode]

public class CameraFollow : MonoBehaviour {

    /*
    [SerializeField]
    Transform target { get; set; }


    public float distance { get; set; }
    [InspectorRange(0f, 90f)]
    [SerializeField]
    float angle { get; set; }
    [SerializeField]
    float rotation { get; set; }
    */

    [SerializeField]
    private GeneralManager generalManager;

    public float distance;
    [Range(0f, 90f)]
    [SerializeField]
    private float angle;
    [SerializeField]
    private float rotation;

    [SerializeField]
    private bool isCamera = false;

    private void Awake()
    {
        if (generalManager != null && isCamera)
            generalManager.cameraFollow = this;
    }

    void Start () {
        if (generalManager != null && generalManager.currentPlayerCharacter != null)
        {
            Follow(generalManager.currentPlayerCharacter.transform);
            transform.LookAt(generalManager.currentPlayerCharacter.transform);
        }
            
    }
	
	void Update () {
        if (generalManager != null && generalManager.currentPlayerCharacter != null)
        {
            Follow(generalManager.currentPlayerCharacter.transform);
#if UNITY_EDITOR
            transform.LookAt(generalManager.currentPlayerCharacter.transform);
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