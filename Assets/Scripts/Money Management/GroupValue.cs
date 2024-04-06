using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupValue : MonoBehaviour
{
    
    public PlayerInputActions playerControls;
    [SerializeField] float value;
    public bool submittable = false;

    void Awake()
    {
        playerControls = new PlayerInputActions();
        value = 0;
    }

    public void AddValue(float value)
    {
        this.value += value;
    }

    public void SubtractValue(float value)
    {
        this.value -= value;
    }

    public float GetValue()
    {
        return value;
    }
}
