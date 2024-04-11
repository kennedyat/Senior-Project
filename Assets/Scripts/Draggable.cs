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
    // The variable below shows the height that objects in edit view will be set to when grabbed
    private bool listed = false; // If it has been added to the allMoney list
    public float grabHeight = 0.57f;
    public BoxCorners boundary;
    private EventManager eventManager;
    [Header("Events")]
    public GameEvent submitEvent;

    private void Awake()
    {
        eventManager = GameObject.FindGameObjectWithTag("Event Manager").GetComponent<EventManager>();
    }

    private void Update()
    {
        if (eventManager.cameraView.Equals("Submission") && boundary)
        {
            transform.position = new Vector3 (
                Mathf.Clamp(transform.position.x, boundary.bse.x, boundary.fnw.x),
                Mathf.Clamp(transform.position.y, boundary.bse.y + 0.01f, boundary.fnw.y - 0.01f),
                transform.position.z);
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
        if (eventManager.cameraView.Equals("Edit"))
        {
            if (!boundary)
            {
                Instantiate(gameObject, transform.position, transform.rotation, transform.parent);
                transform.parent = null;
            }
            transform.position = new Vector3(transform.position.x, grabHeight, transform.position.z);
        }
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
        if (boundary == null)
            Destroy(gameObject);
        else if (!listed)
        {
            eventManager.GetComponent<MoneyGrouper>().Add(gameObject.GetComponent<DollarValue>());
            listed = true;
        }
        if (transform.parent)
        {
            if (gameObject.GetComponentInParent<GroupValue>().submittable)
                submitEvent.Raise(this, gameObject.GetComponentInParent<GroupValue>().GetValue());
            foreach (Transform child in transform.parent.transform)
                child.gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    private void OnDestroy()
    {
        if (listed)
            eventManager.GetComponent<MoneyGrouper>().allMoney.Remove(gameObject);
    }
}
