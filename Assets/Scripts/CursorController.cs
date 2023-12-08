using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class CursorController : MonoBehaviour
{
    public PlayerInputActions playerControls;


    public Texture2D cursor;
    public Texture2D cursorClicked;


    private InputAction grab;
    private bool grabbing = false;
    private InputAction point;
    public Transform selection = null;
    public Vector2 previousMousePos = Vector2.zero;

    private void Awake()
    {
        playerControls = new PlayerInputActions();
        ChangeCursor(cursor);
        UnityEngine.Cursor.lockState = CursorLockMode.Confined;
    }

    private void OnEnable()
    {
        grab = playerControls.Cashier.Grab;
        grab.Enable();

        point = playerControls.Cashier.Point;
        point.Enable();

        grab.started += Grab;
        grab.canceled += Drop;
    }


    private void OnDisable()
    {
        grab.Disable();
        point.Disable();
    }

    private void ChangeCursor(Texture2D cursorType)
    {
        Vector2 hotspot = new Vector2(cursorType.width / 2, cursorType.height / 2);
        UnityEngine.Cursor.SetCursor(cursorType, hotspot, CursorMode.Auto);
    }

    private void Grab(InputAction.CallbackContext context)
    {
        ChangeCursor(cursorClicked);
        grabbing = true;
        var ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            selection = hit.transform;
        }
        else
        {
            selection = null;
        }
    }

    private void Drop(InputAction.CallbackContext context)
    {
        ChangeCursor(cursor);
        grabbing = false;
        previousMousePos = Vector2.zero;
    }

    private void DragObject(Transform transform, Vector3 translation)
    {
        transform.position += translation;
    }

    void Update()
    {
        if (grabbing)
        {
            Vector3 translation = (Mouse.current.position.ReadValue() - previousMousePos) * Time.deltaTime;
            DragObject(selection, translation);
        }
        previousMousePos = Mouse.current.position.ReadValue();
    }
}
