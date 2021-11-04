using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class days : MonoBehaviour
{
    public int dayNum = 1;
    private float fadeSpeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            StartCoroutine(FadeToBlack());
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            StartCoroutine(FadeInFromBlack());
        }
    }

    void advanceDay()
    {
        dayNum++;
    }

    IEnumerator FadeToBlack()
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

    IEnumerator FadeInFromBlack()
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
}