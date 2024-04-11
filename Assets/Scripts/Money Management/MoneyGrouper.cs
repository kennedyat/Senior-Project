using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyGrouper : MonoBehaviour
{
    /*
    * This list will sort bills and coins out
    * as instantiated, sorted in descending order.
    */
    public List<GameObject> dollars = new List<GameObject>();

    [Header("Dollar Objects")]
    public GameObject twentyDollar;
    public GameObject tenDollar;
    public GameObject fiveDollar;
    public GameObject oneDollar;

    // This dictionary returns a spawn point depenting on the currency value 
    private Dictionary<float, Transform> spawnPoints = new Dictionary<float, Transform>();

    public GameObject grouper;
    private GroupValue groupValue;
    private float tempValue;
    private float spaceBetweenDollars = 2.5f;

    // The goal of this method is to stack the money and count its value
    public void onSubmissionViewEvent()
    {
        if (!GameObject.FindGameObjectWithTag("Grouper"))
            Instantiate(grouper);
        groupValue = grouper.GetComponent<GroupValue>();
        foreach (GameObject currency in dollars)
        {
            tempValue = currency.GetComponent<DollarValue>().value;
            currency.transform.parent = grouper.transform;
            groupValue.AddValue(tempValue);
            currency.transform.position = spawnPoints[tempValue].position;
        }
    }

    public void getDollarGrid(int twenty, int ten, int five, int one){
        //Add value to list
        for(int i = 0; i<twenty; i++)
            dollars.Add(twentyDollar);
        for(int i = 0; i<ten; i++)
            dollars.Add(tenDollar);
        for(int i = 0; i<five; i++)
            dollars.Add(fiveDollar);
        for(int i = 0; i<one; i++)
            dollars.Add(oneDollar);

        setPosition();
        
        //Sort values in list
        // Multiply positions by list index
    }

    public void sortDollars(){
        GameObject temp;
        for(int i = 0; i<dollars.Count; i++){
            for(int j = 0; j<dollars.Count; j++){
                if(dollars[j].GetComponent<DollarValue>().value > dollars[i].GetComponent<DollarValue>().value){
                    temp = dollars[i];
                    dollars[i] = dollars[j];
                    dollars[j] = temp;
                }
            }
        }
    }

    public void setPosition(){
        float index = 0;
        foreach(GameObject dollar in dollars){
            dollar.transform.position  = new Vector3(dollar.transform.position.x + spaceBetweenDollars*index,
                dollar.transform.position.y, dollar.transform.position.z);
            index++;
        }
    }
}
