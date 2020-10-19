using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speedForward = .9f;
    public float speedRotation = 2.5f;
    public float speedSides = 20f;
    public float jumpForce = 1750f;
 
  
    
    void Update()
    {
        
        this.GetComponent<Rigidbody>().velocity = new Vector3(0,0, speedForward);

        transform.Rotate(speedRotation, 0, 0);


        if (Input.GetKey(KeyCode.D))
        {
            this.GetComponent<Rigidbody>().AddForce(Vector3.right * speedSides);
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.GetComponent<Rigidbody>().AddForce(Vector3.left * speedSides);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Jump")
        {
                      
            this.GetComponent<Rigidbody>().AddForce(Vector3.up *  jumpForce);
           
           collision.gameObject.tag = "WheelDummy";
            
        }
    }



}
