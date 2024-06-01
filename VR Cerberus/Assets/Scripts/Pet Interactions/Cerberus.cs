using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cerberus : MonoBehaviour
{
    public Dictionary<HeadPosition, CerberusHead> heads;

    public int hygiene;
    public int satiation;
    public int fun;

    public int energy;

    public int friendship;

    // Start is called before the first frame update
    void Start()
    {
        heads[HeadPosition.LEFT].cerberus = this;
        heads[HeadPosition.LEFT].headPosition = HeadPosition.LEFT;

        heads[HeadPosition.MIDDLE].cerberus = this;
        heads[HeadPosition.MIDDLE].headPosition = HeadPosition.MIDDLE;

        heads[HeadPosition.RIGHT].cerberus = this;
        heads[HeadPosition.RIGHT].headPosition = HeadPosition.RIGHT;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsTired() { return (energy <= 0); }
    public bool IsDirty() { return (hygiene < 75); }
    public bool IsHungry() { return (satiation < 75); }
}
