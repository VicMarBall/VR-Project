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

    public Cerberus cerberus;

    public CerberusAction currentAction;

    CerberusItemInteraction itemInteraction;

    // Start is called before the first frame update
    void Start()
    {
        itemInteraction = gameObject.GetComponent<CerberusItemInteraction>();
        itemInteraction.actionManager = this;

        if (itemInteraction == null) { Debug.Log("CerberusItemInteraction not found");  }
    }

    void UpdateCurrentAction()
    {
        if (cerberus.IsTired())
        {
            currentAction = CerberusAction.SLEEPING;
            return;
        }

        if (itemInteraction.IsFocused())
        {
            if (itemInteraction.FocusedItemIsToy())
            {
                //currentAction;
            }
            else if (itemInteraction.FocusedItemIsFood())
            {
                //currentAction;
            }

        }
    }






    // Update is called once per frame
    void Update()
    {
        UpdateCurrentAction();


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
