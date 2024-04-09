using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmissionTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Money"))
            other.gameObject.GetComponentInParent<GroupValue>().submittable = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Money"))
            other.gameObject.GetComponentInParent<GroupValue>().submittable = false;
    }
}
