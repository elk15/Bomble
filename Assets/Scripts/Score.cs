using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;

public class Score : MonoBehaviour
{
    public static int scoreValue = 0;
    public static int initScorePool = 500;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = string.Format("Score: {0}", scoreValue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CalculateScorePerTime()
    {

        System.Diagnostics.Debug.WriteLine("initScorePool: {0}", initScorePool);

        initScorePool -= 1;

        if (scoreValue < 0)
        {
            scoreValue = 0;
        }
    }

    void CalculateScorePerTry(int currentNumBox)
    {
        //if(currentNumBox)

        if(scoreValue < 0)
        {
            scoreValue = 0;
        }
    }
}
