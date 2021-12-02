using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class days : MonoBehaviour
{
    public GameObject scriptHolder;
    public timer timeAccessor;
    public movement move;

    public GameObject charScript;
    public levelWinFail checkWF;
    private Animator _anim;
    
    private int temp = 0;

    private int dayNum;
    private float fadeSpeed = 1.0f;
    private int sceneNumber;
    private bool endSequence = false;
    // Start is called before the first frame update
    void Start()
    {
        sceneNumber = SceneManager.GetActiveScene().buildIndex;
        dayNum = sceneNumber + 1;
        StartCoroutine(FadeInFromBlack());
        scriptHolder = GameObject.Find("UI Holder"); //TimeHolder is an empty game object. It should be replaced by UI component in the future.
        timeAccessor = scriptHolder.GetComponent<timer>();
        charScript = GameObject.Find("character");
        checkWF = charScript.GetComponent<levelWinFail>();

        _anim = charScript.GetComponent<Animator>();
        move = charScript.GetComponent<movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timeAccessor.dayDone && !endSequence)
        {
            endSequence = true;

            //Stops player movement after the day has concluded
            //BUG: Players still in motion after day timer ends have drift
            move.enabled = false;

            //Plays win or fail animation upon day's end
            StartCoroutine(WinFailCheck());


           /* if (temp == 500)
            {
                //Insert fade to black code
                StartCoroutine(FadeToBlack());
                LoadNextDay();
            }
            temp++;*/
        }

        /*if (Input.GetKeyDown(KeyCode.O))
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
        }*/
    }

    IEnumerator WinFailCheck()
    {
        //.Log("WinFailCheck called");
       int baseLayer = _anim.GetLayerIndex("Base Layer");
        for (int i = 1; i < 6; i++)
        {
            _anim.SetLayerWeight(i, 0);
        }

        _anim.SetLayerWeight(baseLayer, 1000);
        Debug.Log(_anim.GetLayerWeight(0));
        checkWF.winOrFail();

        yield return new WaitForSeconds(7);

        StartCoroutine(FadeToBlack());
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

        }
        if (_anim.GetBool("levelWin"))
        {
            LoadNextDay();
        }
        else
        {
            LoadSameDay();
        }
            yield return null;
    }

    public void LoadNextDay()
    {
        SceneManager.LoadScene(sceneNumber + 1);
    }

    public void LoadSameDay()
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public int getDayNum()
    {
        return dayNum;
    }
}