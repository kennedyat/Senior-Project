using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public GameObject target;
    public EventManager _eventManager;
    float degreePerSecond;
    // Start is called before the first frame update
    

    void Start()
    {
       degreePerSecond = transform.eulerAngles.z/_eventManager.playTime*1.3f; 
    }

    // Update is called once per frame
    void Update()
    {
         transform.RotateAround(target.transform.position, Vector3.forward, degreePerSecond * Time.deltaTime);
    }
}
