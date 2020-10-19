using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Transform wheelTransform;


    void Update()
    {
        if (Vector3.Distance(transform.position,wheelTransform.position) > 3f)
        {
          
            transform.position += new Vector3(0, 0, Time.deltaTime);
        }
    }
}
