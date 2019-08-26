using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{

    public struct Tile
    {
        public bool destroyed;
        public Transform t;

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
    Tile t;
    public GameObject[] temp = new GameObject[64];
    GameObject bridge;
    CreateScene createScene;
    GameObject manager;
    //List<int> numbers = new List<int>() { 0, 1, 2, 3, 4, 5 };
    //List<int> numbers2 = new List<int>() { 0, 1, 2, 3, 4, 5 };
    List<int> numbers2;
    List<int> column = new List<int>() { 24, 25, 30, 31, 32, 33, 38, 39 };
    Rigidbody rb;


    private void Awake()
    {
        tiles = new List<Tile>();
        manager = GameObject.Find("GameManager");
        bridge = GameObject.Find("Bridge");
        rb = bridge.GetComponent<Rigidbody>();
        createScene = manager.GetComponent<CreateScene>();
        Assign();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       /* if(createScene.Sections.Count==1)
        {
            StartCoroutine(TilesDestroy());
        */
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

    
    public void StartDestroyingSequence(int id)
    {
        StartCoroutine(TilesDestroy(id));
       
    }
    
    public  IEnumerator TilesDestroy(int id)
    {
        while (true)
        {
            numbers2 = new List<int> { 0, 1, 2, 3, 4, 5 } ;
            int b = 6;
            for (int i = 0; i < 10; i++)
            {


                if (i == 4)
                {
                    numbers2.Add(30);
                    numbers2.Add(31);
                    b = 8;
                }

                if(i==5)
                {
                    int y = 8675;
                }
                if (i == 6)
                {
                    numbers2.Sort();
                    b = 6;
                    numbers2.Remove(numbers2[0]);
                    numbers2.Remove(numbers2[0]);
                    b = 6;
                }
                
                numbers2 = ShuffleList<int>(numbers2);
                for (int j = 0; j < b; j++)
                {
                    Tile tem = new Tile();
                    
                    bool ok = false;

                    if (i > 3 && i < 6)
                    {

                        tem = tiles[numbers2[j]];
                        if (column.Contains(numbers2[j])==false)
                        {                           
                            ok = true;
                        }                                            
                    }
                    else
                    {
                            tem = tiles[numbers2[j]];
                            ok = true;                      
                    }

                    if(numbers2[j]>39 || numbers2[j]<32)
                    {
                        numbers2[j] += numbers2.Count;
                    }
                    else
                    {
                        numbers2[j] += 6;
                    }
                       

                   if (tem.destroyed==false && ok==true)
                    {
                        
                        tem.t.GetChild(0).GetComponent<Rigidbody>().useGravity=true;
                        tem.t.GetChild(1).gameObject.SetActive(false);
                        yield return new WaitForSeconds(0.1f);
                    }  
                }
            }
             //   yield return new WaitForSeconds(5);


                createScene.DestroyNextSection(1);
            yield return new WaitForSeconds(5);
                createScene.RemoveFromList();


        }
    }

    void Assign()
    {
        foreach(GameObject i in temp)
        {

            t = new Tile(false, i.transform);
            tiles.Add(t);


        }
    }
    
}
