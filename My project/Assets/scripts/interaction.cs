using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interaction : MonoBehaviour
{
    private bool hasFood = false;
    //needs to implement recipes
    private bool hasCookFood = false;
    private BoxCollider2D colid;
    private minigame mini;

    // Start is called before the first frame update
    void Start()
    {
        colid = GetComponent<BoxCollider2D>();
        mini = GetComponent<minigame>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "cooking")
        {
            if (hasFood)
            {
                //call minigame
                //check minigame results
                hasCookFood = true;
                Debug.Log("cooked food");
                hasFood = false;
                //mini.ActivateGame()
            }
        }
        if (other.transform.tag == "ingredents")
        {
            Debug.Log("has food");
            hasFood = true;
        }
        if (other.transform.tag == "serve")
        {
            
            // check if player has cook food
            if (hasCookFood)
            {
                hasCookFood = false;
                Debug.Log("served food");
                custumers orders = other.gameObject.GetComponent<custumers>();
                orders.leave();
            }
        }
    }
}

