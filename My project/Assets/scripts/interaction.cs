using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class interaction : MonoBehaviour
{
    [SerializeField] public GameObject fishanimate1;
    [SerializeField] public GameObject fisganimate2;
    [SerializeField] public GameObject fishanimate3;

    [SerializeField] public GameObject gumboanime1;
    [SerializeField] public GameObject gumboanime2;
    [SerializeField] public GameObject gumboanime3;

    [SerializeField] public GameObject clamchowder1;
    [SerializeField] public GameObject clamchowder2;
    [SerializeField] public GameObject clamchowder3;

    [SerializeField] public GameObject tast1;
    [SerializeField] public GameObject tast2;
    [SerializeField] public GameObject tast3;

    [SerializeField] public GameObject recipe1;
    [SerializeField] public GameObject recipe2;
    [SerializeField] public GameObject recipe3;
    [SerializeField] public GameObject recipe4;

    [SerializeField] public GameObject button1;
    [SerializeField] public GameObject button2;
    [SerializeField] public GameObject button3;
    [SerializeField] public GameObject button4;
    [SerializeField] public GameObject button5;
    [SerializeField] public GameObject button6;

    private movement move;
    private bool hasMeat = false;
    private bool hasGrain = false;
    private bool hasVeggie = false;
    private bool hasFood = false;
    private int order;
    //needs to implement recipes
    private bool hasCookFood = false;
    private BoxCollider2D colid;
    private minigame mini;
    private Animator _anim;
    private custumers orders;
    private bool halfCooked = false;
    private bool ischopped = false;
    private float wieght = 1f;
    private bool needsM = false;
    private bool needsV = false;
    private bool prep = false;
    private bool needsG = false;
    // Start is called before the first frame update
    void Start()
    {
        move = GetComponent<movement>();
        colid = GetComponent<BoxCollider2D>();
        mini = GetComponent<minigame>();
        _anim = GetComponent<Animator>();
        orders = GetComponent<custumers>();
        order = -1;
        recipe1.SetActive(false);
        recipe2.SetActive(false);
        recipe3.SetActive(false);
        recipe4.SetActive(false);

        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        button4.SetActive(false);
        button5.SetActive(false);
        button6.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (orders != null)
        {
            if (orders.spriteRenderer0.enabled == true)
            {
                order = orders.pos[orders.another];
            }
        }
        switch (order)
        {
            case 3:
                //fishfry
                Debug.Log("fishfry");
                recipe1.SetActive(false);
                recipe2.SetActive(false);
                recipe3.SetActive(false);
                recipe4.SetActive(true);
                break;
            case 2:
                //gumbo
                Debug.Log("gumbo");
                recipe1.SetActive(false);
                recipe2.SetActive(false);
                recipe3.SetActive(true);
                recipe4.SetActive(false);

                break;
            case 1:
                //clam chowder
                Debug.Log("clam chowder");
                recipe1.SetActive(false);
                recipe2.SetActive(true);
                recipe3.SetActive(false);
                recipe4.SetActive(false);

                break;
            case 0:
                //avocado toast
                Debug.Log("toast");
                recipe1.SetActive(true);
                recipe2.SetActive(false);
                recipe3.SetActive(false);
                recipe4.SetActive(false);

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
                        fishanimate1.SetActive(true);
                        mini.ActivateGame();
                        //check minigame results
                        if (mini.mgFailed())
                        {
                            //The food did not get cooked.

                            button3.SetActive(false);
                            mini.ResetMG();
                            mini.ResetQuality();
                            hasVeggie = false;
                        }
                        else
                        {
                            //The food was successfully cooked
                            ischopped = true;
                            button4.SetActive(true);
                        }
                        fishanimate1.SetActive(false);
                    }
                    break;
                case 2:
                    //gumbo
                    if (hasMeat && !ischopped)
                    {
                        //call minigame
                        gumboanime1.SetActive(true);
                        mini.ActivateGame();
                        //check minigame results
                        if (mini.mgFailed())
                        {
                            //The food did not get cooked.

                            button1.SetActive(false);
                            mini.ResetMG();
                            mini.ResetQuality();
                            hasMeat = false;
                        }
                        else
                        {
                            //The food was successfully cooked
                            ischopped = true;
                            button2.SetActive(true);

                        }
                        gumboanime1.SetActive(false);
                    }
                    break;
                case 1:
                    //clam chowder
                    if ((hasMeat && needsM) || (hasVeggie && needsV))
                    {
                        //call minigame
                        if (hasMeat)
                            clamchowder1.SetActive(true);
                        if (hasVeggie)
                            clamchowder2.SetActive(true); 
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
                                button2.SetActive(true);
                            }
                            else
                            {
                                needsV = false;
                                button4.SetActive(true);
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
                    clamchowder1.SetActive(false);
                    clamchowder2.SetActive(false);
                    break;
                case 0:
                    //avocado toast
                    if (hasGrain && !ischopped)
                    {
                        //call minigame
                        tast1.SetActive(true);
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
                            button2.SetActive(true);
                        }
                        tast1.SetActive(false);
                        if (hasCookFood)
                        {
                            _anim.SetLayerWeight(M, 0);
                            _anim.SetLayerWeight(rawlayer, 0);
                            _anim.SetLayerWeight(V, 0);
                            _anim.SetLayerWeight(M, 0);
                            _anim.SetLayerWeight(rawlayer, 0);
                            _anim.SetLayerWeight(V, 0);

                            _anim.SetLayerWeight(rawlayer, 0);
                            _anim.SetLayerWeight(layerfood, wieght);
                        }

                    }
                    if (hasVeggie && !ischopped)
                    {
                        tast3.SetActive(true);
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
                            button5.SetActive(true);
                        }
                        tast3.SetActive(false);
                        if (hasCookFood)
                        {
                            _anim.SetLayerWeight(M, 0);
                            _anim.SetLayerWeight(rawlayer, 0);
                            _anim.SetLayerWeight(V, 0);
                            _anim.SetLayerWeight(M, 0);
                            _anim.SetLayerWeight(rawlayer, 0);
                            _anim.SetLayerWeight(V, 0);

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
                        fishanimate3.SetActive(true);
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
                            button2.SetActive(true);
                        }
                        fishanimate3.SetActive(false);
                        //hasMeat = false;
                        //hasMeat = false;
                        _anim.SetBool("raw", false);
                        _anim.SetBool("food", hasCookFood);
                        //mini.ActivateGame();
                        if (hasCookFood)
                        {
                            _anim.SetLayerWeight(M, 0);
                            _anim.SetLayerWeight(rawlayer, 0);
                            _anim.SetLayerWeight(V, 0);
                            _anim.SetLayerWeight(M, 0);
                            _anim.SetLayerWeight(rawlayer, 0);
                            _anim.SetLayerWeight(V, 0);

                            _anim.SetLayerWeight(rawlayer, 0);
                            _anim.SetLayerWeight(layerfood, wieght);
                        }
                    }
                    if (hasVeggie && ischopped)
                    {
                        fisganimate2.SetActive(true);
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
                            button5.SetActive(true);
                        }
                        fisganimate2.SetActive(false);
                        //hasVeggie = false;
                        ischopped = false;
                        //needsV = false;
                        _anim.SetBool("raw", hasMeat);
                        _anim.SetBool("food", hasCookFood);
                        //mini.ActivateGame();
                        if (hasCookFood)
                        {
                            _anim.SetLayerWeight(M, 0);
                            _anim.SetLayerWeight(rawlayer, 0);
                            _anim.SetLayerWeight(V, 0);
                            _anim.SetLayerWeight(M, 0);
                            _anim.SetLayerWeight(rawlayer, 0);
                            _anim.SetLayerWeight(V, 0);

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
                        gumboanime3.SetActive(true);
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
                            if (halfCooked)
                            {
                                hasCookFood = true;
                                halfCooked = false;
                            }
                            else
                                halfCooked = true;
                            needsG = false;
                            button5.SetActive(true);
                        }
                        gumboanime3.SetActive(false);
                        //hasGrain = false;
                        //hasGrain = false;
                        _anim.SetBool("raw", hasMeat);
                        _anim.SetBool("food", hasCookFood);
                        //mini.ActivateGame();
                        if (hasCookFood)
                        {
                            _anim.SetLayerWeight(M, 0);
                            _anim.SetLayerWeight(rawlayer, 0);
                            _anim.SetLayerWeight(V, 0);

                            _anim.SetLayerWeight(rawlayer, 0);
                            _anim.SetLayerWeight(layerfood, wieght);
                        }
                    }
                    if (hasMeat && ischopped)
                    {
                        gumboanime2.SetActive(true);
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
                            button3.SetActive(true);
                        }
                        gumboanime2.SetActive(false);


                        //hasMeat = false;
                        ischopped = false;
                        //needsM = false;
                        _anim.SetBool("raw", hasMeat);
                        _anim.SetBool("food", hasCookFood);
                        //mini.ActivateGame();
                        if (hasCookFood)
                        {
                            _anim.SetLayerWeight(M, 0);
                            _anim.SetLayerWeight(rawlayer, 0);
                            _anim.SetLayerWeight(V, 0);
                            _anim.SetLayerWeight(M, 0);
                            _anim.SetLayerWeight(rawlayer, 0);
                            _anim.SetLayerWeight(V, 0);

                            _anim.SetLayerWeight(rawlayer, 0);
                            _anim.SetLayerWeight(layerfood, wieght);
                        }

                    }
                    break;
                case 1:
                    //clam chowder
                    if ((hasMeat && (ischopped || prep)) || (hasVeggie && (ischopped || prep)))
                    {
                        clamchowder3.SetActive(true);
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

                            button5.SetActive(true);
                        }
                        clamchowder3.SetActive(false);

                        //_anim.SetBool("raw", hasMeat);
                        //_anim.SetBool("food", hasCookFood);
                        //mini.ActivateGame();
                        if (hasCookFood)
                        {
                            _anim.SetLayerWeight(M, 0);
                            _anim.SetLayerWeight(rawlayer, 0);
                            _anim.SetLayerWeight(V, 0);
                            _anim.SetLayerWeight(M, 0);
                            _anim.SetLayerWeight(rawlayer, 0);
                            _anim.SetLayerWeight(V, 0);

                            _anim.SetLayerWeight(rawlayer, 0);
                            _anim.SetLayerWeight(layerfood, wieght);
                        }
                    }
                    break;
                case 0:
                    //avocado toast
                    tast2.SetActive(true);
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

                            button3.SetActive(true);
                        }
                        tast2.SetActive(false);

                        //hasGrain = false;
                        ischopped = false;
                        _anim.SetLayerWeight(M, 0);
                        //_anim.SetLayerWeight(rawlayer, 0);
                        _anim.SetLayerWeight(V, 0);

                        _anim.SetBool("raw", hasGrain);
                        _anim.SetBool("food", hasCookFood);
                        //mini.ActivateGame();
                        if (hasCookFood)
                        {
                            _anim.SetLayerWeight(M, 0);
                            _anim.SetLayerWeight(rawlayer, 0);
                            _anim.SetLayerWeight(V, 0);

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
            _anim.SetLayerWeight(regurallayer, 0);
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
            _anim.SetLayerWeight(regurallayer, 0);
            _anim.SetLayerWeight(V, 0);
            _anim.SetLayerWeight(rawlayer, 0);

            _anim.SetLayerWeight(M, wieght);
            _anim.SetBool("raw", hasMeat);
            switch (order)
            {
                case 3:
                    //fishfry
                    button1.SetActive(true);
                    break;
                case 2:
                    //gumbo
                    button1.SetActive(true);
                    break;
                case 1:
                    //clam chowder
                    button1.SetActive(true);
                    break;
                case 0:
                    //avocado toast

                    break;
                default:
                    //Debug.Log("error");
                    break;
            };


        }
        if (other.transform.tag == "Veggie" && needsV)
        {
            Debug.Log("has food");
            hasVeggie = true;
            hasMeat = false;
            hasGrain = false;

            _anim.SetBool("raw", hasVeggie);
            _anim.SetLayerWeight(regurallayer, 0);
            _anim.SetLayerWeight(M, 0);
            _anim.SetLayerWeight(rawlayer, 0);

            _anim.SetLayerWeight(V, wieght);

            _anim.SetBool("raw", hasVeggie);
            switch (order)
            {
                case 3:
                    //fishfry
                    button3.SetActive(true);
                    break;
                case 2:
                    //gumbo
                    //button1.SetActive(true);
                    break;
                case 1:
                    //clam chowder
                    button3.SetActive(true);
                    break;
                case 0:
                    //avocado toast
                    button4.SetActive(true);
                    break;
                default:
                    //Debug.Log("error");
                    break;
            };

        }
        if (other.transform.tag == "Grain" && needsG)
        {
            Debug.Log("has food");
            hasGrain = true;
            hasVeggie = false;
            hasMeat = false;

            _anim.SetBool("raw", hasGrain);
            _anim.SetLayerWeight(regurallayer, 0);
            _anim.SetLayerWeight(V, 0);
            _anim.SetLayerWeight(M, 0);
            _anim.SetLayerWeight(rawlayer, wieght);
            _anim.SetBool("raw", hasGrain);
            switch (order)
            {
                case 3:
                    //fishfry
                    //button1.SetActive(true);
                    break;
                case 2:
                    //gumbo
                    button4.SetActive(true);
                    break;
                case 1:
                    //clam chowder
                    break;
                case 0:
                    //avocado toast
                    button1.SetActive(true);
                    break;
                default:
                    //Debug.Log("error");
                    break;
            };

        }
        if (other.transform.tag == "serve")
        {

            // check if player has cook food
            if (hasCookFood)
            {
                button1.SetActive(false);
                button2.SetActive(false);
                button3.SetActive(false);
                button4.SetActive(false);
                button5.SetActive(false);
                button6.SetActive(false);
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
                _anim.SetLayerWeight(M, 0);
                _anim.SetLayerWeight(rawlayer, 0);
                _anim.SetLayerWeight(V, 0);
                _anim.SetLayerWeight(regurallayer, 20);

            }
        }
    }
}

