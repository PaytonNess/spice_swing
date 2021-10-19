using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowControls : MonoBehaviour
{
    public bool canBeHit;

    public GameObject scriptHolder;
    public minigame modifyQuality;
    // Update is called once per frame

    void Start()
    {
        canBeHit = false;

        scriptHolder = GameObject.Find("MiniGameBG");
        modifyQuality = scriptHolder.GetComponent<minigame>();

    }

    void Update()
    {
        if (canBeHit)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Destroy(this.gameObject);
                modifyQuality.UpdateQuality(1);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Destroy(this.gameObject);
                modifyQuality.UpdateQuality(1);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Destroy(this.gameObject);
                modifyQuality.UpdateQuality(1);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Destroy(this.gameObject);
                modifyQuality.UpdateQuality(1);
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
