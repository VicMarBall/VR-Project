using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerberusActionManager : MonoBehaviour
{
    public enum CerberusAction
    {
        IDLE, 

        SEEKING_ITEM, // look at
        FOLLOWING_ITEM, // moving + look at

        EATING,
        PLAYING_WITH_BALL,

        GETTING_PET,
        GETTING_CLEANED,

        SLEEPING
    }

    public CerberusAction currentAction;

    CerberusItemInteraction itemInteraction;

    // Start is called before the first frame update
    void Start()
    {
        itemInteraction = gameObject.GetComponent<CerberusItemInteraction>();
        if (itemInteraction == null) { Debug.Log("CerberusItemInteraction not found");  }
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentAction)
        {
            case CerberusAction.IDLE: 
                break;

            case CerberusAction.SEEKING_ITEM:
                itemInteraction.CerberusUpdateSeekingAction();
                break;

            case CerberusAction.FOLLOWING_ITEM:
                itemInteraction.CerberusUpdateFollowingAction();
                break;

            case CerberusAction.EATING:
                break;

            case CerberusAction.PLAYING_WITH_BALL:
                break;

            case CerberusAction.GETTING_PET:
                break;

            case CerberusAction.GETTING_CLEANED:
                break;

            case CerberusAction.SLEEPING:
                break;

            default:
                break;

        }
    }
}
