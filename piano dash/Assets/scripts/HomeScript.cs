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
    public Slider volume;
    public AudioSource soundvolume;
    public string weburl;
    public string playstoreurl;
    public string instaurl;

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
    }
    public void Play()
    {
        SceneManager.LoadScene("Play");
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
    public void volumechange()
    {
        soundvolume.volume = volume.value;
        save();
    }
    private void load()
    {
        volume.value = PlayerPrefs.GetFloat("soundvolume");
        soundvolume.volume = volume.value;
    }
    private void save()
    {
        PlayerPrefs.SetFloat("soundvolume", volume.value);
    }
    public void OnApplicationQuit()                                     //function to call when want to exit//
    {
        Application.Quit();
    }


}
