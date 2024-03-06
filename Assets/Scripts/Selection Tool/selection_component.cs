using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selection_component : MonoBehaviour
{
    // This is where the outline texture will need to be added
    void Start()
    {
        GetComponent<Renderer>().material.color = Color.red;
        gameObject.transform.parent = GameObject.FindGameObjectWithTag("Parent").transform;
    }

    //This returns the texture when deselected
    private void OnDestroy()
    {
        GetComponent<Renderer>().material.color = Color.white;
        gameObject.transform.parent = null;
    }
}