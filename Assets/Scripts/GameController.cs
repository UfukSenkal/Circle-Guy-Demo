using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    #region Singleton class: GameController

    public static GameController Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

        }
    }

    #endregion

    [SerializeField]
  public  GameObject dummyPrefab;

    [SerializeField]
    GameObject button;

    [SerializeField]
    GameObject wheel;

    public int dummyCount;
    private float offset;

    private float _offset = 0.06f;

    List<GameObject> wheelDummyList;

 

  
    void Start()
    {
        Time.timeScale = 1;
        button.SetActive(false);
        dummyCount = 1;
        wheelDummyList = new List<GameObject>();
        RearrangeCycle();
       
       
    }


   public  void RearrangeCycle()
    {
        if (dummyCount <= 0)
        {
           
            button.gameObject.SetActive(true);
            Time.timeScale = 0;
        }

        if (wheelDummyList.Count > 0)
        {
            foreach (var dummy in wheelDummyList)
            {
               
                Destroy(dummy);
            }
        }

        offset = _offset * dummyCount;
        if (dummyCount <= 3)
        {
           
            wheel.GetComponent<SphereCollider>().radius = .20f;


        }
        if (dummyCount > 3)
        {
            wheel.GetComponent<SphereCollider>().radius = offset;
           

        }

        InstantiateDummies();

    }

    void InstantiateDummies()
    {
        for (int i = 0; i < dummyCount; i++)
        {
            Vector3 targetPos = wheel.transform.position;
            float rotateAngle = (dummyCount - 2) * 180 / dummyCount;

            GameObject go = Instantiate(dummyPrefab);

            float angle = i * (2 * Mathf.PI / dummyCount);


            float x = Mathf.Cos(angle) * offset;
            float y = Mathf.Sin(angle) * offset;

            targetPos = new Vector3(targetPos.x, targetPos.y + y, targetPos.z - x);
            go.transform.Rotate(i * (180 - rotateAngle), 0, 0);

            go.transform.position = targetPos;
            go.transform.parent = wheel.transform;
            go.tag = "WheelDummy";
            wheelDummyList.Add(go);

        }
    }
   
    public void Restart()
    {
               
        SceneManager.LoadScene(0);
    }
   

}
