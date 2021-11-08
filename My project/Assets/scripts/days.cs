using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class days : MonoBehaviour
{
    public int dayNum = 1;
    private float fadeSpeed = 2.0f;
    private int sceneNumber;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeInFromBlack());
        sceneNumber = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            StartCoroutine(FadeToBlack());
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            StartCoroutine(FadeInFromBlack());
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            LoadNextDay();
        }
    }

    void advanceDay()
    {
        dayNum++;
    }

    IEnumerator FadeInFromBlack()
    {
        while (this.GetComponent<Renderer>().material.color.a > 0)
        {
            Color blackScreen = this.GetComponent<Renderer>().material.color;
            float fadeAmount = blackScreen.a - (fadeSpeed * Time.deltaTime);
            blackScreen = new Color(blackScreen.r, blackScreen.g, blackScreen.b, fadeAmount);
            this.GetComponent<Renderer>().material.color = blackScreen;
            yield return null;
        }
    }

    IEnumerator FadeToBlack()
    {
        while (this.GetComponent<Renderer>().material.color.a < 1)
        {
            Color blackScreen = this.GetComponent<Renderer>().material.color;
            float fadeAmount = blackScreen.a + (fadeSpeed * Time.deltaTime);
            blackScreen = new Color(blackScreen.r, blackScreen.g, blackScreen.b, fadeAmount);
            this.GetComponent<Renderer>().material.color = blackScreen;
            yield return null;
        }
    }

    public void LoadNextDay()
    {
        advanceDay();
        SceneManager.LoadScene(sceneNumber + 1);
    }

    public void LoadSameDay()
    {
        SceneManager.LoadScene(sceneNumber);
    }
}