using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterState : MonoBehaviour
{
  
    [Header("Events")]
    public GameEvent submissionView;
    bool _mainState=true;
    bool _editState=false;
    Vector3 mousePos;
    Vector3 initialPosition;
    //public GameObject Drawer;
    //public GameObject FollowTarget;
   
    public Animator _anim;

    //Limit Drawer movement on the z axis
    float zLimitForward;
    float zLimitBackward;

    void Start(){
        initialPosition = transform.position;
        zLimitBackward = initialPosition.z;
        zLimitForward = initialPosition.z + .8f;
    }
    void Update(){
        if(_mainState==true){
            transform.position = initialPosition;
           //Drawer.transform.position = initialPosition;
        }

        //Call Follow 
        //When Opening, make mainstate false
       /* if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Opening")&&_anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !_anim.IsInTransition(0)){
           Debug.Log("Anim Ended");
           if(_mainState==true){
                Follow();
                _mainState=false;
                 //transform.Translate(Vector3.forward *1.03f);
                _anim.SetBool("OpenState", true);
           }
        } */


    }

    private Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        if(_mainState==true){
            _mainState=false;
            Open();
             _anim.SetBool("OpenState", true);
            Debug.Log("Open State");
        }else{
            mousePos= Input.mousePosition - GetMousePos();
        }
    }
    /*private void Pull(){
        _anim.SetBool("OpenState", true);
    }*/
    //Pull Object follows drawer through FollowTarget
    // Drawer becomes parent to Pull Object
    private void Open(){
        
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z +5f);
    }

    //On drag, clamp pull on z direction
    private void OnMouseDrag(){
        float zPos;
        if(_mainState == false){
          
           zPos = Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePos).z,zLimitBackward,zLimitForward);
           transform.position = new Vector3(transform.position.x, transform.position.y, zPos);
            // It seems that this function here calls a lot of times,
            // as seen by how many clones appear if you un-comment my line
            if(zPos<=zLimitBackward){
                
                submissionView.Raise(); //added line!
                Debug.Log("Closed Register!! Main State: " + _mainState);
                _anim.SetBool("OpenState", false);
                _mainState=true; 
                 //Drawer.transform.parent = null;
                 //Drawer.transform.position = initialPosition;
            }
        }
       
    }

     void OnTriggerEnter(Collider other){
        if(other.name == "RegisterTrigger" && _mainState == false){
            _anim.SetBool("OpenState", false);
            _mainState = true;
        }
     }

   



       
}

