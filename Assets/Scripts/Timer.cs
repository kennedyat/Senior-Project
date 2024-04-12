using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{
    public GameObject target;
    public EventManager _eventManager;
    float degreePerSecond;
    public float nearEndTime;
    public GameObject safeTimer;
    public GameObject dangerTimer;
    // Start is called before the first frame update
    

    void Start()
    {
       degreePerSecond = transform.eulerAngles.z/_eventManager.playTime*1.31f; 
    }

    // Update is called once per frame
    void Update()
    {
        if(_eventManager.playTime<nearEndTime){
            safeTimer.SetActive(false);
            dangerTimer.SetActive(true);
            AudioManager.Instance.PlaySFX("Timer");
        } else {
            safeTimer.SetActive(true);
            dangerTimer.SetActive(false);
        }
         transform.RotateAround(target.transform.position, Vector3.forward, degreePerSecond * Time.deltaTime);

         if(_eventManager.playTime<=0){
              SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
         }
    }
}
