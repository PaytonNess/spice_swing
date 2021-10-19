using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class minigame : MonoBehaviour
{
    public GameObject Up_Arrow;
    public GameObject Down_Arrow;
    public GameObject Left_Arrow;
    public GameObject Right_Arrow;
    public GameObject minigameBG;
    public GameObject leftPressZone;
    public GameObject upPressZone;
    public GameObject downPressZone;
    public GameObject rightPressZone;
    public GameObject outOfBounds;
    public GameObject qualityMeter;

    public GameObject scriptHolder;
    public startMiniGame theScript;
    public GameObject scriptHolder2;
    public minigame modifyQuality;

    public int quality;
    public int qualityStart = 3; //quality starts at 3; Max value of 10
    public int qualityMax = 10;
    private int dayNum = 1; //Holds day of week number
    private bool startArrowSpawns = true;

    //Set number of notes needed per day
    private int[] numOfNotes = { 3, 5, 6, 10, 12 };


    //The pace at which notes fall down
    private float[] notePace = { 2.0f, 1.75f, 1.5f, 1.25f, 1.0f };


    private List<GameObject> notesList;
    // Start is called before the first frame update
    void Start()
    {

        //Set number of notes in mini game.
        notesList = randomizeNotes(numOfNotes[dayNum - 1]);

        scriptHolder = GameObject.Find("CookingArea");
        theScript = scriptHolder.GetComponent<startMiniGame>();

        scriptHolder2 = GameObject.Find("MiniGameBG");
        modifyQuality = scriptHolder2.GetComponent<minigame>();
        quality = qualityStart;

    }

    // Update is called once per frame
    void Update()
    {
        if (startArrowSpawns && minigameBG.activeSelf)
        {
            //Activates arrow spawning once per time the player is in the game.
            startArrowSpawns = false;
            ActivateGame();
        }

        //If quality meter reaches 0, the dish is failed [Not implemented yet]
        if (getQuality() < 1)
        {
            DeactivateMiniGame();
        }
    }

    public int getQuality()
    {
        return quality;
    }

    List<GameObject> randomizeNotes(int numNotes)
    {
        //List is created to hold set of randomized notes
        List<GameObject> listOfNotes = new List<GameObject>();

        //Loop continues until listOfNotes has appropriated number of notes for the mini-game
        for (int i = 0; i < numNotes; i++)
        {

            int noteChoice = (int)Random.Range(0.0f, 4.0f);
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
        if (other.gameObject.CompareTag("UpArrow") || other.gameObject.CompareTag("DownArrow") || other.gameObject.CompareTag("LeftArrow") || other.gameObject.CompareTag("RightArrow"))
        {
            DestroyArrows(other.gameObject);

            modifyQuality.UpdateQuality(-1);
        }
    }

    void DestroyArrows(GameObject arrow)
    {
        Destroy(arrow);
    }



    public void UpdateQuality(int performance)
    {
        quality += performance;

        if (quality > qualityMax)
        {
            quality = qualityMax;
        }

    }

    void ActivateGame()
    {
        if (minigameBG.activeSelf)
        {
            StartCoroutine(Gamestart());
        }
    }

    void DeactivateMiniGame()
    {
        theScript.setActivateObjects(false);
    }

    IEnumerator Gamestart()
    {
        Debug.Log("Made it to Gamestart");
        for (int i = 0; i < numOfNotes[dayNum - 1]; i++)
        {
            yield return new WaitForSeconds(notePace[dayNum - 1]);
            GameObject gameObject = Instantiate(notesList[i]) as GameObject;
            Debug.Log("An arrow has been created");

        }
        notesList.RemoveRange(0, numOfNotes[dayNum - 1] - 1);
        yield return new WaitForSeconds(5);

        DeactivateMiniGame();
    }
}
