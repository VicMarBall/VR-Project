using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaysManager : MonoBehaviour
{
    int currentDay = 1;

    [SerializeField]
    FadeScreen fade;

    [SerializeField]
    CerberusStats cerberus;

    [SerializeField]
    float timeFromTiredToFadeToBlack;

    float fromTiredToBlackTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cerberus.IsTired())
        {
            fromTiredToBlackTimer += Time.deltaTime;

            if (fromTiredToBlackTimer > timeFromTiredToFadeToBlack)
            {
                StartCoroutine(EndDay());
            }
        }
    }

    IEnumerator EndDay()
    {
        float timer = 0;

        fade.FadeOut();
        while (timer <= 5)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        currentDay++;
        cerberus.energy = 100;

        fade.FadeIn();
    }
}
