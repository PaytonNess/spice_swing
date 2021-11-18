using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interaction : MonoBehaviour
{
    public movement move;
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
        move = GetComponent<movement>();
        colid = GetComponent<BoxCollider2D>();
        mini = GetComponent<minigame>();
        _anim = GetComponent<Animator>();
        orders = GetComponent<custumers>();
        order = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (orders != null)
        {
            if (orders.spriteRenderer0.enabled==true)
            {
                order = orders.pos[orders.another];
            }
        }
        switch (order)
        {
            case 3:
                //fishfry
                Debug.Log("fishfry");
                break;
            case 2:
                //gumbo
                Debug.Log("gumbo");

                break;
            case 1:
                //clam chowder
                Debug.Log("clam chowder");

                break;
            case 0:
                //avocado toast
                Debug.Log("toast");

                break;
            default:
                //Debug.Log("error");
                break;
        };
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        int regurallayer = _anim.GetLayerIndex("Base Layer");
        int rawlayer = _anim.GetLayerIndex("walking with raw");
        int layerfood = _anim.GetLayerIndex("walking with food");
        int M = _anim.GetLayerIndex("walkingM");
        int V = _anim.GetLayerIndex("walkingV");

        switch (order)
        {
            case 3:
                //fishfry
                needsM = true;
                needsV = true;
                needsG = false;
                Debug.Log("fishfry");
                break;
            case 2:
                //gumbo
                needsM = true;
                needsG = true;
                needsV = false;
                Debug.Log("gumbo");

                break;
            case 1:
                //clam chowder
                needsM = true;
                needsV = true;
                needsG = false;
                Debug.Log("clam chowder");

                break;
            case 0:
                //avocado toast
                needsG = true;
                needsV = true;
                needsM = false;
                Debug.Log("toast");

                break;
            default:
                //Debug.Log("error");
                break;
        };

        if (other.transform.tag == "cutting")
        {
            //for debug
            //mini.ActivateGame();
            switch (order)
            {
                case 3:
                    if (hasVeggie && !ischopped)
                    {
                        //call minigame
                        mini.ActivateGame();
                        //check minigame results
                        if (mini.mgFailed())
                        {
                            //The food did not get cooked.
                            
                            mini.ResetMG();
                            mini.ResetQuality();
                            hasVeggie = false;
                        }
                        else
                        {
                            //The food was successfully cooked
                            ischopped = true;
                        }
                    }
                    break;
                case 2:
                    //gumbo
                    if (hasMeat && !ischopped)
                    {
                        //call minigame
                        mini.ActivateGame();
                        //check minigame results
                        if (mini.mgFailed())
                        {
                            //The food did not get cooked.

                            mini.ResetMG();
                            mini.ResetQuality();
                            hasMeat = false;
                        }
                        else
                        {
                            //The food was successfully cooked
                            ischopped = true;
                        }
                    }
                    break;
                case 1:
                    //clam chowder
                    if ((hasMeat && needsM) || (hasVeggie && needsV))
                    {
                        //call minigame
                        mini.ActivateGame();
                        //check minigame results
                        if (mini.mgFailed())
                        {
                            //The food did not get cooked.
                            hasVeggie = false;
                            hasMeat = false;
                            mini.ResetMG();
                            mini.ResetQuality();
                        }
                        else
                        {
                            //The food was successfully cooked
                            //ischopped = true;
                            if (hasMeat)
                            {
                                needsM = false;
                            }
                            else
                            {
                                needsV = false;
                            }
                            if (prep)
                            {
                                prep = false;
                                ischopped = true;
                            }
                            else
                                prep = true;

                        }
                    }
                    break;
                case 0:
                    //avocado toast
                    if (hasGrain && !ischopped)
                    {
                        //call minigame
                        mini.ActivateGame();
                        //check minigame results
                        if (mini.mgFailed())
                        {
                            //The food did not get cooked.
                            hasGrain = false;
                            mini.ResetMG();
                            mini.ResetQuality();
                        }
                        else
                        {
                            //The food was successfully cooked
                            if (prep)
                            {
                                hasCookFood = true;
                            }
                            else
                                prep = true;
                            ischopped = true;
                        }
                        if (hasCookFood)
                        {
                            _anim.SetLayerWeight(M, -1);
                            _anim.SetLayerWeight(rawlayer, -1);
                            _anim.SetLayerWeight(V, -1);

                            _anim.SetLayerWeight(rawlayer, 0);
                            _anim.SetLayerWeight(layerfood, wieght);
                        }

                    }
                    if (hasVeggie && !ischopped)
                    {
                        //ischopped = true;
                        //call minigame
                        mini.ActivateGame();
                        //check minigame results
                        if (mini.mgFailed())
                        {
                            //The food did not get cooked.

                            mini.ResetMG();
                            mini.ResetQuality();
                        }
                        else
                        {
                            //The food was successfully cooked
                            if (prep)
                            {
                                hasCookFood = true;
                            }
                            else
                                prep = true;
                            ischopped = true;
                            needsV = false;
                        }
                       
                        if (hasCookFood)
                        {
                            _anim.SetLayerWeight(M, -1);
                            _anim.SetLayerWeight(rawlayer, -1);
                            _anim.SetLayerWeight(V, -1);

                            _anim.SetLayerWeight(rawlayer, 0);
                            _anim.SetLayerWeight(layerfood, wieght);
                        }
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
                        //call minigame
                        mini.ActivateGame();
                        //check minigame results
                        if (mini.mgFailed())
                        {
                            //The food did not get cooked.

                            mini.ResetMG();
                            mini.ResetQuality();
                        }
                        else
                        {
                            //The food was successfully cooked
                            if (halfCooked)
                            {
                                hasCookFood = true;
                                halfCooked = false;
                            }
                            else
                                halfCooked = true;
                            needsM = false;
                        }
                        hasMeat = false;
                        _anim.SetBool("raw", false);
                        _anim.SetBool("food", hasCookFood);
                        //mini.ActivateGame();
                        if (hasCookFood)
                        {
                            _anim.SetLayerWeight(M, -1);
                            _anim.SetLayerWeight(rawlayer, -1);
                            _anim.SetLayerWeight(V, -1);

                            _anim.SetLayerWeight(rawlayer, 0);
                            _anim.SetLayerWeight(layerfood, wieght);
                        }
                    }
                    if (hasVeggie && ischopped)
                    {
                        //call minigame
                        mini.ActivateGame();
                        //check minigame results
                        if (mini.mgFailed())
                        {
                            //The food did not get cooked.

                            mini.ResetMG();
                            mini.ResetQuality();
                        }
                        else
                        {
                            //The food was successfully cooked
                            if (halfCooked)
                            {
                                hasCookFood = true;
                                halfCooked = false;
                            }
                            else
                                halfCooked = true;
                            needsV = false;
                        }

                        hasVeggie = false;
                        ischopped = false;
                        //needsV = false;
                        _anim.SetBool("raw", hasMeat);
                        _anim.SetBool("food", hasCookFood);
                        //mini.ActivateGame();
                        if (hasCookFood)
                        {
                            _anim.SetLayerWeight(M, -1);
                            _anim.SetLayerWeight(rawlayer, -1);
                            _anim.SetLayerWeight(V, -1);

                            _anim.SetLayerWeight(rawlayer, 0);
                            _anim.SetLayerWeight(layerfood, wieght);
                        }
                    }
                    break;
                case 2:
                    if (hasGrain)
                    {

                        //gumbo
                        //call minigame
                        mini.ActivateGame();
                    //check minigame results
                    if (mini.mgFailed())
                    {
                        //The food did not get cooked.

                        mini.ResetMG();
                        mini.ResetQuality();
                    }
                    else
                    {
                        //The food was successfully cooked
                        if (halfCooked)
                        {
                            hasCookFood = true;
                            halfCooked = false;
                        }
                        else
                            halfCooked = true;
                        needsG = false;
                    }

                        hasGrain = false;
                        _anim.SetBool("raw", hasMeat);
                        _anim.SetBool("food", hasCookFood);
                        //mini.ActivateGame();
                        if (hasCookFood)
                        {
                            _anim.SetLayerWeight(M, -1);
                            _anim.SetLayerWeight(rawlayer, -1);
                            _anim.SetLayerWeight(V, -1);

                            _anim.SetLayerWeight(rawlayer, 0);
                            _anim.SetLayerWeight(layerfood, wieght);
                        }
                    }
                    if (hasMeat && ischopped)
                    {
                        //call minigame
                        mini.ActivateGame();
                        //check minigame results
                        if (mini.mgFailed())
                        {
                            //The food did not get cooked.

                            mini.ResetMG();
                            mini.ResetQuality();
                        }
                        else
                        {
                            //The food was successfully cooked
                            if (halfCooked)
                            {
                                hasCookFood = true;
                                halfCooked = false;
                            }
                            else
                                halfCooked = true;
                            needsM = false;
                        }



                        hasMeat = false;
                        ischopped = false;
                        //needsM = false;
                        _anim.SetBool("raw", hasMeat);
                        _anim.SetBool("food", hasCookFood);
                        //mini.ActivateGame();
                        if (hasCookFood)
                        {
                            _anim.SetLayerWeight(M, -1);
                            _anim.SetLayerWeight(rawlayer, -1);
                            _anim.SetLayerWeight(V, -1);

                            _anim.SetLayerWeight(rawlayer, 0);
                            _anim.SetLayerWeight(layerfood, wieght);
                        }

                    }
                    break;
                case 1:
                    //clam chowder
                    if ((hasMeat && (ischopped || prep)) || (hasVeggie && (ischopped || prep)))
                    {
                        //call minigame
                        mini.ActivateGame();
                        //check minigame results
                        if (mini.mgFailed())
                        {
                            //The food did not get cooked.

                            mini.ResetMG();
                            mini.ResetQuality();
                        }
                        else
                        {
                            //The food was successfully cooked
                            hasCookFood = true;

                            hasVeggie = false;
                            prep = false;
                            hasMeat = false;
                            ischopped = false;
                            needsM = false;
                            needsV = false;

                        }


                        //_anim.SetBool("raw", hasMeat);
                        //_anim.SetBool("food", hasCookFood);
                        //mini.ActivateGame();
                        if (hasCookFood)
                        {
                            _anim.SetLayerWeight(M, -1);
                            _anim.SetLayerWeight(rawlayer, -1);
                            _anim.SetLayerWeight(V, -1);

                            _anim.SetLayerWeight(rawlayer, 0);
                            _anim.SetLayerWeight(layerfood, wieght);
                        }
                    }
                    break;
                case 0:
                    //avocado toast
                    if (hasGrain && ischopped)
                    {
                                                //call minigame
                        mini.ActivateGame();
                        //check minigame results
                        if (mini.mgFailed())
                        {
                            //The food did not get cooked.

                            mini.ResetMG();
                            mini.ResetQuality();
                        }
                        else
                        {
                            //The food was successfully cooked
                            //hasCookFood = true;
                            if (halfCooked)
                            {
                                hasCookFood = true;
                                halfCooked = false;
                            }
                            else
                                halfCooked = true;
                            needsG = false;

                        }


                        hasGrain = false;
                        ischopped = false;
                        _anim.SetLayerWeight(M, -1);
                        //_anim.SetLayerWeight(rawlayer, -1);
                        _anim.SetLayerWeight(V, -1);

                        _anim.SetBool("raw", hasGrain);
                        _anim.SetBool("food", hasCookFood);
                        //mini.ActivateGame();
                        if (hasCookFood)
                        {
                            _anim.SetLayerWeight(M, -1);
                            _anim.SetLayerWeight(rawlayer, -1);
                            _anim.SetLayerWeight(V, -1);

                            _anim.SetLayerWeight(rawlayer, 0);
                            _anim.SetLayerWeight(layerfood, wieght);
                        }

                    }

                    break;
                default:
                    Debug.Log("error");
                    break;
            };
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
            hasVeggie = false;
            hasGrain = false;
            _anim.SetBool("raw", hasMeat);
            _anim.SetLayerWeight(regurallayer, -1);
            _anim.SetLayerWeight(V, -1);
            _anim.SetLayerWeight(rawlayer, -1);

            _anim.SetLayerWeight(M, wieght);
            _anim.SetBool("raw", hasMeat);

        }
        if (other.transform.tag == "Veggie" && needsV)
        {
            Debug.Log("has food");
            hasVeggie = true;
            hasMeat = false;
            hasGrain = false;

            _anim.SetBool("raw", hasVeggie);
            _anim.SetLayerWeight(regurallayer, -1);
            _anim.SetLayerWeight(M, -1);
            _anim.SetLayerWeight(rawlayer, -1);

            _anim.SetLayerWeight(V, wieght);

            _anim.SetBool("raw", hasVeggie);

        }
        if (other.transform.tag == "Grain" && needsG)
        {
            Debug.Log("has food");
            hasGrain = true;
            hasVeggie = false;
            hasMeat = false;

            _anim.SetBool("raw", hasGrain);
            _anim.SetLayerWeight(regurallayer, -1);
            _anim.SetLayerWeight(V, -1);
            _anim.SetLayerWeight(M, -1);
            _anim.SetLayerWeight(rawlayer, wieght);
            _anim.SetBool("raw", hasGrain);

        }
        if (other.transform.tag == "serve")
        {

            // check if player has cook food
            if (hasCookFood)
            {
                mini.ResetMG();
                mini.ResetQuality();
                hasGrain = false;
                hasMeat = false;
                hasVeggie = false;
                hasCookFood = false;
                _anim.SetBool("food", hasCookFood);
                Debug.Log("served food");
                //custumers orders = other.gameObject.GetComponent<custumers>();
                orders.leave();
                _anim.SetLayerWeight(M, -1);
                _anim.SetLayerWeight(rawlayer, -1);
                _anim.SetLayerWeight(V, -1);
                _anim.SetLayerWeight(regurallayer, wieght);

            }
        }
    }
}

