using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CharacterScript : MonoBehaviour
{
    private float rotateSpeed = 0;
    private float maxSpeed = 500;
    private float yaxis=0;

    public int appleAmount;
    public TMP_Text itemOrderAmount;
    public TMP_Text itemOrderPrice;

    private EventManager eventManager;

    private bool spin = false;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        eventManager = GameObject.FindGameObjectWithTag("Event Manager").GetComponent<EventManager>();
        GenerateOrder();
    }

    // Update is called once per frame
    void Update()
    {
         float scalingFactor = 1; // Bigger for slower
        
        Quaternion target = Quaternion.Euler(0, yaxis, 0);
        if(spin){
            Debug.Log("hit target");
            yaxis+=720f;
           
        }
         transform.Rotate(0f, yaxis*Time.deltaTime, 0.0f);
        //transform.rotation = Quaternion.Slerp(transform.rotation,target, Time.deltaTime*5f);
       
    }
   void FixedUpdate(){
        yaxis*=.98f;
   }

   public void OnSubmissionEvent()
    {
        StartCoroutine(Spin());
    }

    private float GenerateOrder()
    {
        appleAmount = Random.Range(1,13);
        itemOrderAmount.text = appleAmount.ToString() + "X";
        itemOrderPrice.text = eventManager.applePrice.ToString("0.00");
        return appleAmount * eventManager.applePrice;
    }

   private IEnumerator Spin()
    {
        spin = true;
        yield return new WaitForSeconds(1f);
        spin = false;
    }

    
   
}
