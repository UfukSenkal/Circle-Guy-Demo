using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    
    void OnTriggerEnter(Collider col)
    {
       
        if (col.gameObject.tag == "Dummy" )
        {
            col.gameObject.tag = "WheelDummy";
            Destroy(col.gameObject);
            GameController.Instance.dummyCount++;
            GameController.Instance.RearrangeCycle();
          

        }
        if (col.gameObject.tag == "Obstacle")
        {
            
            col.gameObject.tag = "StayDummy";
            GameController.Instance.dummyCount--;
            GameController.Instance.RearrangeCycle();
            GameObject go = Instantiate(GameController.Instance.dummyPrefab);
            go.transform.position = new Vector3(transform.position.x, transform.position.y, col.transform.position.z);
            go.transform.Rotate(90, 0, 0);

            go.tag = "StayDummy";

        }
        if (col.gameObject.tag == "ObstacleWall")
        {

            col.gameObject.tag = "Jump";
            GameController.Instance.dummyCount--;
            GameController.Instance.RearrangeCycle();
            GameObject go = Instantiate(GameController.Instance.dummyPrefab);
            go.transform.position = new Vector3(transform.position.x, col.transform.position.y, transform.position.z);
           
            go.tag = "Jump";

        }
    }
}
