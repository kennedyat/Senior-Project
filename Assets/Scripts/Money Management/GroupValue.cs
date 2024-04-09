using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupValue : MonoBehaviour
{
    
    public PlayerInputActions playerControls;
    [SerializeField] float value = 0;
    public bool submittable = false;

    void Awake()
    {
        playerControls = new PlayerInputActions();
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
