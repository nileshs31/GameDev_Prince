using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class gameConroller : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject GameOverScreen;
    public GameObject Thanks;
    public GameObject continuepanel;
    public Slider progress;
    public MOTION M;

    //
    public Slider volume;
    public GameObject Pause;
    public AudioSource soundvolume;
    public TextMeshProUGUI scoretext;
    public TextMeshProUGUI besttext;
    private int highscore;
    public float currenttime;
    public float startingtime = 5f;
    public bool continueenabled = false;


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
        currenttime = startingtime;
    }

    // Update is called once per frame
    void Update()
    {
        if (continueenabled)
        {
            if (currenttime > 0)
            {
                progress.value = currenttime * 0.2f;
                currenttime -= Time.unscaledDeltaTime;
            }
            else
            {
                continueenabled = false;
                //Debug.Log("came out good");
                GameOver();
            }
        }
    }
    public void Home()
    {
        SceneManager.LoadScene("Home");
    }
    public void GameOver()
    {
        continuepanel.SetActive(false);
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
    public void continuescreen()
    {
        continuepanel.SetActive(true);
        Time.timeScale = 0;
        continueenabled = true;
        //currenttime -= Time.unscaledDeltaTime;
        //Time.deltaTime
        /*while (currenttime >0)
        {
            currenttime -= Time.time;
            //currenttime += 1 * Time.deltaTime;
            Debug.Log(currenttime);
        }*/
        //continuepanel.SetActive(false);

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