/*
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
        order = 1;
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
                            _anim.SetLayerWeight(M, 1);
                            _anim.SetLayerWeight(rawlayer, 1);
                            _anim.SetLayerWeight(V, 1);

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
                            _anim.SetLayerWeight(M, 1);
                            _anim.SetLayerWeight(rawlayer, 1);
                            _anim.SetLayerWeight(V, 1);

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
                            _anim.SetLayerWeight(M, 1);
                            _anim.SetLayerWeight(rawlayer, 1);
                            _anim.SetLayerWeight(V, 1);

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
                            _anim.SetLayerWeight(M, 1);
                            _anim.SetLayerWeight(rawlayer, 1);
                            _anim.SetLayerWeight(V, 1);

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
                            _anim.SetLayerWeight(M, 1);
                            _anim.SetLayerWeight(rawlayer, 1);
                            _anim.SetLayerWeight(V, 1);

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
                            _anim.SetLayerWeight(M, 1);
                            _anim.SetLayerWeight(rawlayer, 1);
                            _anim.SetLayerWeight(V, 1);

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
                            _anim.SetLayerWeight(M, 1);
                            _anim.SetLayerWeight(rawlayer, 1);
                            _anim.SetLayerWeight(V, 1);

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
                        _anim.SetLayerWeight(M, 1);
                        //_anim.SetLayerWeight(rawlayer, 1);
                        _anim.SetLayerWeight(V, 1);

                        _anim.SetBool("raw", hasGrain);
                        _anim.SetBool("food", hasCookFood);
                        //mini.ActivateGame();
                        if (hasCookFood)
                        {
                            _anim.SetLayerWeight(M, 1);
                            _anim.SetLayerWeight(rawlayer, 1);
                            _anim.SetLayerWeight(V, 1);

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
            _anim.SetLayerWeight(regurallayer, 1);
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
            _anim.SetLayerWeight(regurallayer, 1);
            _anim.SetLayerWeight(V, 1);
            _anim.SetLayerWeight(rawlayer, 1);

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
            _anim.SetLayerWeight(regurallayer, 1);
            _anim.SetLayerWeight(M, 1);
            _anim.SetLayerWeight(rawlayer, 1);

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
            _anim.SetLayerWeight(regurallayer, 1);
            _anim.SetLayerWeight(V, 1);
            _anim.SetLayerWeight(M, 1);
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
                _anim.SetLayerWeight(M, 1);
                _anim.SetLayerWeight(rawlayer, 1);
                _anim.SetLayerWeight(V, 1);
                _anim.SetLayerWeight(regurallayer, 20);
    
            }
        }
}
}

*/