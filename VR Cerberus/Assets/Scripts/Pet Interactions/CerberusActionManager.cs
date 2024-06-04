using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerberusActionManager : MonoBehaviour
{
    public enum CerberusAction
    {
        IDLE, 

        SEEKING_ITEM, // look at

        GRABBING_ITEM,

        GETTING_TOUCHED,

        SLEEPING
    }

    public CerberusStats cerberus;

    public CerberusAction currentAction;

    public CerberusItemInteraction itemInteraction;

    public CerberusTouchInteraction leftTouchInteraction;
    public CerberusTouchInteraction middleTouchInteraction;
    public CerberusTouchInteraction rightTouchInteraction;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        itemInteraction = gameObject.GetComponent<CerberusItemInteraction>();

        if (itemInteraction == null) { Debug.Log("CerberusItemInteraction not found");  }

        anim = gameObject.GetComponent<Animator>();
    }

    void UpdateCurrentAction()
    {
        CerberusAction previousAction = currentAction;

        if (cerberus.IsTired())
        {
            currentAction = CerberusAction.SLEEPING;

            if (previousAction == CerberusAction.GRABBING_ITEM)
            {
                itemInteraction.ReleaseFocusedItem();
            }

            return;
        }
        
        if (leftTouchInteraction.GettingTouched() || middleTouchInteraction.GettingTouched() || rightTouchInteraction.GettingTouched())
        {
            currentAction = CerberusAction.GETTING_TOUCHED;

            if (previousAction == CerberusAction.GRABBING_ITEM)
            {
                itemInteraction.ReleaseFocusedItem();
            }

            return;
        }

        if (itemInteraction.IsGrabbing())
        {
            currentAction = CerberusAction.GRABBING_ITEM;

            return;
        }

        if (itemInteraction.IsFocused())
        {
            currentAction = CerberusAction.SEEKING_ITEM;

            return;
        }

        currentAction = CerberusAction.IDLE;
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
                itemInteraction.CerberusSeekingUpdate();
                break;

            case CerberusAction.GRABBING_ITEM:
                anim.SetInteger("STATE", 2);
                if (itemInteraction.FocusedItemIsFood())
                {
                    itemInteraction.CerberusEatingUpdate();
                }
                else if (itemInteraction.FocusedItemIsToy())
                {
                    itemInteraction.CerberusPlayingUpdate();
                }
                break;

            case CerberusAction.GETTING_TOUCHED:
                anim.SetInteger("STATE", 3);
                leftTouchInteraction.CerberusUpdate();
                middleTouchInteraction.CerberusUpdate();
                rightTouchInteraction.CerberusUpdate();
                break;

            case CerberusAction.SLEEPING:
                anim.SetInteger("STATE", 0);
                break;

            default:
                break;

        }
    }
}
