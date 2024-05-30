using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetInteraction : MonoBehaviour
{
    public Collider[] interactorColliders;

    bool isGettingPet;

    float timeSinceLastPetEvent = 0;

    public float inBetweenPetEventPeriodTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGettingPet)
        {
            timeSinceLastPetEvent += Time.deltaTime;
        }

        if (timeSinceLastPetEvent >= inBetweenPetEventPeriodTime)
        {
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
                if (!isGettingPet)
                {
                    timeSinceLastPetEvent = 0;
                }
                isGettingPet = true;
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        foreach (Collider collider in interactorColliders)
        {
            if (collision.collider == collider)
            {
                isGettingPet = false;
                timeSinceLastPetEvent = 0;
            }
        }
    }

}
