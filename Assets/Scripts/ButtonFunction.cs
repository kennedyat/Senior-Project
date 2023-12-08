using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunction : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    string value;

    ButtonFunction()
    {
       value = this.value; 
    }
    void Start()
    {
        
    }

    // Update is called once per frame
   

    public string GetValue(){
        return value;
    }
}
