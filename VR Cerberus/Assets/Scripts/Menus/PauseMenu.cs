using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public void Pause() 
    { 
        pauseMenu.SetActive(true);
    }

    public void Home()
    {
        print("Home not available :D");
        //SceneManager.LoadSceneAsync("TestingScene"); //This should be changed to correct name, just for debug
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
    }
}
