using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RevenueBar : MonoBehaviour
{
    public EventManager _eventManager;
    public Image RevBar;
    public float maxRevenue;
    
    public TMP_Text revenue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        revenue.text = "$" + _eventManager.revenue.ToString();
        RevBar.fillAmount = _eventManager.revenue/maxRevenue;
        
    }
}
