using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class minigame : MonoBehaviour
{
    public AudioSource player;
    public GameObject MiniGameBG;
    public GameObject Out_Of_Bounds;
    public GameObject QualityMeter;
    public GameObject LeftArrowEnd;
    public GameObject RightArrowEnd;
    public GameObject UpArrowEnd;
    public GameObject DownArrowEnd;
    public GameObject Left_Arrow;
    public GameObject Up_Arrow;
    public GameObject Down_Arrow;
    public GameObject Right_Arrow;

    public GameObject scriptHolder;
    public GameObject uiScript;
    public GameObject daysScript;
    public minigame modifyQuality;
    public scoring scoreHelper;
    public movement move;
    public days days;
    public timer timeAccessor;

    public int quality;
    public int qualityStart = 3; //quality starts at 3; Max value of 10
    public int qualityMax = 10;
    private int dayNum; //Holds day of week number
    public int mgWaitTime = 20;

    public Vector3 temp;
    private interaction inter;
    private bool failedMG = false; //Has the player failed the minigame?
    private bool destroyedArrows = false;

    //Set number of notes needed per day
    private int[] numOfNotes = { 3, 5, 6, 10, 12 };


    //The pace at which notes fall down
    private float[] notePace = { 2.0f, 1.75f, 1.5f, 1.25f, 1.0f };


    private List<GameObject> notesList;
    // Start is called before the first frame update
    void Start()
    {
        move = GetComponent<movement>();

        quality = 3;
        //Set number of notes in mini game.
        inter = GetComponent<interaction>();
        scriptHolder = GameObject.Find("character");
        modifyQuality = scriptHolder.GetComponent<minigame>();
        uiScript = GameObject.Find("UI Holder");
        scoreHelper = uiScript.GetComponent<scoring>();
        timeAccessor = uiScript.GetComponent<timer>();
        daysScript = GameObject.Find("FadeOutScreen");
        days = daysScript.GetComponent<days>();
        DeactivateMiniGame();
    }

    // Update is called once per frame
    void Update()
    {
        
        if ((getQuality() <= 0 && destroyedArrows == false) || timeAccessor.dayDone == true)
        {
            GameObject[] arrowsGenerated;

            destroyedArrows = true;
            failedMG = true;
            arrowsGenerated = GameObject.FindGameObjectsWithTag("LeftArrow");
            DestroyArrows(arrowsGenerated);
            arrowsGenerated = GameObject.FindGameObjectsWithTag("UpArrow");
            DestroyArrows(arrowsGenerated);
            arrowsGenerated = GameObject.FindGameObjectsWithTag("DownArrow");
            DestroyArrows(arrowsGenerated);
            arrowsGenerated = GameObject.FindGameObjectsWithTag("RightArrow");
            DestroyArrows(arrowsGenerated);

            DeactivateMiniGame();
        }
    }


    List<GameObject> randomizeNotes(int numNotes)
    {
        //List is created to hold set of randomized notes
        List<GameObject> listOfNotes = new List<GameObject>();

        //Loop continues until listOfNotes has appropriated number of notes for the mini-game
        for (int i = 0; i < numNotes; i++)
        {

            int noteChoice = (int) Random.Range(0.0f, 4.0f);
            if (noteChoice == 0)
            {
                listOfNotes.Add(Left_Arrow);
                temp = new Vector3(LeftArrowEnd.transform.position.x, Left_Arrow.transform.position.y, 0);

                ////.Log("List added left arrow");
            }
            else if (noteChoice == 1)
            {
                listOfNotes.Add(Up_Arrow);
                temp = new Vector3(UpArrowEnd.transform.position.x, Up_Arrow.transform.position.y, 0);

                ////.Log("List added up arrow");
            }
            else if (noteChoice == 2)
            {
                listOfNotes.Add(Down_Arrow);
                temp = new Vector3(DownArrowEnd.transform.position.x, Down_Arrow.transform.position.y, 0);

                ////.Log("List added down arrow");
            }
            else if (noteChoice == 3)
            {
                listOfNotes.Add(Right_Arrow);
                temp = new Vector3(RightArrowEnd.transform.position.x, Right_Arrow.transform.position.y, 0);

                ////.Log("List added right arrow");
            }
        }

        return listOfNotes;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //Transfer to a different script for the Out-of-Bounds to hold.
        if (other.gameObject.CompareTag("UpArrow") || other.gameObject.CompareTag("DownArrow") || other.gameObject.CompareTag("LeftArrow") || other.gameObject.CompareTag("RightArrow"))
        {
            Destroy(other.gameObject);

            modifyQuality.UpdateQuality(-1);
            //scoreHelper.setMultiplier(false);
        }
    }

    //Destroys remaining arrows on screen upon a failed attempt
    public void DestroyArrows(GameObject[] arrowsArray)
    {
        for (int i = 0; i < arrowsArray.Length; i++)
        {
            Destroy(arrowsArray[i]);
            
        }
    }

    //When the food is served reset the quality to startingQuality;
    public void ResetQuality()
    {
        quality = qualityStart;
    }

    public int getQuality()
    {
        return quality;
    }

    public void UpdateQuality(int performance)
    {
        quality += performance;
        player.Play();
        if (quality > qualityMax)
        {
            quality = qualityMax;
        }

    }

    public IEnumerator ActivateGame()
    {
        move.enabled = false;
        MiniGameBG.SetActive(true);
        Out_Of_Bounds.SetActive(true);
        QualityMeter.SetActive(true);
        LeftArrowEnd.SetActive(true);
        UpArrowEnd.SetActive(true);
        DownArrowEnd.SetActive(true);
        RightArrowEnd.SetActive(true);

        StartCoroutine(Gamestart());
        yield return new WaitForSeconds(mgWaitTime);
    }//

    public void DeactivateMiniGame()
    {
        inter.failedanime();
        MiniGameBG.SetActive(false);
        Out_Of_Bounds.SetActive(false);
        QualityMeter.SetActive(false);
        LeftArrowEnd.SetActive(false);
        UpArrowEnd.SetActive(false);
        DownArrowEnd.SetActive(false);
        RightArrowEnd.SetActive(false);

        //If the day is NOT finished, re-enable movement.
        if (timeAccessor.dayDone != true)
        {
            move.enabled = true;
        }
    }

    //Return true if the user failed the minigame, false if the minigame was passed.
    public bool mgFailed()
    {
        return failedMG;
    }

    //Resets failedMG boolean to false (Player can retry minigame)
    public void ResetMG()
    {
        failedMG = false;
        destroyedArrows = false;
    }

    IEnumerator Gamestart()
    {
        //Randomizes game notes that will drop down
        notesList = randomizeNotes(numOfNotes[days.getDayNum() - 1]);

        ////.Log("Made it to Gamestart");
        for (int i = 0; i < numOfNotes[days.getDayNum() - 1]; i++)
        {
            yield return new WaitForSeconds(notePace[days.getDayNum() - 1]);
            GameObject gameObject = Instantiate(notesList[i]) as GameObject;
            if (notesList[i] == Left_Arrow)
            temp = new Vector3(LeftArrowEnd.transform.position.x, Left_Arrow.transform.position.y, 0);
            if (notesList[i] == Up_Arrow)
            temp = new Vector3(UpArrowEnd.transform.position.x, Up_Arrow.transform.position.y, 0);
            if (notesList[i] == Down_Arrow)
            temp = new Vector3(DownArrowEnd.transform.position.x, Down_Arrow.transform.position.y, 0);
            if (notesList[i] == Right_Arrow)
            temp = new Vector3(RightArrowEnd.transform.position.x, Right_Arrow.transform.position.y, 0);
            gameObject.transform.position = temp;

        }
        notesList.Clear();

        yield return new WaitForSeconds(2);

        DeactivateMiniGame();
    }


}
