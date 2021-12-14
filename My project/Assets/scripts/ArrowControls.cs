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
    public Rigidbody2D rb;

    void Start()
    {
        canBeHit = false;
      
        scriptHolder = GameObject.Find("character");
        callMinigame = scriptHolder.GetComponent<minigame>();
        uiScript = GameObject.Find("UI Holder");
        scoreChanger = uiScript.GetComponent<scoring>();
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = new Vector2(0, -1);
    }

    void Update()
    {
        if (canBeHit)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && this.gameObject.tag == "LeftArrow")
            {
                //.Play();
                Destroy(this.gameObject);
                callMinigame.UpdateQuality(1);
                ////.Play();
                scoreChanger.setScore(100);
                //scoreChanger.setMultiplier(true);
                Debug.Log("asdfjiodsjifkdsaik");
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) && this.gameObject.tag == "UpArrow")
            {
                //.Play();
                Destroy(this.gameObject);
                callMinigame.UpdateQuality(1);            
                scoreChanger.setScore(100);
                //scoreChanger.setMultiplier(true);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && this.gameObject.tag == "DownArrow")
            {
                //.Play();
                Destroy(this.gameObject);
                callMinigame.UpdateQuality(1);
                ////.Play();
                Debug.Log("asdfjiodsjifkdsaik");

                scoreChanger.setScore(100);
                //scoreChanger.setMultiplier(true);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && this.gameObject.tag == "RightArrow")
            {
                //.Play();
                Destroy(this.gameObject);
                callMinigame.UpdateQuality(1);
                Debug.Log("asdfjiodsjifkdsaik");


                scoreChanger.setScore(100);
                //scoreChanger.setMultiplier(true);
            }
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Input Area")
        {
            canBeHit = true;
            //.Log("An arrow is in the zone!");
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
            //.Log("An arrow is leaving the zone.");
        }
    }
}
