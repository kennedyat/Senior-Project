using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Draggable : MonoBehaviour
{

    Vector3 mousePos;
    // This variable decides how much the dollar will be zoomed in
    private float zoomVal = 1.2f;
    // This variable shows whether the object will be zoomed in on when hovered over
    private bool zoom = false;
    public BoxCorners boundary;
    public bool editView = false;

    private void Update()
    {
        if (!editView && boundary != null)
        {
            transform.position = new Vector3 (
                Mathf.Clamp(transform.position.x, boundary.bse.x, boundary.fnw.x),
                Mathf.Clamp(transform.position.y, boundary.bse.y, boundary.fnw.y),
                Mathf.Clamp(transform.position.z, boundary.bse.z, boundary.fnw.z));
        }
    }

    private Vector3 GetMousePos()
    {
        if (transform.parent == null)
            return Camera.main.WorldToScreenPoint(transform.position);
        else
        {
            foreach (Transform child in transform.parent.transform)
                child.gameObject.GetComponent<Rigidbody>().useGravity = false;
            return Camera.main.WorldToScreenPoint(transform.parent.position);
        }
    }

    private void OnMouseDown()
    {
        mousePos = Input.mousePosition - GetMousePos();
    }

    private void OnMouseDrag()
    {

        if (transform.parent == null)
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePos);
        else
            transform.parent.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePos);
    }

    private void OnMouseEnter()
    {
        if (zoom)
        {
            transform.localScale *= zoomVal;
        }
    }

    private void OnMouseExit()
    {
        if (zoom)
        {
            transform.localScale /= zoomVal;
        }
    }

    private void OnMouseUp()
    {
        if (transform.parent)
        {
            foreach (Transform child in transform.parent.transform)
                child.gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
