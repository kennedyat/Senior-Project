using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{

    Vector3 mousePos;
    // This variable decides how much the dollar will be zoomed in
    private float zoomVal = 1.2f;
    public float value;
    // This variable shows whether the money is in the docked view where it can be grouped
    private bool docked = true;

    private Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        mousePos = Input.mousePosition - GetMousePos();
    }

    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePos);
    }

    private void OnMouseEnter()
    {
        if (docked)
        {
            transform.localScale *= zoomVal;
        }
    }

    private void OnMouseExit()
    {
        if (docked)
        {
            transform.localScale /= zoomVal;
        }
    }
}
