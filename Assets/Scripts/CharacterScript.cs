using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterScript : MonoBehaviour
{

    public PlayerInputActions playerControls;

    private InputAction order;

    private float rotateSpeed = 0;
    private float maxSpeed = 500;
    private float yaxis=0;

    public int appleAmount;
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

    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }

    private void OnEnable()
    {
        order = playerControls.Cashier.Grab;

        order.Enable();

        order.performed += StartOrder;
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

   void StartOrder(InputAction.CallbackContext context)
   {
        if (ready2order)
        {
            solution = GenerateSolution();
            ready2order = false;
        }
   }

   public void OnSubmissionEvent()
    {
        StartCoroutine(Spin());
        ready2order = true;
    }

    private float GenerateOrder()
    {
        appleAmount = Random.Range(1,13);
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
