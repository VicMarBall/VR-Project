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

    public int timesHasEaten = 0;

    public int energy;

    public int friendship;

    private void Update()
    {
        if (hygiene > 100) { hygiene = 100; }
        if (satiation > 100) { satiation = 100; }
        if (fun > 100) { fun = 100; }
        if (affection > 100) { affection = 100; }

        if (hygiene < 0) { hygiene = 0; }
        if (satiation < 0) { satiation = 0; }
        if (fun < 0) { fun = 0; }
        if (affection < 0) { affection = 0; }

        if (energy > 100) { energy = 100; }
        if (energy < 0) { energy = 0; }

    }

    public bool IsTired() { return (energy <= 0); }
    public bool IsDirty() { return (hygiene < 75); }
    public bool IsHungry() { return (satiation < 75); }
    public bool IsBored() { return (fun < 75); }
}
