using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interaction : MonoBehaviour
{
    public bool hasMeat = false;
    public bool hasGrain = false;
    public bool hasVeggie = false;
    public bool hasFood = false;
    
    //needs to implement recipes
    public bool hasCookFood = false;
    private BoxCollider2D colid;
    private minigame mini;
    private Animator _anim;
    private custumers orders;
    public bool halfCooked = false;
    // Start is called before the first frame update
    void Start()
    {
        colid = GetComponent<BoxCollider2D>();
        mini = GetComponent<minigame>();
        _anim = GetComponent<Animator>();
        orders = GetComponent<custumers>();
    }

    // Update is called once per frame
    void Update()
    {
     /*   switch (orders.pos[orders.another].getOrder())
        {
            case 3:
                
                break;
            case 2:
                
                break;
            case 1:
                
                break;
            case 0:
                break;
            default:
                Debug.Log("error");
                break;
        } */
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        int regurallayer = _anim.GetLayerIndex("Base Layer"); ;
        int rawlayer = _anim.GetLayerIndex("walking with raw"); ;
        int layerfood = _anim.GetLayerIndex("walking with food"); ;
        float wieght = 1f; 
       
        if (other.transform.tag == "cooking")
        {
            if (hasFood)
            {
                //call minigame
                //check minigame results
                hasCookFood = true;
                Debug.Log("cooked food");
                hasFood = false;
                _anim.SetBool("raw", hasFood);
                _anim.SetBool("food", hasCookFood);
                //mini.ActivateGame();
                _anim.SetLayerWeight(rawlayer, 0);
                _anim.SetLayerWeight(layerfood, wieght);

            }
        }
        if (other.transform.tag == "ingredents")
        {
            Debug.Log("has food");
            hasFood = true;
            _anim.SetLayerWeight(regurallayer, -1);
            _anim.SetLayerWeight(rawlayer, wieght);
            _anim.SetBool("raw", hasFood);
        }
        if (other.transform.tag == "Meat")
        {
            Debug.Log("has food");
            hasMeat = true;
            _anim.SetBool("raw", hasFood);
        }
        if (other.transform.tag == "Veggie")
        {
            Debug.Log("has food");
            hasVeggie = true;
            _anim.SetBool("raw", hasFood);
        }
        if (other.transform.tag == "Grain")
        {
            Debug.Log("has food");
            hasGrain = true;
            _anim.SetBool("raw", hasFood);
        }
        if (other.transform.tag == "serve")
        {
            
            // check if player has cook food
            if (hasCookFood)
            {
                hasCookFood = false;
                _anim.SetBool("food", hasCookFood);
                Debug.Log("served food");
                custumers orders = other.gameObject.GetComponent<custumers>();
                orders.leave();
                _anim.SetLayerWeight(layerfood, 0);
                _anim.SetLayerWeight(regurallayer, wieght);

            }
        }
    }
}

