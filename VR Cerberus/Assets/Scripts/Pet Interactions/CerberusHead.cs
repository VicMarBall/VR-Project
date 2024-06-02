using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HeadPosition
{
    LEFT,
    MIDDLE,
    RIGHT
}

public class CerberusHead : MonoBehaviour
{
    public HeadPosition headPosition;

    public Cerberus cerberus;

    public int affection;

    bool hasEaten;

    public CerberusTouchInteraction petInteraction;

    // Start is called before the first frame update
    void Start()
    {
        petInteraction.head = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (cerberus.actionManager.currentAction == CerberusActionManager.CerberusAction.GETTING_PET)
        {
            petInteraction.HeadUpdate();
        }
    }
}
