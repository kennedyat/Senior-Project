using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{

    // This is basically the player's score
    public float revenue;
    public float playTime = 60f;
    public static AudioSource audioSource;
    public string cameraView = "Submission";

    [Header("Events")]
    public GameEvent gameOver;

    [Header("Sound Effects")]
    public static AudioClip gameOverSound;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        //gameOverSound = Sounds.Load<AudioClip>("Game Over");
    }

    void Update()
    {
        playTime -= Time.deltaTime;
        if (playTime <= 0)
        {
            gameOver.Raise(this, "Timeout");
        }
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

    public void onSubmissionEvent(Component sender, object data)
    {
        if (data is float)
        {
            float money = (float)data;
            if (money < 0)
            {
                gameOver.Raise(this, "Incorrect Answer");
                return;
            }
            addRevenue(money);
        }

        Destroy(sender.transform.parent.gameObject);
    }

    public void onSubmissionViewEvent(Component sender, object data){
        if (data is string)
        {
            cameraView = (string)data;
        }
    }

    public void onEditViewEvent(Component sender, object data){
        if (data is String)
        {
            cameraView = (string)data;
        }
    }

}
