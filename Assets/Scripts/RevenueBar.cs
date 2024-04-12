using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RevenueBar : MonoBehaviour
{
    public EventManager _eventManager;
    public Image RevBar;
    public float maxRevenue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RevBar.fillAmount = _eventManager.revenue/maxRevenue;
    }
}
