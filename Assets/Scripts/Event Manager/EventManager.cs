using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{

    // This is basically the player's score
    public float revenue;
    public static AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void addRevenue(float money)
    {
        revenue += Mathf.Round(money / 4 * 100) / 100.0f;
        //scoreText.text = "Revenue: " + revenue.ToString();
    }

    private void addTip(int tip)
    {
        revenue += tip;
        //scoreText.text = "Revenue: " + revenue.ToString();
    }

    public void OnSubmissionEvent(Component sender, object data)
    {
        if (data is float)
        {
            float money = (float)data;
            addRevenue(money);
        }

        Destroy(sender.transform.parent.gameObject);

        GameObject.FindGameObjectWithTag("Character").GetComponent<CharacterScript>().OnSubmissionEvent();
    }

}
