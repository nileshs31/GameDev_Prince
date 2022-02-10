using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDecider : MonoBehaviour
{
    // Start is called before the first frame update

    //Top tiles
    //public GameObject[] TopTiles;
    //public GameObject[] BottomTiles;
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
    void Start()
    {
        row = CSVfile.text.Split(new char[] { '\n' });
    }

    // Update is called once per frame
    void Update()
    {
        if (starter == 11)
        {
            levelno++;
            takefromCSV();
            starter = -1;
            Debug.Log("levelno: " + levelno);
        }
    }
    public void takefromCSV()
    {
        for (int j = 1; j < levelno + 1; j++)
        {
            //words = CSVfile.text.Split(new char[] { ',' });
            notes = row[levelno].Split(new char[] { ',' });
        }
        for (i = 1; i < notes.Length; i++)
        {
            temp[i - 1] = Tilesaudio[i - 1];
        }
        for (i = 1; i < notes.Length; i++)
        {
            Tilesaudio[i - 1] = temp[int.Parse(notes[i]) - 1];
        }
    }
    public AudioClip pickSound()
    {
        starter++;
        return Tilesaudio[starter];
    }
}
