using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerInputActions playerControls;

    private InputAction grab;

    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }

    private void OnEnable()
    {
        grab = playerControls.Cashier.Grab;
        grab.Enable();

        grab.started += Grab;
        grab.canceled += Drop;
    }

    private void OnDisable()
    {
        grab.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Grab(InputAction.CallbackContext context)
    {
        Debug.Log("We grabbed");
    }

    private void Drop(InputAction.CallbackContext context)
    {
        Debug.Log("We dropped");
    }
}
