using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer : MonoBehaviour
{
    public float gameTimer = 0.0f;
    //Displays text with clock on screen.
    //public Text timerText;

    //Will interact with Song method to change songs
    public float rushHourStart = 60.0f;
    public float rushHourEnd = 300.0f;

    public float dayLength = 360.0f;

    void Start()
    {
        ResetDayTimer();
    }

    void Update()
    {
        gameTimer += Time.deltaTime;

        if (gameTimer > dayLength)
        {
            gameTimer = dayLength;


            endDay(); //Queue end of day sequence
        }

        showTime(gameTimer);
    }


    public void endDay()
    {
        gameTimer = 360.0f;
    }

    public void showTime(float gameTime)
    {

        int minutes = Mathf.FloorToInt(gameTimer / 60);
        int seconds = Mathf.FloorToInt(gameTimer % 60);

    //    timerText.text = "Time: " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    //public void prematureEnd(/*Customers served */)
    //{
    //if (Customers served  == maxCustomers)
    //{
    //endDay()
    // }
    // }

    void ResetDayTimer()
    {
        gameTimer = 0;
    }

}
