using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DollarValue : MonoBehaviour
{
    public float value;
    //Renderer _mat;

    // Start is called before the first frame update
    void Start(){
      //  _mat = GetComponent<Renderer>();

    }
    
    public void AddValue(float assigned_Value){
        value = assigned_Value;
        // _mat = GetComponent<Renderer>();
        //GetMaterial();
    }

  /*  public void GetMaterial(){
        switch(value){
            case 20:
                _mat.material.color = new Color(0,0,255);
                break;
            case 10:
                _mat.material.color = new Color(0,255,0);
                break;
            case 5:
                _mat.material.color = new Color(255,0,0);
                break;
            case 1:
                _mat.material.color = new Color(255,138,248);
                break;
            
            }
    }*/
}
