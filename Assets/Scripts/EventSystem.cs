using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystem : MonoBehaviour
{

    // This is basically the player's score
    public float revenue;
    public static AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void addRevenue(float money)
    {
        revenue += money / 4;
        //scoreText.text = "Revenue: " + revenue.ToString();
    }

    public void addTip(int tip)
    {
        revenue += tip;
        //scoreText.text = "Revenue: " + revenue.ToString();
    }

}
