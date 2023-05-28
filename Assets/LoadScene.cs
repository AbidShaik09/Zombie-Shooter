using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    // [Obsolete]
    // [Obsolete]
    
    public static void ReturnGame()
    {
        PlayerControllerScript.resume();
        
    }
   
    public static void Store()
    {
        //Eventsystem.enabled = false;
        //Eventsystem.gameObject.SetActive(false);
        SceneManager.LoadScene("Store",LoadSceneMode.Additive);
    }
    [System.Obsolete]
    public static void Game()
    {
       
        SceneManager.UnloadScene("Store");
      //  Instantiate(EventSystem);
        
    }
    public static void StartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }
    public static void Loadscreen()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Loading");
    }
    public static void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    public static void Quit()
    {
        PlayerPrefs.Save();
        Application.Quit();
    }

    public static void WatchAdsScene()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene("WatchAds", LoadSceneMode.Additive);
    }
    public static void StopWatchAdsScene()
    {
        Time.timeScale = 1;
        SceneManager.UnloadScene("WatchAds");
        //  Instantiate(EventSystem);

    }
}
