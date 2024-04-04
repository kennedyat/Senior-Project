using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupValue : MonoBehaviour
{
    
    public PlayerInputActions playerControls;
    [SerializeField] private float value;
    public bool submittable = false;

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
