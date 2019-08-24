using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{

    public struct Tile
    {
        public bool destroyed;
        Transform t;

        public Tile(bool destroyed, Transform t)
        {
            this.destroyed = destroyed;
            this.t = t;
        }

        public Tile(bool destroyed)
        {
            this.destroyed = destroyed;
            this.t = null ;
        }
    }

    public List<Tile> tiles;
    GameObject bridge;
    CreateScene createScene;
    List<int> numbers = new List<int>() { 0, 1, 2, 3, 4, 5 };


    private void Awake()
    {
        tiles = new List<Tile>();
        bridge = GameObject.Find("Bridge");
        createScene = GetComponent<CreateScene>();
        Assign();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TilesDestroy(bridge));
    }

    // Update is called once per frame
    void Update()
    {

    }

    private List<E> ShuffleList<E>(List<E> inputList)
    {
        List<E> randomList = new List<E>();

        System.Random r = new System.Random();
        int index = 0;
        while (inputList.Count > 0)
        {
            index = r.Next(0, inputList.Count);
            randomList.Add(inputList[index]);
            inputList.RemoveAt(index);
        }

        return randomList;

    }

    public void GetDestroyed(GameObject section)
    {
        StartCoroutine(TilesDestroy(section));
    }

    IEnumerator TilesDestroy(GameObject section)
    {
        for (int i = 0; i < 10; i++)
        {
            numbers = ShuffleList<int>(numbers);

            for (int j = 0; j < 6; j++)
            {
                //tu odpada tegesik
                yield return new WaitForSeconds(0.1f);
            }

        }
        Destroy(section);
        createScene.DestroyNextSection();
        yield return null;

    }

    void Assign()
    {
        foreach(Transform child in transform)
        {

        }
    }

    
}
