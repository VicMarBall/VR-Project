using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabDropItem : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip grabAudio;
    [SerializeField] private AudioClip dropAudio;

    public void Grab()
    {
        audioSource.PlayOneShot(grabAudio);
    }

    public void Drop()
    {
        audioSource.PlayOneShot(dropAudio);
    }
}
