using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GroupValue : MonoBehaviour
{
    
    public PlayerInputActions playerControls;
    private InputAction select;
    [SerializeField] private int value;
    void Awake()
    {
        playerControls = new PlayerInputActions();
        value = 0;
    }

    public void AddValue(int value)
    {
        this.value += value;
    }

    public void SubtractValue(int value)
    {
        this.value -= value;
    }
}
