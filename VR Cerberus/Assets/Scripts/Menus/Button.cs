using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    private bool canClick = true;
    public float cooldownTime = 0.5f;

    public void OnButtonClick()
    {
        if (canClick)
        {
            StartCoroutine(PlayAudioWithCooldown());
        }
    }

    private IEnumerator PlayAudioWithCooldown()
    {
        canClick = false;
        audioSource.Play();
        yield return new WaitForSeconds(cooldownTime);
        canClick = true;
    }
}
