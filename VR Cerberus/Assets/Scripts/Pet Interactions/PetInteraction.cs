using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetInteraction : MonoBehaviour
{
    public Collider[] interactorColliders;

    List<Collider> handsPetting;

    float timeSinceLastPetEvent = 0;

    public float inBetweenPetEventPeriodTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach (Collider collider in interactorColliders)
        {
            if (collision.collider == collider)
            {
                if (handsPetting.Count == 0)
                {
                    timeSinceLastPetEvent = 0;
                }
                handsPetting.Add(collider);
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        foreach (Collider collider in interactorColliders)
        {
            if (collision.collider == collider)
            {
                handsPetting.Remove(collider);
                if (handsPetting.Count == 0)
                {
                    timeSinceLastPetEvent = 0;
                }
            }
        }
    }

}
