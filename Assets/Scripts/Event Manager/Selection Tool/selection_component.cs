using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selection_component : MonoBehaviour
{
    [SerializeField]
    private Material outliner;

    void Start()
    {
        GetComponent<Renderer>().material = outliner;
        transform.parent = GameObject.FindGameObjectWithTag("Parent").transform;
        transform.parent.gameObject.GetComponent<GroupValue>().AddValue(gameObject.GetComponent<DollarValue>().value);
    }

    //This returns the texture when deselected
    private void OnDestroy()
    {
        GetComponent<Renderer>().material = null;
        transform.parent.gameObject.GetComponent<GroupValue>().SubtractValue(gameObject.GetComponent<DollarValue>().value);
        transform.parent = null;
    }
}