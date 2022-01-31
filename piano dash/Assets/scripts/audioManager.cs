using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    public  Level L;
    public gameConroller GM;
    public AudioSource[] sou;
    public AudioSource bad = null;
    public AudioSource bad2 = null;
    public int a=0;
    public int[] numb1;
    public int[] numb2;
    public int[] numb3;
    public int[] numb4;
    public int[] numb5;
    public int[] numb6;
    public int[] numb7;
    public int[] numb8;
    public int[] numb9;
    public int[] numb10;
    public int temp;

     void Start()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("level");
        L = obj.GetComponent<Level>();
         
        temp = L.level;
        
    }
    public void Play1()
    {
         
        if (temp == 1)
        {
            sou[numb1[a]].Play();
            a++;
            if (a == 11)
            {
                a = 0;
                GM.showPopUp();

            }
        }
        if (temp == 2)
        {
            sou[numb2[a]].Play();
            a++;
            if (a == 11)
            {
                a = 0;
                GM.showPopUp();
            }
        }
        if (temp == 3)
        {
            sou[numb3[a]].Play();
            a++;
            if (a == 11)
            {
                a = 0;
                GM.showPopUp();
            }
        }
        if (temp == 4)
        {
            sou[numb4[a]].Play();
            a++;
            if (a == 11)
            {
                a = 0;
                GM.showPopUp();
            }
        }
        if (temp == 5)
        {
            sou[numb5[a]].Play();
            a++;
            if (a == 11)
            {
                a = 0;
                GM.showPopUp();
            }
        }
        if (temp == 6)
        {
            sou[numb6[a]].Play();
            a++;
            if (a == 11)
            {
                a = 0;
                GM.showPopUp();
            }
        }
        if (temp == 7)
        {
            sou[numb7[a]].Play();
            a++;
            if (a == 11)
            {
                a = 0;
                GM.showPopUp();
            }
        }
        if (temp == 8)
        {
            sou[numb8[a]].Play();
            a++;
            if (a == 11)
            {
                a = 0;
                GM.showPopUp();
            }
        }
        if (temp == 9)
        {
            sou[numb9[a]].Play();
            a++;
            if (a == 11)
            {
                a = 0;
                GM.showPopUp();
            }
        }
        if (temp == 10)
        {
            sou[numb10[a]].Play();
            a++;
            if (a == 11)
            {
                a = 0;
                GM.showPopUp();
            }
        }
     }
     public void PlayA3()
    {
        bad.Play();
    }
    public void PlayA2()
    {
        bad2.Play();
    }
    
     

}
