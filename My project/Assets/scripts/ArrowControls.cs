using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowControls : MonoBehaviour
{
    public bool canBeHit;

    public GameObject scriptHolder;
    public GameObject uiScript;
    public minigame callMinigame;
    public scoring scoreChanger;
    // Update is called once per frame

    void Start()
    {
        canBeHit = false;

        scriptHolder = GameObject.Find("character");
        callMinigame = scriptHolder.GetComponent<minigame>();
        uiScript = GameObject.Find("UI Holder");
        scoreChanger = uiScript.GetComponent<scoring>();
    }

    void Update()
    {
        if (canBeHit)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && this.gameObject.tag == "LeftArrow")
            {
                Destroy(this.gameObject);
                callMinigame.UpdateQuality(1);

                scoreChanger.setScore(100);
                scoreChanger.setMultiplier(true);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) && this.gameObject.tag == "UpArrow")
            {
                Destroy(this.gameObject);
                callMinigame.UpdateQuality(1);

                scoreChanger.setScore(100);
                scoreChanger.setMultiplier(true);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && this.gameObject.tag == "DownArrow")
            {
                Destroy(this.gameObject);
                callMinigame.UpdateQuality(1);

                scoreChanger.setScore(100);
                scoreChanger.setMultiplier(true);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && this.gameObject.tag == "RightArrow")
            {
                Destroy(this.gameObject);
                callMinigame.UpdateQuality(1);

                scoreChanger.setScore(100);
                scoreChanger.setMultiplier(true);
            }
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Input Area")
        {
            canBeHit = true;
            Debug.Log("An arrow is in the zone!");
        }

        if (other.tag == "Out_Of_Bounds")
        {
            Destroy(this.gameObject);
            callMinigame.UpdateQuality(-1);
        }
    }

    //Implement to where a bool is used to check when a note enter/leaves the zone, so an input can be made to a note within a zone to improve food quality
    void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag == "Input Area")
        {
            canBeHit = false;
            Debug.Log("An arrow is leaving the zone.");
        }
    }
}
