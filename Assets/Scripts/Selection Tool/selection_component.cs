using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selection_component : MonoBehaviour
{
    // This is where the outline texture will need to be added
    void Start()
    {
        GetComponent<Renderer>().material.color = Color.green;
        gameObject.transform.parent = GameObject.FindGameObjectWithTag("Parent").transform;
        gameObject.transform.parent.gameObject.GetComponent<GroupValue>().AddValue(gameObject.GetComponent<DollarValue>().value);
    }

    //This returns the texture when deselected
    private void OnDestroy()
    {
        GetComponent<Renderer>().material.color = Color.white;
        gameObject.transform.parent.gameObject.GetComponent<GroupValue>().SubtractValue(gameObject.GetComponent<DollarValue>().value);
        gameObject.transform.parent = null;
    }
}