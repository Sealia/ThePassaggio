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
    GameObject manager; 
    List<int> numbers = new List<int>() { 0, 1, 2, 3, 4, 5 };


    private void Awake()
    {
        tiles = new List<Tile>();
        manager = GameObject.Find("GameManager");
        bridge = GameObject.Find("Bridge");
        createScene = manager.GetComponent<CreateScene>();
        Assign();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TilesDestroy(createScene.Sections[0]));
    }

    // Update is called once per frame
    void Update()
    {
        if(createScene.Sections.Count==1)
        {
            StartCoroutine(TilesDestroy(createScene.Sections[0]));
        }
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
                yield return new WaitForSeconds(0.5f);
            }

        }
       
       // createScene.Sections.Remove(createScene.Sections[0]);
        createScene.DestroyNextSection();
        StopCoroutine(TilesDestroy(section));
        
    }

    void Assign()
    {
        foreach(Transform child in transform)
        {

        }
    }

    
}
