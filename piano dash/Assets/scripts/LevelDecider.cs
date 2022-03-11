using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelDecider : MonoBehaviour
{
    int levelno;
    int levelopened;
    //bool buttoninteractable = false;
    GameObject levelbutton;
    public GameObject[] heart;
    int lives;
    
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("levelno"))
        {
            PlayerPrefs.SetInt("levelno", 1);
            levelno = PlayerPrefs.GetInt("levelno");
        }
        else
        {
            levelno = PlayerPrefs.GetInt("levelno");
        }
        if (!PlayerPrefs.HasKey("levelopened"))
        {
            PlayerPrefs.SetInt("levelopened", levelno);
            levelopened = PlayerPrefs.GetInt("levelopened");
        }
        else
        {
            levelopened = PlayerPrefs.GetInt("levelopened");
        }
        for (int i = 1; i <= levelopened; i++)
        {
            levelbutton = GameObject.Find(i.ToString());
            levelbutton.GetComponent<Button>().interactable = true;
        }/*
        if (!PlayerPrefs.HasKey("chanceleft"))
        {
            PlayerPrefs.SetInt("chanceleft", 6);
            lives = PlayerPrefs.GetInt("chanceleft");
        }
        else
        {
            lives = PlayerPrefs.GetInt("chanceleft");
        }
        for (int temp = 6; temp > lives; temp--)
        {
            heart[temp - 1].SetActive(false);
        }*/
    }

    public void whichlevel()
    {
        PlayerPrefs.SetInt("levelno", int.Parse(this.name));
        levelno = PlayerPrefs.GetInt("levelno");
        //Debug.Log(levelno);
        SceneManager.LoadScene("Play");
    }
    public void back()
    {
        SceneManager.LoadScene("Home");
    }
}
