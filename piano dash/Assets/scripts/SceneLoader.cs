using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void LoadQuit()
    {
        SceneManager.LoadScene("QuitScene");
    }
    public void OnApplicationQuit()
    {
        Application.Quit();
    }
    /*public void Restartgame()
    {
        SceneManager.LoadScene("Scene2");
        Time.timeScale = 1;
    }*/
    public void Levels()
    {
        SceneManager.LoadScene("Levels menu");
    }
    public void Settings()
    {
        SceneManager.LoadScene("Settings menu");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }    
}
