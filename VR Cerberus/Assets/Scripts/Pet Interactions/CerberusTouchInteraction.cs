using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerberusTouchInteraction : MonoBehaviour
{
    public CerberusStats cerberus;

    public Collider[] interactorColliders;

    List<Collider> handsTouching = new List<Collider>();

    List<CleaningObject> cleaningObjects = new List<CleaningObject>();

    enum TouchAction
    {
        PET,
        CLEAN,
        NO_TOUCH_ACTION
    }

    TouchAction action;

    float timeSinceLastPetEvent = 0.0f;
    public float inBetweenPetEventPeriodTime = 1.0f;
    public ParticleSystem eventParticleSystem;

    float timeSinceLastCleanEvent = 0.0f;
    public float inBetweenCleanEventPeriodTime = 1.0f;

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Touch Update");

        //switch (action)
        //{
        //    case TouchAction.CLEAN:
        //        CleaningUpdate();
        //        break;
        //    case TouchAction.PET:
        //        PetUpdate();
        //        break;
        //    default:
        //        break;
        //}

    }

    void CleaningUpdate()
    {
        if (GettingTouched())
        {
            timeSinceLastCleanEvent += Time.deltaTime;
        }

        if (timeSinceLastCleanEvent >= inBetweenCleanEventPeriodTime)
        {
            foreach (CleaningObject cleaningObject in cleaningObjects)
            {
                cleaningObject.CleaningEvent();
                cerberus.hygiene += 5;
            }
            timeSinceLastCleanEvent = 0;
        }
    }

    void PetUpdate()
    {
        if (GettingTouched())
        {
            timeSinceLastPetEvent += Time.deltaTime;
        }

        if (timeSinceLastPetEvent >= inBetweenPetEventPeriodTime)
        {
            PetEvent();
            timeSinceLastPetEvent = 0;
        }
    }

    public void CerberusUpdate()
    {
        Debug.Log("Touch Update");

        switch (action)
        {
            case TouchAction.CLEAN:
                CleaningUpdate();
                break;
            case TouchAction.PET:
                PetUpdate();
                break;
            default:
                break;
        }
    }

    public void PetEvent()
    {
        // reaction
        cerberus.affection += 5;
        Debug.Log("PetEventActivated");
        eventParticleSystem.Play();
    }

    public bool GettingTouched()
    {
        return handsTouching.Count > 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ENTER");
        if (other.gameObject.GetComponent<CleaningObject>() != null)
        {
            action = TouchAction.CLEAN;
            cleaningObjects.Add(other.gameObject.GetComponent<CleaningObject>());
            return;
        }

        foreach (Collider handCollider in interactorColliders)
        {
            Debug.Log("ENTER: foreach (Collider collider in interactorColliders)");

            if (other == handCollider)
            {
                Debug.Log("ENTER: other == collider");

                if (handsTouching.Count == 0)
                {
                    timeSinceLastPetEvent = 0;
                }
                handsTouching.Add(other);

                if (cleaningObjects.Count == 0)
                {
                    action = TouchAction.PET;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("EXIT");

        if (other.gameObject.GetComponent<CleaningObject>() != null)
        {
            cleaningObjects.Remove(other.gameObject.GetComponent<CleaningObject>());
            if (cleaningObjects.Count == 0 && GettingTouched())
            {
                action = TouchAction.PET;
            }
            return;
        }

        foreach (Collider collider in interactorColliders)
        {
            Debug.Log("EXIT: foreach (Collider collider in interactorColliders)");

            if (other == collider)
            {
                Debug.Log("EXIT: other == collider");

                handsTouching.Remove(other);
                if (handsTouching.Count == 0)
                {
                    timeSinceLastPetEvent = 0;
                    timeSinceLastCleanEvent = 0;
                    action = TouchAction.NO_TOUCH_ACTION;
                }
            }
        }
    }

}
