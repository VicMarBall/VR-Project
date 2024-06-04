using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CerberusItemInteraction : MonoBehaviour
{
    public CerberusStats cerberus;

    GameObject focusedItem;

    public float itemGrabDistance;

    bool grabbingItem = false;

    public Transform grabSocket;

    float timeSinceLastBite = 0.0f;
    public float inBetweenBitesPeriodTime = 1.0f;

    float timeSinceLastPlay = 0.0f;
    public float inBetweenPlayPeriodTime = 1.0f;

    float timePlaying = 0.0f;
    public float totalPlayingTime = 10.0f;

    float playingCooldownTimer = 0.0f;
    public float playingCooldown = 30.0f;

    [SerializeField]
    float speed = 1;

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
        if (playingCooldownTimer < playingCooldown)
        {
            playingCooldownTimer += Time.deltaTime;
        }

        if (grabbingItem)
        {
            focusedItem.transform.SetPositionAndRotation(grabSocket.gameObject.transform.position, grabSocket.gameObject.transform.rotation);
        }
    }

    public void CerberusSeekingUpdate()
    {
        if (focusedItem != null)
        {
            Vector3 lookAtVector = new Vector3(focusedItem.transform.position.x, transform.position.y, focusedItem.transform.position.z);
            transform.LookAt(lookAtVector, Vector3.up);

            transform.Translate(Vector3.forward * Time.deltaTime * speed);

            if (CanGrab())
            {
                GrabFocusedItem();
            }
        }
    }

    void EatEvent() { }
    void FinalEatEvent() { }

    public void CerberusEatingUpdate()
    {
        if (IsGrabbing())
        {
            timeSinceLastBite += Time.deltaTime;
        }

        if (timeSinceLastBite >= inBetweenBitesPeriodTime)
        {
            if (focusedItem.GetComponent<FoodObject>() != null)
            {
                focusedItem.GetComponent<FoodObject>().TakeBite();
                EatEvent();
                if (focusedItem.GetComponent<FoodObject>().IsEaten())
                {
                    FinalEatEvent();
                    cerberus.satiation += 20;
                    cerberus.energy -= 5;
                    cerberus.friendship += 10;
                    cerberus.timesHasEaten += 1;
                    ReleaseFocusedItem();
                    focusedItem.SetActive(false);
                    focusedItem = null;
                }
            }
            timeSinceLastBite = 0;
        }

    }

    void PlayEvent() { }
    void FinalPlayEvent() { }


    public void CerberusPlayingUpdate()
    {
        if (IsGrabbing())
        {
            timeSinceLastPlay += Time.deltaTime;
            timePlaying += Time.deltaTime;
        }

        if (timeSinceLastPlay >= inBetweenPlayPeriodTime)
        {
            PlayEvent();
            cerberus.fun += 5;
            timeSinceLastPlay = 0;
            cerberus.energy -= 1;
        }

        if (timePlaying >= totalPlayingTime)
        {
            FinalPlayEvent();
            ReleaseFocusedItem();
            cerberus.fun += 20;
            cerberus.energy -= 5;
            cerberus.friendship += 10;
            timePlaying = 0;
            playingCooldownTimer = 0;
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

        if (focusedItem.gameObject.CompareTag("Toy") && playingCooldownTimer < playingCooldown) { return false; }

        return true;
    }

    public void GrabFocusedItem()
    {
        grabbingItem = true;
        focusedItem.GetComponent<Rigidbody>().useGravity = false;
    }

    public void ReleaseFocusedItem()
    {
        grabbingItem = false;
        focusedItem.GetComponent<Rigidbody>().useGravity = true;
    }

    public bool IsGrabbing() {  return grabbingItem; }

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
