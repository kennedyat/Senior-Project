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
    public float solution;
    private bool ready2order = true;

    private GameObject eventManager;

    private bool spin = false;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        eventManager = GameObject.FindGameObjectWithTag("Event Manager");
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

        if(Input.GetMouseButtonDown(0)){
            if (ready2order)
            {
                solution = GenerateSolution();
                ready2order = false;
            }
        }
       
    }
   void FixedUpdate(){
        yaxis*=.98f;
   }
   public void OnSubmissionEvent()
    {
        StartCoroutine(Spin());
        ready2order = true;
    }

    private float GenerateOrder()
    {
        appleAmount = Random.Range(1,13);
        itemOrderAmount.text = appleAmount.ToString() + "X";
        itemOrderPrice.text = eventManager.GetComponent<EventManager>().applePrice.ToString("0.00");
        return appleAmount * eventManager.GetComponent<EventManager>().applePrice;
    }

    private float GenerateSolution()
    {
        float change = GenerateOrder();
        Debug.Log(change);
        change = eventManager.GetComponent<MoneyGrouper>().GeneratePayment(change) - change;
        return change;
    }

   private IEnumerator Spin()
    {
        spin = true;
        yield return new WaitForSeconds(1f);
        spin = false;
    }

    
   
}
