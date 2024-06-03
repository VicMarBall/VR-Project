using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleaningObject : MonoBehaviour
{
    public ParticleSystem cleaningParticles;
    [SerializeField] private AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CleaningEvent()
    {
        cleaningParticles.Play();
        audioSource.Play();
    }
}