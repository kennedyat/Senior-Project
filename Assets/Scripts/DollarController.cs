using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DollarController : MonoBehaviour
{
    public GameObject dollarSpawn;
    DollarValue dollarValue;
    public List<GameObject> dollars = new List<GameObject>();
    public List<int> dollarsVal = new List<int>();
    GameObject currentDollar;
    public GameObject dollarView;
    Animator animator;
    bool created = false;
    // Start is called before the first frame update
    void Start()
    {
        animator.enabled = true;


        dollarValue = dollarSpawn.GetComponent<DollarValue>();
    }
    void GetDollarValue(){
        dollarValue = currentDollar.GetComponent<DollarValue>();
        animator = currentDollar.GetComponent<Animator>();
        animator.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        Clicked();
        if(created){
            
            if(DollarAnimatorCheck()){
                Debug.Log("Anim");
                animator.enabled = false;
            DollarRotate(DollarPlacement());
            created = false;
            
            }
            
        }
        
    }

    void Clicked(){
        
        //Checks if mouse is clicked on
        if(Input.GetMouseButtonDown(0)){
            RaycastHit hit;
			var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Gets value of clicked button
            Physics.Raycast(ray, out hit);
            if(hit.collider.gameObject.tag == "DollarHolder"){
                string stringVal=hit.collider.gameObject.name.ToString();
                currentDollar = Instantiate(dollarSpawn, transform.position, transform.rotation);
                GetDollarValue();
                dollarValue.AddValue(int.Parse(stringVal));
                
                created = true;
                
                 Debug.Log(dollarValue.value);
            }
            else{
                //If button is not pressed
               Debug.Log("Nothing Pressed");
            }
        }
        
    }
    //Check if there is a greater value or lower value than currrent dollar
    //if top value is greater check bottom value
    //if bottom value is less check middle value
    //half value and continue to check middle


    int DollarPlacement(){
        dollarsVal.Clear();
        //Determines index where to look for
        int size = dollars.Count;

        //If empty, just add dollar as index 0; 
        if(dollars.Count == 0){
            dollars.Add(currentDollar);
              size=0;
           // return 0;
        } else if(dollars[dollars.Count - 1].GetComponent<DollarValue>().value<=dollarValue.value){
            dollars.Insert(dollars.Count , currentDollar);
            size = dollars.Count-1; 

        } else if(dollars[0].GetComponent<DollarValue>().value>=dollarValue.value){
            dollars.Insert(0, currentDollar);
            size = 0;

        } else{
            size=size/2;
            for(int i=0;i<dollars.Count/2;i++){

                Debug.Log(dollars[size-1].GetComponent<DollarValue>().value+ " vs " + dollarValue.value);
                if(dollars[size-1].GetComponent<DollarValue>().value==dollarValue.value){
                    dollars.Insert(size, currentDollar);
                    break;
                    }
                if(dollars[size-1].GetComponent<DollarValue>().value> dollarValue.value){
                    size = size/2;
                }
                else{
                    size=(size+dollars.Count)/2;
                }
            }
            
            dollars.Insert(size, currentDollar);
           
        }
        for(int i=0;i<dollars.Count;i++){
            dollarsVal.Add(dollars[i].GetComponent<DollarValue>().value);
        }
        Debug.Log("~~Size:" + size);

       return size;
    }

    void DollarRotate(int index){
        for(int i=0;i<index+1;i++){
            dollars[i].transform.position = new Vector3(dollars[i].transform.position.x+(.1f*i+1),
                dollars[i].transform.position.y,dollars[i].transform.position.z);
            //dollars[index].transform.RotateAround(dollarView.transform.position, Vector3.up, 120);
        }
    }

    bool DollarAnimatorCheck(){
        
        return animator.GetCurrentAnimatorStateInfo(0).length >
           animator.GetCurrentAnimatorStateInfo(0).normalizedTime;

    }



    //This script checks amount of dollars & dollar value  and places them accordingly
    //left->right less value -> more value
    // larger value overlaps
    //change position the angle


}
