using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatButton : MonoBehaviour
{
    public GameObject hat;

    public void OnButtonClick()
    {
        Instantiate(hat);
    }
}
