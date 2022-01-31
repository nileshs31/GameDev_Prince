using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
     public int level;
    public int[] Levelnumber;
    public Button[] LevelButton;
    public int g;
    //public SceneLoader SL;
    int levelAt; 
 
      public void Start()
      {
        DontDestroyOnLoad(this.gameObject);
        levelAt = PlayerPrefs.GetInt("levelAt", 1);
         for(int i= 0;i < LevelButton.Length; i++ )
         {
             LevelButton[i].interactable = false;
            
         }
        for (int i = 0; i < levelAt; i++)
        {
            LevelButton[i].interactable = true;
        }

    }
     public void levelPlus(int i)
     {
        level = i;
     }
    public void unlock()
    {
        PlayerPrefs.SetInt("levelAt", ++levelAt);

        
    }
}
