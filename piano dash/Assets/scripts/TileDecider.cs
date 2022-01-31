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
    int i = 0;
    int starter = -1;
    AudioClip[] temp=new AudioClip[12];
    void Start()
    {
        for (i = 0; i < order_of_tiles.Length; i++)
        {
            temp[i] = Tilesaudio[i];
        }
        for (i = 0; i < order_of_tiles.Length; i++)
        {
            Tilesaudio[i] = temp[order_of_tiles[i]];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (starter == 11)
        {
            starter = -1;
        }
    }
    public AudioClip pickSound()
    {
        starter++;
        return Tilesaudio[starter];
    }
}
