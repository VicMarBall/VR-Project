using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerberusItemInteraction : MonoBehaviour
{
    GameObject focusedToy;

    public float toyGrabRadius;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CerberusUpdateSeekingAction()
    {
        if (focusedToy != null)
        {
            transform.LookAt(focusedToy.transform);
        }
    }

    public void CerberusUpdateFollowingAction()
    {
        if (focusedToy != null)
        {
            transform.LookAt(focusedToy.transform);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("OnCollisionStay");
        if (other.gameObject.CompareTag("Toy") || other.gameObject.CompareTag("Food"))
        {
            Debug.Log("OnCollisionStay is Toy");
            if (focusedToy == null)
            {
                focusedToy = other.gameObject;
            }
            else if (Vector3.Distance(other.gameObject.transform.position, transform.position) < Vector3.Distance(focusedToy.gameObject.transform.position, transform.position))
            {
                focusedToy = other.gameObject;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == focusedToy)
        {
            focusedToy = null;
        }
    }
}
