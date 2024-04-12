using System;
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
    private float moneyGiven = 0;

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
    public Transform moneySpawn;
    #region Grid
    private static float hspacing = 0.3f; // Dollar horizontal spacing
    private static float vspacing = -0.63f; // Dollar vertical spacing
    private static float cspacing = 0.158f; // Coin spacing

    #endregion

    // This dictionary returns a spawn point depenting on the currency value 
    private Dictionary<float, Transform> submissionSpawn = new Dictionary<float, Transform>();
    private Dictionary<float, Transform> tipSpawn = new Dictionary<float, Transform>();

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

        submissionSpawn[1f] = moneySpawn.GetChild(0).GetChild(2);
        submissionSpawn[0.25f] = moneySpawn.GetChild(0).GetChild(3);
        submissionSpawn[0.1f] = moneySpawn.GetChild(0).GetChild(4);
        submissionSpawn[0.05f] = moneySpawn.GetChild(0).GetChild(5);
        submissionSpawn[0.01f] = moneySpawn.GetChild(0).GetChild(6);

        tipSpawn[1f] = moneySpawn.GetChild(1).GetChild(2);
        tipSpawn[0.25f] = moneySpawn.GetChild(1).GetChild(3);
        tipSpawn[0.1f] = moneySpawn.GetChild(1).GetChild(4);
        tipSpawn[0.05f] = moneySpawn.GetChild(1).GetChild(5);
        tipSpawn[0.01f] = moneySpawn.GetChild(1).GetChild(6);
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
        StartCoroutine(SubmissionTips(submissionGrouper.transform, submissionSpawn[1], submissionSpawn));
        StartCoroutine(GroupTips(tipGrouper.transform, tipSpawn[1], tipSpawn));
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

    public float GeneratePayment(float orderValue)
    {
        int temp;
        moneyGiven = 0;
        DollarValue dollarValue;
        while(moneyGiven < orderValue)
        {
            temp = UnityEngine.Random.Range(0,4);
            if (orderValue - moneyGiven > 20 && temp != 3)
                temp++;
            dollarValue = dollars[temp].GetComponent<DollarValue>();
            Add("Submission", dollarValue);
            moneyGiven += dollarValue.value;
        }
        InstantiateGrid2D(submissionMoney, moneySpawn.GetChild(0).GetChild(0), 2, 6, hspacing, vspacing, moneySpawn.GetChild(0).GetChild(1), 2, 10, cspacing);
        submissionMoney.Clear();
        return moneyGiven;
        
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
    private void GenerateGrid2D(List<GameObject> money, Transform dollars, int rows, int cols, float hspacing, float vspacing, Transform coins, int crows, int ccols, float cspacing)
    {
        int index = 0;
        // Places Dollars
        for (int r = 0; index < money.Count && r < rows && money[index].GetComponent<DollarValue>().value >= 1; r++)
        {
            for (int c = 0; index < money.Count && c < cols && money[index].GetComponent<DollarValue>().value >= 1; c++, index++)
            {
                money[index].transform.parent = null;
                money[index].transform.position = dollars.position - new Vector3(hspacing * c, 0, vspacing * r);
            }
        }
        // Places Coins
        for (int r = 0; index < money.Count && r < ccols; r++, index++)
        {
            for (int c = 0; index < money.Count && c < crows; c++, index++)
            {
                money[index].transform.parent = null;
                money[index].transform.position = coins.position - new Vector3(cspacing * c, 0, cspacing * r * -1);
            }  
        }  
    }

    private void InstantiateGrid2D(List<GameObject> money, Transform dollars, int rows, int cols, float hspacing, float vspacing, Transform coins, int crows, int ccols, float cspacing)
    {
        int index = 0;
        // Places Dollars
        for (int r = 0; index < money.Count && r < rows && money[index].GetComponent<DollarValue>().value >= 1; r++)
        {
            for (int c = 0; index < money.Count && c < cols && money[index].GetComponent<DollarValue>().value >= 1; c++, index++)
            {
                Debug.Log(dollars.position + new Vector3(hspacing * c, 0, vspacing * r));
                Instantiate(money[index], dollars.position - new Vector3(hspacing * c, 0, vspacing * r), money[index].transform.rotation);
            }
        }
        // Places Coins
        for (int r = 0; index < money.Count && r < ccols; r++, index++)
        {
            for (int c = 0; index < money.Count && c < crows; c++, index++)
            {
                Instantiate(money[index], coins.position - new Vector3(cspacing * c, 0, cspacing * r * -1), money[index].transform.rotation);
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
                return;
            }
        }

        temp.Add(currency.gameObject);
        
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

    public void Remove(string group, DollarValue currency){

        List<GameObject> temp;
        if (group.Equals("Submission"))
            temp = submissionMoney;
        else
            temp = tipMoney;

        temp.Remove(currency.gameObject);
    }

    private IEnumerator GroupTips(Transform grouper, Transform dollars, Dictionary<float, Transform> spawns)
    {
        foreach (GameObject currency in tipMoney)
        {
            if (currency.GetComponent<DollarValue>().value >= 1)
                currency.transform.position = dollars.position;
            else
            {
                currency.transform.position = spawns[currency.GetComponent<DollarValue>().value].position;
            }
            currency.transform.parent = grouper;
            grouper.GetComponent<GroupValue>().AddValue(currency.GetComponent<DollarValue>().value);
        }
        yield return new WaitForSeconds(0.5f);
    }

    private IEnumerator SubmissionTips(Transform grouper, Transform dollars, Dictionary<float, Transform> spawns)
    {
        //gameObject.GetComponent<global_selection>().playerControls.Disable();
        foreach (GameObject currency in submissionMoney)
        {
            if (currency.GetComponent<DollarValue>().value >= 1)
                currency.transform.position = dollars.position;
            else
            {
                currency.transform.position = spawns[currency.GetComponent<DollarValue>().value].position;
            }
            currency.transform.parent = grouper;
            grouper.GetComponent<GroupValue>().AddValue(currency.GetComponent<DollarValue>().value);
        }
        yield return new WaitForSeconds(0.5f);
        //gameObject.GetComponent<global_selection>().playerControls.Enable();
    }

    /*public void SubmissionSort()
    {
        GenerateGrid2D(submissionMoney,)
    }

    public void tipSort()
    {

    }*/

    /*public void setPosition(){
        float index = 0;
        foreach(GameObject dollar in allMoney){
            dollar.transform.position  = new Vector3(dollar.transform.position.x + spaceBetweenDollars*index,
                dollar.transform.position.y, dollar.transform.position.z);
            index++;
        }
    }*/
}
