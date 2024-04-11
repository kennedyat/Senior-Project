using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class MoneyGrouper : MonoBehaviour
{
    /*
    * This list will sort bills and coins out
    * as instantiated, sorted in descending order.
    */
    public List<GameObject> submissionMoney = new List<GameObject>();
    public List<GameObject> tipMoney = new List<GameObject>();
    private float orderValue = 0;

    [Header("Game Object Count")]
    public int submissionCoins = 0;
    public int submissionDollars = 0;
    public int tipCoins = 0;
    public int tipDollars = 0;

    [Header("Dollar Objects")]
    public GameObject twentyDollar;
    public GameObject tenDollar;
    public GameObject fiveDollar;
    public GameObject oneDollar;
    private GameObject[] dollars = new GameObject[4];

    // This dictionary returns a spawn point depenting on the currency value 
    private Dictionary<float, Transform> spawnPoints = new Dictionary<float, Transform>();

    public GameObject grouper;
    private GameObject tipGrouper = null;
    private GameObject submissionGrouper = null;

    private GroupValue groupValue;
    private float tempValue;
    private float spaceBetweenDollars = 2.5f;

    public void Start()
    {
        dollars[0] = twentyDollar;
        dollars[1] = tenDollar;
        dollars[2] = fiveDollar;
        dollars[3] = oneDollar;
    }

    // The goal of this method is to stack the money and count its value
    public void onSubmissionViewEvent()
    {
        if (!(tipGrouper && submissionGrouper))
        {
            tipGrouper = Instantiate(grouper);
            submissionGrouper = Instantiate(grouper);
        }
        groupValue = grouper.GetComponent<GroupValue>();
        foreach (GameObject currency in submissionMoney)
        {
            tempValue = currency.GetComponent<DollarValue>().value;
            currency.transform.parent = grouper.transform;
            groupValue.AddValue(tempValue);
            currency.transform.position = spawnPoints[tempValue].position;
        }
    }

    public void onSubmissionEvent()
    {
        if (!submissionGrouper)
        {
            submissionMoney.Clear();
            submissionCoins = 0;
            submissionDollars = 0;
        }

        if (!tipGrouper)
        {
            tipMoney.Clear();
            tipCoins = 0;
            tipDollars = 0;
        }
    }

    public void GeneratePayment(float orderValue){
        GameObject temp;
        for (int i = 0; this.orderValue < orderValue; i++)
        {
            
        }
        
        /*//Add value to list
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
        // Multiply positions by list index*/
    }

    // hspacing is horizontal spacing
    // vspacing is vertical spacing
    // c stands for coin
    private void GenerateGrid2D(List<GameObject> money, Transform dollars, int rows, int cols, float hspacing, float vspacing, Transform coins, int crows, int ccols, float chspacing, float cvspacing)
    {
        int index = 0;
        // Places Dollars
        for (int c = 0; c < cols && money[index].GetComponent<DollarValue>().value >= 1 && index < money.Count; c++)
        {
            for (int r = 0; r < rows && money[index].GetComponent<DollarValue>().value >= 1 && index < money.Count; r++, index++)
            {
                money[index].transform.parent = null;
                money[index].transform.position = dollars.position + new Vector3(hspacing * r, vspacing * c, 0);
            }
        }
        // Places Coins
        for (int c = 0; index < money.Count && c < ccols; c++, index++)
        {
            for (int r = 0; index < money.Count && r < crows; r++, index++)
            {
                money[index].transform.parent = null;
                money[index].transform.position = coins.position + new Vector3(chspacing * r, cvspacing * c, 0);
            }  
        }  
    }

    private void InstantiateGrid2D(List<GameObject> money, Transform dollars, int rows, int cols, float hspacing, float vspacing, Transform coins, int crows, int ccols, float chspacing, float cvspacing)
    {
        int index = 0;
        // Places Dollars
        for (int c = 0; c < cols && money[index].GetComponent<DollarValue>().value >= 1 && index < money.Count; c++)
        {
            for (int r = 0; r < rows && money[index].GetComponent<DollarValue>().value >= 1 && index < money.Count; r++, index++)
            {
                Instantiate(money[index], dollars.position + new Vector3(hspacing * r, vspacing * c, 0), money[index].transform.rotation);
            }
        }
        // Places Coins
        for (int c = 0; index < money.Count && c < ccols; c++, index++)
        {
            for (int r = 0; index < money.Count && r < crows; r++, index++)
            {
                Instantiate(money[index], coins.position + new Vector3(chspacing * r, cvspacing * c, 0), money[index].transform.rotation);
            }  
        }  
    }

    public void Add(string group, DollarValue currency){

        List<GameObject> temp;
        if (group.Equals("Submission"))
            temp = submissionMoney;
        else
            temp = tipMoney;
        for (int i = 0; i < temp.Count; i++)
        {
            if (temp[i].GetComponent<DollarValue>().value >= currency.value)
            {
                temp.Insert(i, currency.gameObject);
                break;
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

    /*public void setPosition(){
        float index = 0;
        foreach(GameObject dollar in allMoney){
            dollar.transform.position  = new Vector3(dollar.transform.position.x + spaceBetweenDollars*index,
                dollar.transform.position.y, dollar.transform.position.z);
            index++;
        }
    }*/
}
