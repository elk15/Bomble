using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int scoreValue = 0;
    public static int initScorePool = 600;
    public Text scoreText;
    public Gameplay gameplay;
    
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CalculateScore()
    {
        scoreValue = CalculateScorePerTry(gameplay.currentNumBox) - gameplay.finalTime/2;
        Debug.Log(scoreValue);
        scoreText.text = string.Format("{0}", scoreValue);
    }

    public int CalculateScorePerTry(int currentNumBox)
    {
        int score;
        score = initScorePool - currentNumBox*100;
        return score;
    }
}
