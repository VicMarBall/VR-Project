using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerberusStats : MonoBehaviour
{
    public CerberusActionManager actionManager;

    public int hygiene;
    public int satiation;
    public int fun;
    public int affection;

    public int timesHasEaten;

    public int energy;

    public int friendship;

    public bool IsTired() { return (energy <= 0); }
    public bool IsDirty() { return (hygiene < 75); }
    public bool IsHungry() { return (satiation < 75); }
    public bool IsBored() { return (fun < 75); }
}
