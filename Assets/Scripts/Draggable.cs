using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{

    Vector3 mousePos;
    // This variable decides how much the dollar will be zoomed in
    private float zoomVal = 1.2f;
    // This variable shows whether the object will be zoomed in on when hovered over
    private bool zoom = false;

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
}
