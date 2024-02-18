using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DollarController : MonoBehaviour
{
    
    #region Variables
    public GameObject dollarSpawn;
    public GameObject dollarView;
    GameObject currentDollar;
    
    public List<GameObject> dollars = new List<GameObject>();
     DollarValue dollarValue;
    
    Animator animator;
    bool created = false;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        animator.enabled = true;
        dollarValue = dollarSpawn.GetComponent<DollarValue>();
    }

    void GetDollarValue(){
        dollarValue = currentDollar.GetComponent<DollarValue>();
        animator = currentDollar.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Clicked();
        if(created){
            
            if(DollarAnimatorCheck()){
                animator.StopPlayback();
                DollarRotate(DollarPlacement());
                created = false;
            
            }
            
        }
        
    }

    void Clicked(){
        
        //Checks if mouse is clicked on a Dollar Holder
        if(Input.GetMouseButtonDown(0)){
            RaycastHit hit;
			var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);
            if(hit.collider.gameObject.tag == "DollarHolder"){
                //Gets value of clicked button from Dollar Holder Value
                string stringVal=hit.collider.gameObject.name.ToString();
                //Spawns current dollar that holds the clicked dollar value
                currentDollar = Instantiate(dollarSpawn, transform.position, transform.rotation);
                GetDollarValue();
                animator.Play("MoneyOut");
                dollarValue.AddValue(int.Parse(stringVal));
                //When dollar is created, stop animating
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
            Debug.Log("Biggest");

        } else if(dollars[0].GetComponent<DollarValue>().value>=dollarValue.value){
            dollars.Insert(0, currentDollar);
            size = 0;
            Debug.Log("Smallest");

        } else{
            size=size/2;
            for(int i=0;i<dollars.Count/2;i++){

                if(dollars[size-1].GetComponent<DollarValue>().value==dollarValue.value){
                    dollars.Insert(size, currentDollar);
                    Debug.Log("Equal");
                    break;
                    }
                if(dollars[size-1].GetComponent<DollarValue>().value> dollarValue.value){
                    size = size/2;
                    Debug.Log("Less : " + dollars[size-1].GetComponent<DollarValue>().value + " vs " + dollarValue.value);
                }
                else{
                    size=(size+dollars.Count)/2;
                    Debug.Log("Greater : " + dollars[size-1].GetComponent<DollarValue>().value + " vs " + dollarValue.value);
                }
            }
            
            dollars.Insert(size, currentDollar);
           
        }
       

       return size;
    }

    void DollarRotate(int index){
        dollars[index].transform.position = new Vector3(dollars[index].transform.position.x,
               dollars[index].transform.position.y,dollars[index].transform.position.z+(index/dollars.Count)/60);
         dollars[index].transform.RotateAround(dollarView.transform.position, Vector3.forward, (index-(dollars.Count/2))*5);
        for(int i=0;i<dollars.Count;i++){
            //dollars[i].transform.position = new Vector3(dollars[i].transform.position.x+(.1f*i+1),
               // dollars[i].transform.position.y,dollars[i].transform.position.z);
            
            if(i>index){
                 dollars[i].transform.RotateAround(dollarView.transform.position, Vector3.forward, 5f);
            }else{
                dollars[i].transform.RotateAround(dollarView.transform.position, Vector3.forward, -5f);
            }
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
