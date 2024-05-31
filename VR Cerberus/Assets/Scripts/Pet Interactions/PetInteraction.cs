using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetInteraction : MonoBehaviour
{
    public Collider[] interactorColliders;

    List<Collider> handsPetting = new List<Collider>();

    float timeSinceLastPetEvent = 0;

    public float inBetweenPetEventPeriodTime = 1.0f;

    public ParticleSystem eventParticleSystem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Pet Update");

        if (handsPetting.Count > 0)
        {
            timeSinceLastPetEvent += Time.deltaTime;
        }

        if (timeSinceLastPetEvent >= inBetweenPetEventPeriodTime)
        {
            PetEvent();
            timeSinceLastPetEvent = 0;
        }
    }

    public void PetEvent()
    {
        // reaction
        Debug.Log("PetEventActivated");
        eventParticleSystem.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ENTER");

        foreach (Collider handCollider in interactorColliders)
        {
            Debug.Log("ENTER: foreach (Collider collider in interactorColliders)");

            if (other == handCollider)
            {
                Debug.Log("ENTER: other == collider");

                if (handsPetting.Count == 0)
                {
                    timeSinceLastPetEvent = 0;
                }
                handsPetting.Add(other);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("EXIT");

        foreach (Collider collider in interactorColliders)
        {
            Debug.Log("EXIT: foreach (Collider collider in interactorColliders)");

            if (other == collider)
            {
                Debug.Log("EXIT: other == collider");

                handsPetting.Remove(other);
                if (handsPetting.Count == 0)
                {
                    timeSinceLastPetEvent = 0;
                }
            }
        }
    }

}
