using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selection_component : MonoBehaviour
{
    // This is where the outline texture will need to be added
    void Start()
    {
        GetComponent<Renderer>().material.color = Color.green;
        transform.parent = GameObject.FindGameObjectWithTag("Parent").transform;
        transform.parent.gameObject.GetComponent<GroupValue>().AddValue(gameObject.GetComponent<DollarValue>().value);
    }

    //This returns the texture when deselected
    private void OnDestroy()
    {
        GetComponent<Renderer>().material.color = Color.white;
        transform.parent.gameObject.GetComponent<GroupValue>().SubtractValue(gameObject.GetComponent<DollarValue>().value);
        transform.parent = null;
    }
}