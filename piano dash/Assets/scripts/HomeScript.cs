using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeScript : MonoBehaviour
{
    public GameObject settingspanel;
    public GameObject howtoplay;
    public GameObject credits;
    public GameObject areusure;
    public GameObject soundon;
    public GameObject soundoff;
    //public Slider volume;
    public AudioSource soundvolume;
    public string weburl;
    public string playstoreurl;
    public string instaurl;
    int manual = -1;             //-1 means manual is off, automatic is on and 1 means manual is on and automatic is off//
    public GameObject manualbutton;
    public GameObject automaticbutton;

    public void Start()
    {
        if (!PlayerPrefs.HasKey("soundvolume"))
        {
            PlayerPrefs.SetFloat("soundvolume", 1f);
            load();
        }
        else
        {
            load();
        }


        if (!PlayerPrefs.HasKey("manual"))
        {
            PlayerPrefs.SetInt("manual", -1);
            manual = PlayerPrefs.GetInt("manual");
        }
        else
        {
            manual = PlayerPrefs.GetInt("manual");
        }
        if (manual == 1)
        {
            manualbutton.SetActive(true);
            automaticbutton.SetActive(false);
        }
        else
        {
            manualbutton.SetActive(false);
            automaticbutton.SetActive(true);
        }
    }
    public void Play()
    {
        SceneManager.LoadScene("Levels");
    }
    public void Settings()
    {
        //SceneManager.LoadScene("Settings menu");
        settingspanel.SetActive(true);
    }
    public void Web()
    {
        //SceneManager.LoadScene("Play");
        Application.OpenURL(weburl);
    }
    public void Insta()
    {
        //SceneManager.LoadScene("Play");
        Application.OpenURL(instaurl);
    }
    public void Playstore()
    {
        //SceneManager.LoadScene("Play");
        Application.OpenURL(playstoreurl);
    }
    public void Back()
    {
        settingspanel.SetActive(false);
        howtoplay.SetActive(false);
        credits.SetActive(false);
    }
    public void howto()
    {
        howtoplay.SetActive(true);
    }
    public void creditspanel()
    {
        credits.SetActive(true);
    }
    public void volumeoff()
    {
        soundvolume.volume = 0;
        //volume.value = 0;
        save();
        soundoff.SetActive(true);
        soundon.SetActive(false);
    }
    public void volumeon()
    {
        soundvolume.volume = 1;
        //volume.value = 1;
        save();
        soundon.SetActive(true);
        soundoff.SetActive(false);
    }
    private void load()
    {
        soundvolume.volume = PlayerPrefs.GetFloat("soundvolume");
        if (soundvolume.volume == 1)
        {
            soundon.SetActive(true);
            soundoff.SetActive(false); ;
        }
        else
        {
            soundon.SetActive(false);
            soundoff.SetActive(true); ;
        }
    }
    private void save()
    {
        PlayerPrefs.SetFloat("soundvolume", soundvolume.volume);
    }
    public void areyousure()
    {
        areusure.SetActive(true);
    }
    public void notsure()
    {
        areusure.SetActive(false);
    }
    public void OnApplicationQuit()                                     //function to call when sure to exit//
    {
        Application.Quit();
    }
    public void manualmovement()
    {
        manual = 1;
        PlayerPrefs.SetInt("manual", manual);
        manualbutton.SetActive(true);
        automaticbutton.SetActive(false);
    }
    public void automaticmovement()
    {
        manual = -1;
        PlayerPrefs.SetInt("manual", manual);
        manualbutton.SetActive(false);
        automaticbutton.SetActive(true);
    }


}
