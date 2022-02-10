using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class gameConroller : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject VolumeOffButton;
    public GameObject VolumeOnButton;
    public GameObject HowToPlay;
    public GameObject Credits;
    public GameObject GameOverScreen;
    public GameObject POPUP;
    public GameObject Thanks;
    
    public MOTION M;
    public health H;
    public audioManager AM;
    public Level L;
    public SceneLoader SL;

    //
    public Slider volume;
    public GameObject Pause;
    public AudioSource soundvolume;
    public TextMeshProUGUI scoretext;
    public TextMeshProUGUI besttext;
    private int highscore;


    /*public void Start()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("level");
        L = obj.GetComponent<Level>(); 
        VolumeOffButton.SetActive(true);
        VolumeOnButton.SetActive(false);

        if (!PlayerPrefs.HasKey("soundvolume"))
        {
            Debug.Log("wrongside");
            PlayerPrefs.SetFloat("soundvolume", 1f);
            load();
        }
        else
        {
            Debug.Log("rightside");
            load();
        }


    }*/

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

        if (!PlayerPrefs.HasKey("highscore"))
        {
            PlayerPrefs.SetInt("highscore", 0);
            highscore = PlayerPrefs.GetInt("highscore");
        }
        else
        {
            highscore = PlayerPrefs.GetInt("highscore");
        }
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void VolOn()
    {
        VolumeOffButton.SetActive(true);
        VolumeOnButton.SetActive(false);
        //AudioListener.volume = 1f;


    }
    public void VolOff()
    {
        VolumeOnButton.SetActive(true);
        VolumeOffButton.SetActive(false);

        //AudioListener.volume = 0f;

    }
    public void Home()
    {
        SceneManager.LoadScene("Home");
    }
    public void GameOver()
    {
        GameOverScreen.SetActive(true);
        Time.timeScale = 0;
        M.FireAllowed = false;
        scoretext.text = M.coin.ToString();
        if (M.coin > highscore)
        {
            highscore = M.coin;
            PlayerPrefs.SetInt("highscore", highscore);
        }
        besttext.text = highscore.ToString();
    }
    public void Continue()
    {
        H.numOfHealth = 1;

        Thanks.SetActive(false);
        SceneManager.LoadScene("scene2");
        Time.timeScale = 1;



    }
    public void showPopUp()
    {
        POPUP.SetActive(true);
        Time.timeScale = 0;
        M.FireAllowed = false;


    }
    public void remover()
    {
        GameOverScreen.SetActive(false);
    }
    public void adFinished()
    {
        GameOverScreen.SetActive(false);
        M.FireAllowed = false;
        Thanks.SetActive(true);

    }
    public void PauseMenu()
    {
        //M.canBeTapped = false;
        Pause.SetActive(true);
        Time.timeScale = 0;

    }
    public void RetryLevel()
    {
        //POPUP.SetActive(false);
        Pause.SetActive(false);

        //AM.Play1();
        Time.timeScale = 1;
        //M.canBeTapped = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);



    }
    public void NEXT()
    {
        POPUP.SetActive(false);
        AM.temp++;
        L.level++;
        L.unlock();
        RetryLevel();
        Time.timeScale = 1;
        M.FireAllowed = true;

    }
    public void ResumeGame()
    {
        Pause.SetActive(false);
        Time.timeScale = 1;
        //M.canBeTapped = true;
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
    public void LoadQuit()                                              //only if we need a final confirmation scene before exiting//
    {
        SceneManager.LoadScene("QuitScene");
    }
    public void Levels()
    {
        SceneManager.LoadScene("Levels menu");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }



}
