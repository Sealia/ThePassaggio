using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSpawner : MonoBehaviour
{
    public GameObject lightPrefab;
    public float distanceBetweenLights = 10;
    public float lightDestroyDistance = 20;
    public int maximumLightsAhead = 4;

    private Transform player;

    private List<GameObject> lights;
    private int generatedLights;
    private float playerStartingPosition;

    private int side = 1;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerStartingPosition = player.position.z;
        lights = new List<GameObject>();
    }
    void Start()
    {
        
    }


    void Update()
    {      
        if (player.position.z >= playerStartingPosition + (lights.Count - maximumLightsAhead) * distanceBetweenLights)
        {
            float z = playerStartingPosition + generatedLights * distanceBetweenLights;
            float y = Random.Range(2.5f, 4f);
            float x = Random.Range(2.5f, 6f) * side;

            Vector3 position = new Vector3(x, y, z);

            lights.Add(Instantiate(lightPrefab, position, Quaternion.identity));
            generatedLights++;
            side *= -1;
        }

        if (lights[0].transform.position.z < player.position.z - lightDestroyDistance)
        {
            GameObject light = lights[0];
            lights.Remove(light);
            Destroy(light);
        }
    }
}
