using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProduceController : MonoBehaviour
{
    Vector3 mousePos;
    public TMP_Text textCounter;
    public Animator _anim;
    int counter=0;
    bool _produceState=false;
   
    

void Awake(){
     
    textCounter.text = "0";
}
    private Vector3 GetMousePos()
    {
        
        return Camera.main.WorldToScreenPoint(transform.position);
       
    }

      private void OnMouseDown()
    {
        if(this.tag == "bag" && _produceState == false){
            _anim.SetBool("ProduceState", true);
            _produceState = true;
        }

        else if(this.tag == "bag" && _produceState == true){
            _anim.SetBool("ProduceState", false);
            _produceState = false;
        }

        if(this.tag == "Produce"){
            mousePos = Input.mousePosition - GetMousePos();
            counter++;
            textCounter.text = counter.ToString();
        }
    }
}
