﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class refilllives : MonoBehaviour
{
    // Start is called before the first frame update
    public MOTION motionscript;
    public GameObject continuescreen;
    public gameConroller continuescreenupdate;

    public void checkforcoins()
    {
        if (motionscript.coin >= 2)
        {
            motionscript.coin -= 2;
            PlayerPrefs.SetInt("totalcoin", motionscript.coin);
            motionscript.totalcoins.text = motionscript.coin.ToString();
            refill();
        }
        else
        {
            //do something
        }
    }
    public void refill()
    {
        continuescreen.SetActive(false);
        motionscript.lives = 6;
        continuescreenupdate.continueenabled = false;
        Time.timeScale = 1;
        continuescreenupdate.currenttime = continuescreenupdate.startingtime;
        for (int temp = 0; temp <6; temp++)
        {
            motionscript.heart[temp].SetActive(true);
        }

    }
}
