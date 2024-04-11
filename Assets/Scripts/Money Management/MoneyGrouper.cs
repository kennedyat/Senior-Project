using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyGrouper : MonoBehaviour
{
    /*
    * This list will sort bills and coins out
    * as instantiated, sorted in descending order.
    */
    public List<GameObject> allMoney = new List<GameObject>();

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
        foreach (GameObject currency in allMoney)
        {
            tempValue = currency.GetComponent<DollarValue>().value;
            currency.transform.parent = grouper.transform;
            groupValue.AddValue(tempValue);
            currency.transform.position = spawnPoints[tempValue].position;
        }
    }

    public void onSubmissionEvent()
    {
        allMoney.Clear();
    }

    public void getDollarGrid(int twenty, int ten, int five, int one){
        //Add value to list
        for(int i = 0; i<twenty; i++)
            allMoney.Add(twentyDollar);
        for(int i = 0; i<ten; i++)
            allMoney.Add(tenDollar);
        for(int i = 0; i<five; i++)
            allMoney.Add(fiveDollar);
        for(int i = 0; i<one; i++)
            allMoney.Add(oneDollar);

        setPosition();
        
        //Sort values in list
        // Multiply positions by list index
    }

    public void Add(DollarValue currency){
        if (currency.value < 1)
            allMoney.Add(currency.gameObject);
        else
        {
            for (int i = 0; i < allMoney.Count; i++)
            {
                if (allMoney[i].GetComponent<DollarValue>().value >= currency.value)
                {
                    allMoney.Insert(i, currency.gameObject);
                    break;
                }
            }
        }
        
        /*GameObject temp;
        for(int i = 0; i<allMoney.Count; i++){
            for(int j = 0; j<allMoney.Count; j++){
                if(allMoney[j].GetComponent<DollarValue>().value > allMoney[i].GetComponent<DollarValue>().value){
                    temp = allMoney[i];
                    allMoney[i] = allMoney[j];
                    allMoney[j] = temp;
                }
            }
        }*/
    }

    public void setPosition(){
        float index = 0;
        foreach(GameObject dollar in allMoney){
            dollar.transform.position  = new Vector3(dollar.transform.position.x + spaceBetweenDollars*index,
                dollar.transform.position.y, dollar.transform.position.z);
            index++;
        }
    }
}
