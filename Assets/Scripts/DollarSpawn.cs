using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollarSpawn : MonoBehaviour
{
    private bool grabbed = false;
    Rigidbody rb;

    void Awake(){
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    private void OnMouseDown()
    {
        if( grabbed == false){
             Instantiate(this.gameObject, this.transform.position, this.transform.rotation); 
             rb.useGravity = true;
             grabbed = true;
        }
    }
}
