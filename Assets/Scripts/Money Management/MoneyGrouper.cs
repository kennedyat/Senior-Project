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

    // This dictionary returns a spawn point depenting on the currency value 
    private Dictionary<float, Transform> spawnPoints = new Dictionary<float, Transform>();

    public GameObject grouper;
    private GroupValue groupValue;
    private float tempValue;

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
}
