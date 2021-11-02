using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class minigame : MonoBehaviour
{
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
    public minigame modifyQuality;

    public int quality;
    public int qualityStart = 3; //quality starts at 3; Max value of 10
    public int qualityMax = 10;
    private int dayNum = 2; //Holds day of week number


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
        quality = 3;
        //Set number of notes in mini game.

        scriptHolder = GameObject.Find("character");
        modifyQuality = scriptHolder.GetComponent<minigame>();
    }

    // Update is called once per frame
    void Update()
    {

        //TODO: If quality meter reaches 0, the dish is failed [Not implemented yet]
        if (getQuality() <= 0 && destroyedArrows == false)
        {
            GameObject[] arrowsGenerated;

            destroyedArrows = true;
            Debug.Log("MG Failed");
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
                Debug.Log("List added left arrow");
            }
            else if (noteChoice == 1)
            {
                listOfNotes.Add(Up_Arrow);
                Debug.Log("List added up arrow");
            }
            else if (noteChoice == 2)
            {
                listOfNotes.Add(Down_Arrow);
                Debug.Log("List added down arrow");
            }
            else if (noteChoice == 3)
            {
                listOfNotes.Add(Right_Arrow);
                Debug.Log("List added right arrow");
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

        if (quality > qualityMax)
        {
            quality = qualityMax;
        }

    }

    public void ActivateGame()
    {
        MiniGameBG.SetActive(true);
        Out_Of_Bounds.SetActive(true);
        QualityMeter.SetActive(true);
        LeftArrowEnd.SetActive(true);
        UpArrowEnd.SetActive(true);
        DownArrowEnd.SetActive(true);
        RightArrowEnd.SetActive(true);

        StartCoroutine(Gamestart());

    }

    void DeactivateMiniGame()
    {
        MiniGameBG.SetActive(false);
        Out_Of_Bounds.SetActive(false);
        QualityMeter.SetActive(false);
        LeftArrowEnd.SetActive(false);
        UpArrowEnd.SetActive(false);
        DownArrowEnd.SetActive(false);
        RightArrowEnd.SetActive(false);
    }

    //Return true if the user failed the minigame, false if the minigame was passed.
    public bool mgFailed()
    {
        return failedMG;
    }

    public void ResetMG()
    {
        failedMG = false;
    }

    //TODO: Add check to see (if success, then part of recipe is complete.)
    IEnumerator Gamestart()
    {
        //Randomizes game notes that will drop down
        notesList = randomizeNotes(numOfNotes[dayNum - 1]);

        Debug.Log("Made it to Gamestart");
        for (int i = 0; i < numOfNotes[dayNum - 1]; i++)
        {
            yield return new WaitForSeconds(notePace[dayNum - 1]);
            GameObject gameObject = Instantiate(notesList[i]) as GameObject;
        }
        notesList.Clear();

        yield return new WaitForSeconds(5);

        DeactivateMiniGame();
    }


}
