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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
