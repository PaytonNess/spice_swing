using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoring : MonoBehaviour
{
    private int score;
    public int multiplier;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        resetScore();
        multiplier = 1;
    }

    void Update()
    {
        scoreText.text = "Score: " + score;
    }

    // Returns the current score
    int getScore()
    {
        return score;
    }

    //Modifies current score
    public void setScore(int scoreToAdd)
    {
        score += scoreToAdd * multiplier;
    }

    //Resets the score for the level
    void resetScore()
    {
        score = 0;
    }

    public void setMultiplier(bool streak)
    {
        if (streak)
        {
            multiplier += 1;
        }
        else
        {
            multiplier = 1;
        }
    }
}
