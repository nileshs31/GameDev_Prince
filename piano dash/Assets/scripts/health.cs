using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour
{
    public int Health;
    public int numOfHealth=30;
    public Image[] Hearts;
    public Sprite Heart;

    void Update()
    {
        for(int i=0;i<Hearts.Length;i++)
        {
            if (i < numOfHealth)
            {
                Hearts[i].enabled = true;
            }
            else
            {
                Hearts[i].enabled = false;
            }
        }
    }
}
