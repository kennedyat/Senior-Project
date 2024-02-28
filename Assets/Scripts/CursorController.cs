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
    private InputAction select;
    private InputAction selection;

    private void Awake()
    {
        playerControls = new PlayerInputActions();
        ChangeCursor(cursor);
        UnityEngine.Cursor.lockState = CursorLockMode.Confined;
    }

    private void OnEnable()
    {
        grab = playerControls.Cashier.Grab;
        selection = playerControls.Cashier.Selection;

        grab.Enable();
        selection.Enable();

        grab.started += Grab;
        grab.canceled += Drop;
        selection.started += Grab;
        selection.canceled += Drop;
    }


    private void OnDisable()
    {
        grab.Disable();
    }

    private void ChangeCursor(Texture2D cursorType)
    {
        Vector2 hotspot = new Vector2(cursorType.width / 2, cursorType.height / 2);
        UnityEngine.Cursor.SetCursor(cursorType, hotspot, CursorMode.Auto);
    }

    private void Grab(InputAction.CallbackContext context)
    {
        ChangeCursor(cursorClicked);
    }

    private void Drop(InputAction.CallbackContext context)
    {
        ChangeCursor(cursor);
    }

    void Update()
    {
        
    }
}
