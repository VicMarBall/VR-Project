using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CerberusItemInteraction : MonoBehaviour
{
    public CerberusActionManager actionManager;

    GameObject focusedItem;

    public float itemGrabDistance;

    bool grabbingItem = false;

    public Transform grabSocket;
    // Start is called before the first frame update
    void Start()
    {
        if (grabSocket == null) 
        { 
            grabSocket.localPosition = Vector3.zero;
            grabSocket.rotation = Quaternion.identity;
            grabSocket.localScale = Vector3.zero;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (grabbingItem)
        {
            focusedItem.transform.SetPositionAndRotation(grabSocket.gameObject.transform.position, grabSocket.gameObject.transform.rotation);
        }
    }

    public void CerberusUpdateSeekingAction()
    {
        if (focusedItem != null)
        {
            transform.LookAt(focusedItem.transform);
        }
    }

    public void CerberusUpdateFollowingAction()
    {
        if (focusedItem != null)
        {
            transform.LookAt(focusedItem.transform);
        }
    }

    public bool IsFocused() {  return focusedItem != null; }
    public bool FocusedItemIsToy() { return focusedItem.CompareTag("Toy"); }
    public bool FocusedItemIsFood() { return focusedItem.CompareTag("Food"); }
    public bool CanGrab()
    {
        if (!IsFocused()) return false;

        if (itemGrabDistance < Vector3.Distance(focusedItem.gameObject.transform.position, gameObject.transform.position)) { return false; }

        if (grabbingItem) { return false; }

        return true;
    }

    public void GrabFocusedItem()
    {
        grabbingItem = true;
    }

    public void ReleaseFocusedItem()
    {
        grabbingItem = false;
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("OnCollisionStay");
        if (other.gameObject.CompareTag("Toy") || other.gameObject.CompareTag("Food"))
        {
            Debug.Log("OnCollisionStay is Toy");
            if (focusedItem == null)
            {
                focusedItem = other.gameObject;
            }
            else if (Vector3.Distance(other.gameObject.transform.position, transform.position) < Vector3.Distance(focusedItem.gameObject.transform.position, transform.position))
            {
                focusedItem = other.gameObject;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == focusedItem)
        {
            focusedItem = null;
        }
    }
}
