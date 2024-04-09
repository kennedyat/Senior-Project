using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoxCorners : MonoBehaviour
{
    // The front northwest corner of the box collider
    public Vector3 fnw;
    // The back southeast corner of the box collider
    public Vector3 bse;
    void Awake()
    {
        BoxCollider b = gameObject.GetComponent<BoxCollider>();
        bse = transform.TransformPoint(b.center + new Vector3(-b.size.x, -b.size.y, -b.size.z) * 0.5f);
        fnw = transform.TransformPoint(b.center + new Vector3(b.size.x, b.size.y, b.size.z) * 0.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Money"))
            other.gameObject.GetComponent<Draggable>().boundary = gameObject.GetComponent<BoxCorners>();
    }
}
