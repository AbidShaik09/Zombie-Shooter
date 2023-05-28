using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenuScript : MonoBehaviour
{
    public static void PausGame()
    {
        Time.timeScale = 0.0f;
        SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
    }

   // [Obsolete]
    public static void ResumeGame()
    {
        Time.timeScale = 1f;
       
        SceneManager.UnloadScene("PauseMenu");
    }
}
