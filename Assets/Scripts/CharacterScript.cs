using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    private float rotateSpeed = 0;
    private float maxSpeed = 500;
    private  float yaxis=0;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
         float scalingFactor = 1; // Bigger for slower
        
        Quaternion target = Quaternion.Euler(0, yaxis, 0);
        if(Input.GetMouseButtonDown(0)){
            Debug.Log("hit target");
            yaxis+=720f;
           
        }
         transform.Rotate(0f, yaxis*Time.deltaTime, 0.0f);
        //transform.rotation = Quaternion.Slerp(transform.rotation,target, Time.deltaTime*5f);
       
    }
   void FixedUpdate(){
        yaxis*=.98f;
   }
   
}
