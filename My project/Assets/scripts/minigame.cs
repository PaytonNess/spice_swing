using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minigame : MonoBehaviour
{
    public GameObject Up_Arrow;
    public GameObject Down_Arrow;
    public GameObject Left_Arrow;
    public GameObject Right_Arrow;
    public GameObject minigameBG;
    public GameObject keyPressZone;
    public GameObject outOfBounds;


    public int dayNum = 1; //Holds day of week number
    public int quality = 3; //quality starts at 3; Max value of 10
    public int qualityMax = 10;
    public List<string> notesList;

    //Set number of notes needed per day
    private int[] numOfNotes = { 3, 5, 6, 10, 12 };

    //Assortment of notes that players may need to hit for the mini-game
    private string[] inputSelections = { "a", "w", "s", "d" };

    //The pace at which notes fall down
    private float[] notePace = { 2.0f, 1.75f, 1.5f, 1.25f, 1.0f };


    // Start is called before the first frame update
    void Start()
    {
        GameObject[] arrowOptions = { Left_Arrow, Up_Arrow, Down_Arrow, Right_Arrow };
        //Set number of notes in mini game.
        notesList = randomizeNotes(numOfNotes[dayNum - 1]);

        minigameBG.SetActive(true);
        keyPressZone.SetActive(true);
        outOfBounds.SetActive(true);

        if (minigameBG.activeSelf)
        {
            Debug.Log("The minigame background is active.");
        }
        //Needs to setActive objects above
    }

    // Update is called once per frame

    
    void Update()
    {
        //If quality meter reaches 0, the dish is failed
        if (getQuality() <= 0)
        {
            //Queue fail sequence
        }

    }

    int getQuality()
    {
        return quality;
    }

    List<string> randomizeNotes(int numNotes)
    {
        //List is created to hold set of randomized notes
        List<string> listOfNotes = null;

        //Loop continues until listOfNotes has appropriated number of notes for the mini-game
        while (listOfNotes.Capacity < numOfNotes[dayNum - 1])
        {

            listOfNotes.Add(inputSelections[(int)(Random.Range(0.0f, inputSelections.Length))]);
        }

        return listOfNotes;
    }

    void OnTriggerEnter(Collider other)
    {
        minigameBG.SetActive(true);
        keyPressZone.SetActive(true);
        outOfBounds.SetActive(true);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("UpArrow") || other.gameObject.CompareTag("DownArrow") || other.gameObject.CompareTag("LeftArrow") || other.gameObject.CompareTag("RightArrow"))
        {
            DestroyArrows(other.gameObject);
        }
    }

    void DestroyArrows(GameObject arrow)
    {
        Destroy(arrow);
    }


    /*
    void UpdateQuality("Cooking performance")
    {
        if ("Cooking performance is good")
        {
            quality++;
        }
        else if ("Cooking performance is bad")
        {
            quality--;
        }
        
    }
    */

    /*void ActivateGame(GameObject[] arrowOptions)
    {
        minigameBG.SetActive(true);
        keyPressZone.SetActive(true);
        outOfBounds.SetActive(true);
        
        for(int i = 0; i < numOfNotes[dayNum-1]; i++)
        {

            Instantiate(arrowOptions[(int)Random.Range(0.0f, arrowOptions.length)]) as GameObject;
        }
    }*/
}