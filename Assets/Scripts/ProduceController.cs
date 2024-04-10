using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProduceController : MonoBehaviour
{
    Vector3 mousePos;
    public GameObject item;
    private GameObject currentItem;

    private Vector3 GetMousePos()
    {
        
        return Camera.main.WorldToScreenPoint(transform.position);
       
    }

      private void OnMouseDown()
    {
        mousePos = Input.mousePosition - GetMousePos();
        currentItem =Instantiate(item, this.transform.position, transform.rotation);
    }

    private void OnMouseDrag()
    {

        if (transform.parent == null)
            currentItem.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePos);
        else
            currentItem.transform.parent.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePos);
    }
}
