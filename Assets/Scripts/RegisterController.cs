using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class RegisterController : MonoBehaviour
{
    ButtonFunction _buttonFunction;
    float currentVal;
    float finalVal;
    string currentButton;
    string firstValue;
    string secondValue;
    string op="";

    [SerializeField]
    GameObject textObject;
    
    TMP_Text text;
    
    // Start is called before the first frame update
    void Start()
    {
        text = textObject.GetComponent<TMP_Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Clicked();
    }

    void Clicked(){
        
        //Checks if mouse is clicked on
        if(Input.GetMouseButtonDown(0)){
            RaycastHit hit;
			var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Gets value of clicked button
            Physics.Raycast(ray, out hit);
            if(hit.collider.gameObject.tag == "Button"){
                _buttonFunction=hit.collider.gameObject.GetComponent<ButtonFunction>();
                currentButton = _buttonFunction.GetValue();
                Debug.Log(currentButton);
                ButtonCheck(currentButton);
            }
            else{
                //If button is not pressed
               Debug.Log("Nothing Pressed");
            }
        }
        
    }
    //Checks the button value
    void ButtonCheck(string currentButton){
        //If an integer
        if(int.TryParse(currentButton, out int n)){
            Debug.Log("Inside");

             if(op == ""){
                Debug.Log("No operator");
                firstValue+=currentButton;
                 text.text= firstValue;
             }
             else{
                Debug.Log("operator");
                secondValue+=currentButton;
                 text.text= secondValue;
             }
             
            
        }
        else{
            if(op != ""){
                
                OperatorButtons(op);
                if(currentButton == "="){
                    text.text = firstValue;
                }
                //If an operator
                
            }
            op=currentButton;
        }
        
    }
    //Checks if value matches an operator
    void OperatorButtons(string op){
        int a = int.Parse(firstValue);
        int b = int.Parse(secondValue);
        switch(op){
            case "+":
                firstValue = (a+b).ToString();
                break;
            case"-":
                firstValue = (a-b).ToString();
                break;
            case"=":
                break;
           

        }
    }
}
