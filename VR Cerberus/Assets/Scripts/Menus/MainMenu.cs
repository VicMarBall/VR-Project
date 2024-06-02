using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        print("Scene not available :D");
        //SceneManager.LoadSceneAsync("TestingScene"); //This should be changed to correct name, just for debug
    }

    public void Quit()
    {
        Application.Quit();
    }
}
