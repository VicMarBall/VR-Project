using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogoBehavior : MonoBehaviour
{
    enum DogoState
    {
        LOOKING_AT_PLAYER,
        LOOKING_AT_TOY,
        SLEEPING
    }

    public GameObject objectLookingAt;

    public List<GameObject> toys;

    bool isCarryingToy;
    GameObject carriedToy;

    public ParticleSystem happyParticles;
    void GrabToy(GameObject toy)
    {
        carriedToy = toy;
        isCarryingToy = true;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }




    // Update is called once per frame
    void Update()
    {
        // change to coroutines
        if (objectLookingAt != null)
        {
            transform.LookAt(objectLookingAt.transform);
        }
        if (Vector3.Distance(transform.position, objectLookingAt.transform.position) < 5)
        {
            GetComponent<Animator>().SetBool("HappyDogo", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("HappyDogo", false);
        }
    }

    void PlayHappyParticles()
    {
        happyParticles.Play();
    }
}
