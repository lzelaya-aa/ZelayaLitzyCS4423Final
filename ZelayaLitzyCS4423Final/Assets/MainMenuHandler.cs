using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    public void Play(){
        SceneManager.LoadScene("FinalLevelOne");
    }

    public void Quit(){
        Application.Quit();
    }

    public void OpenOptions()
    {
        SceneManager.LoadScene("OptionsMenu");
    }
}
