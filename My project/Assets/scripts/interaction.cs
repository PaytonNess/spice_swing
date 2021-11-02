using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interaction : MonoBehaviour
{
    public bool hasMeat = false;
    public bool hasGrain = false;
    public bool hasVeggie = false;
    public bool hasFood = false;
    private int order;
    //needs to implement recipes
    public bool hasCookFood = false;
    private BoxCollider2D colid;
    private minigame mini;
    private Animator _anim;
    private custumers orders;
    public bool halfCooked = false;
    bool ischopped = false;
    float wieght = 1f;
    bool needsM = false;
    bool needsV = false;
    bool prep = false;
    bool needsG = false;
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
        if (orders != null)
        {
            if (orders.pos != null)
            {
                order = orders.pos[orders.another].getOrder();
            }
        }
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
        int regurallayer = _anim.GetLayerIndex("Base Layer");
        int rawlayer = _anim.GetLayerIndex("walking with raw");
        int layerfood = _anim.GetLayerIndex("walking with food");
        switch (order)
        {
            case 3:
                //fishfry
                needsM = true;
                needsV = true;
                needsG = false;
                break;
            case 2:
                //gumbo
                needsM = true;
                needsG = true;
                needsV = false;
                break;
            case 1:
                //clam chowder
                needsM = true;
                needsV = true;
                needsG = false;
                break;
            case 0:
                //avocado toast
                needsG = true;
                needsV = true;
                needsM = false;
                break;
            default:
                Debug.Log("error");
                break;
        };

        if (other.transform.tag == "cutting")
        {
            //for debug
            mini.ActivateGame();
            switch (order)
            {
                case 3:
                    if (hasVeggie)
                    {
                        ischopped = true;
                        _anim.SetBool("raw", hasMeat);
                        _anim.SetBool("food", hasCookFood);
                        //mini.ActivateGame();
                        _anim.SetLayerWeight(rawlayer, 0);
                        _anim.SetLayerWeight(layerfood, wieght);

                    }
                    break;
                case 2:
                    //gumbo
                    if (hasMeat)
                    {
                        ischopped = true;

                        _anim.SetBool("raw", hasMeat);
                        _anim.SetBool("food", hasCookFood);
                        //mini.ActivateGame();
                        _anim.SetLayerWeight(rawlayer, 0);
                        _anim.SetLayerWeight(layerfood, wieght);
                    }
                    break;
                case 1:
                    //clam chowder
                    if ((hasMeat || prep))
                    {
                        if (prep)
                        {
                            prep = false;
                            ischopped = true;
                        }
                        else
                            prep = true;

                        _anim.SetBool("raw", hasFood);
                        _anim.SetBool("food", hasCookFood);
                        //mini.ActivateGame();
                        _anim.SetLayerWeight(rawlayer, 0);
                        _anim.SetLayerWeight(layerfood, wieght);

                    }
                    break;
                case 0:
                    //avocado toast
                    if (hasGrain && !ischopped)
                    {
                        ischopped = true;
                        if (prep)
                        {
                            hasCookFood = true;
                        }
                        else
                            prep = true;
                        _anim.SetBool("raw", hasMeat);
                        _anim.SetBool("food", hasCookFood);
                        //mini.ActivateGame();
                        _anim.SetLayerWeight(rawlayer, 0);
                        _anim.SetLayerWeight(layerfood, wieght);

                    }
                    if (hasVeggie)
                    {
                        ischopped = true;
                        if (prep)
                        {
                            hasCookFood = true;
                        }
                        else
                            prep = true;
                        _anim.SetBool("raw", hasMeat);
                        _anim.SetBool("food", hasCookFood);
                        //mini.ActivateGame();
                        _anim.SetLayerWeight(rawlayer, 0);
                        _anim.SetLayerWeight(layerfood, wieght);

                    }
                    break;
                default:
                    Debug.Log("error");
                    break;
            };
        }
        if (other.transform.tag == "cooking")
        {
            switch (order)
            {
                case 3:
                    if (hasMeat)
                    {
                        //fishfry 
                        if (halfCooked)
                        {
                            hasCookFood = true;
                            halfCooked = false;
                        }
                        else
                            halfCooked = true;
                        needsM = false;
                        hasMeat = false;
                        _anim.SetBool("raw", hasMeat);
                        _anim.SetBool("food", hasCookFood);
                        //mini.ActivateGame();
                        _anim.SetLayerWeight(rawlayer, 0);
                        _anim.SetLayerWeight(layerfood, wieght);
                    }
                    if (hasVeggie && ischopped)
                    {
                        if (halfCooked)
                        {
                            hasCookFood = true;
                            halfCooked = false;
                        }
                        else
                            halfCooked = true;

                        hasVeggie = false;
                        ischopped = false;
                        needsV = false;
                        _anim.SetBool("raw", hasMeat);
                        _anim.SetBool("food", hasCookFood);
                        //mini.ActivateGame();
                        _anim.SetLayerWeight(rawlayer, 0);
                        _anim.SetLayerWeight(layerfood, wieght);

                    }
                    break;
                case 2:
                    //gumbo
                    if (hasGrain)
                    {
                        //fishfry 
                        if (halfCooked)
                        {
                            hasCookFood = true;
                            halfCooked = false;
                        }
                        else
                            halfCooked = true;
                        needsG = false;
                        hasGrain = false;
                        _anim.SetBool("raw", hasMeat);
                        _anim.SetBool("food", hasCookFood);
                        //mini.ActivateGame();
                        _anim.SetLayerWeight(rawlayer, 0);
                        _anim.SetLayerWeight(layerfood, wieght);
                    }
                    if (hasMeat && ischopped)
                    {
                        if (halfCooked)
                        {
                            hasCookFood = true;
                            halfCooked = false;
                        }
                        else
                            halfCooked = true;

                        hasMeat = false;
                        ischopped = false;
                        needsM = false;
                        _anim.SetBool("raw", hasMeat);
                        _anim.SetBool("food", hasCookFood);
                        //mini.ActivateGame();
                        _anim.SetLayerWeight(rawlayer, 0);
                        _anim.SetLayerWeight(layerfood, wieght);

                    }
                    break;
                case 1:
                    //clam chowder
                    if ((hasMeat && ischopped && prep) || (hasVeggie && ischopped && prep))
                    {
                        hasCookFood = true;

                        hasVeggie = false;
                        prep = false;
                        hasMeat = false;
                        ischopped = false;
                        needsM = false;
                        needsV = false;
                        _anim.SetBool("raw", hasMeat);
                        _anim.SetBool("food", hasCookFood);
                        //mini.ActivateGame();
                        _anim.SetLayerWeight(rawlayer, 0);
                        _anim.SetLayerWeight(layerfood, wieght);

                    }
                    break;
                case 0:
                    //avocado toast
                    if (hasGrain && ischopped)
                    {
                        if (halfCooked)
                        {
                            hasCookFood = true;
                            halfCooked = false;
                        }
                        else
                            halfCooked = true;

                        hasGrain = false;
                        ischopped = false;
                        needsG = false;
                        _anim.SetBool("raw", hasMeat);
                        _anim.SetBool("food", hasCookFood);
                        //mini.ActivateGame();
                        _anim.SetLayerWeight(rawlayer, 0);
                        _anim.SetLayerWeight(layerfood, wieght);

                    }

                    break;
                default:
                    Debug.Log("error");
                    break;
            };
            //if (hasFood && ((order == 0 && hasGrain && ischopped) ||
            //    (order == 1 && ischopped) || (order == 2 && ischopped && hasMeat) ||
            //    (order == 2 && hasGrain) || (order == 3 && hasMeat) || (order == 3 && ischopped)))
            //{
            //    //call minigame
            //    //check minigame results
            //    if (halfCooked)
            //    {
            //        hasCookFood = true;
            //        halfCooked = false;
            //    }
            //    else
            //        halfCooked = true;

            //    hasMeat = false;
            //    hasVeggie = false;
            //    hasGrain = false;
            //    Debug.Log("cooked food");
            //    hasFood = false;
            //    _anim.SetBool("raw", hasFood);
            //    _anim.SetBool("food", hasCookFood);
            //    //mini.ActivateGame();
            //    _anim.SetLayerWeight(rawlayer, 0);
            //    _anim.SetLayerWeight(layerfood, wieght);

            //}
        }
        if (other.transform.tag == "ingredents")
        {
            Debug.Log("has food");
            hasFood = true;
            _anim.SetLayerWeight(regurallayer, -1);
            _anim.SetLayerWeight(rawlayer, wieght);
            _anim.SetBool("raw", hasFood);
        }
        if (other.transform.tag == "Meat" && needsM)
        {
            Debug.Log("has food");
            hasMeat = true;
            _anim.SetBool("raw", hasFood);
            _anim.SetLayerWeight(regurallayer, -1);
            _anim.SetLayerWeight(rawlayer, wieght);
            _anim.SetBool("raw", hasFood);

        }
        if (other.transform.tag == "Veggie" && needsV)
        {
            Debug.Log("has food");
            hasVeggie = true;
            _anim.SetBool("raw", hasFood);
            _anim.SetLayerWeight(regurallayer, -1);
            _anim.SetLayerWeight(rawlayer, wieght);
            _anim.SetBool("raw", hasFood);

        }
        if (other.transform.tag == "Grain" && needsG)
        {
            Debug.Log("has food");
            hasGrain = true;
            _anim.SetBool("raw", hasFood);
            _anim.SetLayerWeight(regurallayer, -1);
            _anim.SetLayerWeight(rawlayer, wieght);
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

