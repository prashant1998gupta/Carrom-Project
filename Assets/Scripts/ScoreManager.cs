using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text whiteScoreText;
    public Text blackScoreText;

    int whiteScore;
    int blackScore;

    private void Awake()
    {
        instance = this;
    }

    public void AddScoreWhite()
    {
        whiteScore ++;
        

        whiteScoreText.text = whiteScore.ToString();
        
       
    }

    public void AddScoreBlack()
    {
       
        blackScore++;

        
        blackScoreText.text = blackScore.ToString();

    }

}
