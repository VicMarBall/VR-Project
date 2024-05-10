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

    public List<GameObject> toys;

    bool isCarryingToy;
    GameObject carriedToy;

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
        if (isCarryingToy)
        {
            return;
        }
    }
}
