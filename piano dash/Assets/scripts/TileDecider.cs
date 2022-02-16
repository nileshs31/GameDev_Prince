using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class TileDecider : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioClip[] Tilesaudio;
    public AudioSource speaker;
    public int[] order_of_tiles;
    public TextAsset CSVfile;
    string[] notes;
    string[] row;
    int i = 0;
    int starter = -1;
    int levelno = 1;
    AudioClip[] temp=new AudioClip[12];
    public GameObject levelcomplete;
    public Animator levelcompanim;

    string rowsjson="";
    string[] lines;
    List<string> eachrow;
    public GameObject networkerror;

    void Start()
    {
        row = CSVfile.text.Split(new char[] { '\n' });
        if (!PlayerPrefs.HasKey("levelno"))
        {
            PlayerPrefs.SetInt("levelno", 1);
            levelno = PlayerPrefs.GetInt("levelno");
        }
        else
        {
            levelno = PlayerPrefs.GetInt("levelno");
        }
        takefromCSV();
    }
    public void resetanim()
    {
        levelcomplete.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (starter == 11)
        {
            levelno++;
            if (levelno > PlayerPrefs.GetInt("levelopened"))
            {
                PlayerPrefs.SetInt("levelopened", levelno);
            }
            takefromCSV();
            starter = -1;
            levelcomplete.SetActive(true);
            levelcompanim.enabled = true;
            levelcompanim.speed = 3f;
            levelcompanim.Play("task_anim");
            Invoke("resetanim", 3f);
            Debug.Log("levelno: " + levelno);
        }
    }
    public void takefromCSV()
    {
        StartCoroutine(ObtainSheetData());
    }
    public AudioClip pickSound()
    {
        starter++;
        return Tilesaudio[starter];
    }
    void takerandomvalues()
    {
        for (i = 0; i < 12; i++)
        {
            temp[i] = Tilesaudio[i];
        }
        for (i = 0; i < 12; i++)
        {
            float rndm = Random.Range(0, 11);
            int rndmvalue = Mathf.FloorToInt(rndm);
            Tilesaudio[i] = temp[rndmvalue];
        }
    }
    IEnumerator ObtainSheetData()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://sheets.googleapis.com/v4/spreadsheets/1anWnf2R2L7QBh9zMa4z6wQo6EH8960BSkJmf3FHE2us/values/Sheet1?key=AIzaSyAb4mUJkstvNEo-NWEN28K_Q-hpP-12zRw");
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError || www.timeout>2)
        {
            Debug.Log("error" + www.error);
            //networkerror.SetActive(true);
            takerandomvalues();
            Debug.Log("Offline");
        }
        else
        {
            networkerror.SetActive(false);
            string json = www.downloadHandler.text;
            var o = JSON.Parse(json);
            foreach (var item in o["values"])
            {
                var itemo = JSON.Parse(item.ToString());
                eachrow = itemo[0].AsStringList;
                foreach (var bro in eachrow)
                {
                    rowsjson += bro+",";
                }
                rowsjson += "\n";
            }
            lines = rowsjson.Split(new char[] { '\n' });
            notes = lines[levelno].Split(new char[] { ',' });
            for (i = 1; i < notes.Length-1; i++)
            {
                temp[i - 1] = Tilesaudio[i - 1];
            }
            for (i = 1; i < notes.Length-1; i++)
            {
                //Tilesaudio[i - 1] = temp[int.Parse(notes[i]) - 1];
                Tilesaudio[int.Parse(notes[i]) - 1] = temp[i - 1];
            }
        }
    }
}
