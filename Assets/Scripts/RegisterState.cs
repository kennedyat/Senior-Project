using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterState : MonoBehaviour
{
  
    bool _mainState=true;
    bool _editState=false;
    Vector3 mousePos;
    Vector3 initialPosition;
    public GameObject Drawer;
    public GameObject FollowTarget;
   
    public Animator _anim;

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
           Drawer.transform.position = initialPosition;
            
        }
        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Opening")&&_anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !_anim.IsInTransition(0)){
           Debug.Log("Anim Ended");
           if(_mainState==true){
                Follow();
                _mainState=false;
                
                //_anim.SetBool("OpenState", true);
           }
        } 


    }

    private Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        
        if(_mainState==true){
            Pull();
            Debug.Log("Closed State");
        }else{
            mousePos= Input.mousePosition - GetMousePos();
        }
    }
    private void Pull(){

        Debug.Log("Openedstate is false");  

         _anim.SetBool("OpenState", true);
        
    }

    private void Follow(){
        transform.position = FollowTarget.transform.position;
      
        this.transform.parent = null;
        Drawer.transform.parent = this.transform;
      
        
    }

    private void OnMouseDrag(){
        float zPos;
        if(_mainState == false){
          
           zPos = Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePos).z,zLimitBackward,zLimitForward);
           transform.position = new Vector3(transform.position.x, transform.position.y, zPos);
            if(zPos<=zLimitBackward){
                
                _anim.SetBool("OpenState", false);
                _mainState=true; 
                 Drawer.transform.parent = null;
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

