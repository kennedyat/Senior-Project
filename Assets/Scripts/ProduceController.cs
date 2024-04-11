using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProduceController : MonoBehaviour
{
    Vector3 mousePos;
    //public GameObject item;
    public TMP_Text textCounter;
    int counter=0;
    //private GameObject currentItem;
    bool _produceState=false;
    public Animator _anim;
    

void Awake(){
     
    textCounter.text = "0";
}
    private Vector3 GetMousePos()
    {
        
        return Camera.main.WorldToScreenPoint(transform.position);
       
    }

      private void OnMouseDown()
    {
        Debug.Log("OnMouseDown");
        if(this.tag == "bag" && _produceState == false){
            Debug.Log("Bag");
            _anim.SetBool("ProduceState", true);
            _produceState = true;


        }
        else if(this.tag == "bag" && _produceState == true){
            _anim.SetBool("ProduceState", false);
            _produceState = false;

        }
        if(this.tag == "Produce"){
            mousePos = Input.mousePosition - GetMousePos();
            //currentItem =Instantiate(item, this.gameObject.transform.position, transform.rotation);
            counter++;
            textCounter.text = counter.ToString();
        }
    }

        

    /*private void OnMouseDrag()
    {
        currentItem.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePos);
    }*/
}
