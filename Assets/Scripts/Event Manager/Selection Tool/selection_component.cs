using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selection_component : MonoBehaviour
{
    [SerializeField]
    private Material outliner;
    private GameObject face = null;
    private GameObject child = null;
    Material originalMat;
    Material currentMat;

    void Start()
    {
         //Get Child & Face of Child of Grabbed Object -- Only for Dollars!!!
        if( this.transform.childCount>0){
            child = this.transform.GetChild(0).gameObject;
            face = getFaceObject(child);
        }else{
            Debug.Log("Coins");
            face = transform.gameObject;
        }
       


        if (face != null){
            Debug.Log("Face");
            originalMat = new Material(face.GetComponent<Renderer>().materials[0]) ;
            currentMat = face.GetComponent<Renderer>().materials[0];
            setFaceRender();
        }
        
        transform.parent = GameObject.FindGameObjectWithTag("Parent").transform;
        transform.parent.gameObject.GetComponent<GroupValue>().AddValue(gameObject.GetComponent<DollarValue>().value);
    }

    //This returns the texture when deselected
    private void OnDestroy()
    {
        face.GetComponent<Renderer>().materials[0] = originalMat;
        transform.parent.gameObject.GetComponent<GroupValue>().SubtractValue(gameObject.GetComponent<DollarValue>().value);
        transform.parent = null;
    }

    private GameObject getFaceObject(GameObject child){
        GameObject found = null;
        foreach(Transform transform in child.transform) {
            if(transform.CompareTag("Face")){
                found = transform.gameObject;
                break;
            }
        }
        return found;
    }

    private void setFaceRender(){
         currentMat.color = Color.green;
         currentMat.SetColor("_EmissionColor", Color.black);
    }
}