using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DollarController : MonoBehaviour
{
    
    #region Variables
    public GameObject dollarSpawn;

   
    GameObject currentDollar;
    
   
     DollarValue dollarValue;
    
    //Placeholder position for dollars on counter 
    Vector3 counterPosition = new Vector3(-0.59f,0.294f,-0.14f);
    float spaceBetweenDollars=.1f;
    bool created = false;
    #endregion

    // Start is called before the first frame update
    void Start()
    {

        dollarValue = dollarSpawn.GetComponent<DollarValue>();
    }

    void GetDollarValue(){
        dollarValue = currentDollar.GetComponent<DollarValue>();
    

    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetMouseButtonDown(0)){
            Clicked();
         }
    }

    void Clicked(){
        
        //Checks if mouse is clicked on a Dollar Holder
       
            Debug.Log("CLicking");
            RaycastHit hit;
			var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);
            if(hit.collider.gameObject.tag == "DollarHolder"){
                dollarValue = hit.collider.gameObject.GetComponent<DollarValue>();
                Debug.Log("CLicking DollarHolder");
                //Gets value of clicked button from Dollar Holder Value
               // string stringVal=hit.collider.gameObject.name.ToString();
                //Spawns current dollar that holds the clicked dollar value
                currentDollar = Instantiate(dollarSpawn, hit.collider.gameObject.transform.position, dollarSpawn.transform.rotation);
                //GetDollarValue();
               // dollarValue.AddValue(int.Parse(stringVal));
                //When dollar is created, stop animating
                //created = true;
                
                // Debug.Log(dollarValue.value);
            }
        
            
        
    }
    //Check if there is a greater value or lower value than currrent dollar
    //if top value is greater check bottom value
    //if bottom value is less check middle value
    //half value and continue to check middle


    /*int DollarPlacement(){
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
        }
       

       return size;
    }

    void DollarRotate(int index){

        int counter=dollars.Count/2;
        dollars[index].transform.RotateAround(dollarView.transform.position, Vector3.forward, (index-(dollars.Count/2))*5);
        for(int i=0; i<dollars.Count; i++){
            dollars[i].transform.position = new Vector3(dollarView.transform.position.x+(spaceBetweenDollars*counter),
            dollarView.transform.position.y,dollarView.transform.position.z+(-.005f*counter)); 
            if(i>index){
                 dollars[i].transform.RotateAround(dollarView.transform.position, Vector3.forward, 5f);
            }else if(i<index){
                dollars[i].transform.RotateAround(dollarView.transform.position, Vector3.forward, -5f);
            }
            counter--;
           
        
        }
        
        dollars[index].transform.position = new Vector3(dollarView.transform.position.x,
               dollarView.transform.position.y,dollarView.transform.position.z+(index/dollars.Count)/60);
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

    void PlaceCounter(){
        int index=0;
        foreach(GameObject dol in dollars){
            dol.transform.position = new Vector3(counterPosition.x
            , counterPosition.y + .01f*index,
         counterPosition.z);
            //dol.transform.position = counterPosition;
            dol.transform.rotation = new Quaternion(0f,0f, 0f, 0f);
            index++;
        }
    }



    //This script checks amount of dollars & dollar value  and places them accordingly
    //left->right less value -> more value
    // larger value overlaps
    //change position the angle

*/
}
