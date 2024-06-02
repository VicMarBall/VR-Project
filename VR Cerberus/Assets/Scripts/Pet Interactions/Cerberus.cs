using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cerberus : MonoBehaviour
{
    public CerberusHead leftHead;
    public CerberusHead middleHead;
    public CerberusHead rightHead;

    public CerberusActionManager actionManager;

    public int hygiene;
    public int satiation;
    public int fun;

    public int energy;

    public int friendship;

    // Start is called before the first frame update
    void Start()
    {
        leftHead.cerberus = this;
        leftHead.headPosition = HeadPosition.LEFT;

        middleHead.cerberus = this;
        middleHead.headPosition = HeadPosition.MIDDLE;

        rightHead.cerberus = this;
        rightHead.headPosition = HeadPosition.RIGHT;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsTired() { return (energy <= 0); }
    public bool IsDirty() { return (hygiene < 75); }
    public bool IsHungry() { return (satiation < 75); }
    public bool IsBored() { return (fun < 75); }
}
