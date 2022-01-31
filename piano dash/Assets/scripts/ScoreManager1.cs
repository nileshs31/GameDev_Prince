using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager1 : MonoBehaviour
{
    // Start is called before the first frame update
    public int score;
 
    public Text scoreDisplay;
 
    public Text highScore;
    public void AddScore()
    {
        score = score + 1;
        scoreDisplay.text = "Score: " + score;
   
    }
}
