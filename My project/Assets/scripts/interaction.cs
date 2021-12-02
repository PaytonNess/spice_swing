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
    public bool hasCookFood = false;
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
    private GameObject buttonmg;
    private GameObject animemg;

    IEnumerator CheckMini(bool condiction,GameObject button, GameObject anime)
    {
        Debug.Log("AOSIDJKODHIOKJLDHIASJK");
        Debug.Log(mini.mgWaitTime);

        yield return new WaitForSeconds(mini.mgWaitTime);
        if (mini.mgFailed())
        {
            //The food did not get cooked.

            button.SetActive(false);
            mini.ResetMG();
            mini.ResetQuality();
            hasVeggie = false;
            hasMeat = false;
            hasGrain = false;
        }
        else
        {
            //The food was successfully cooked
            condiction = true;
            button.SetActive(true);
        }
        anime.SetActive(false);

    }
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
        fishanimate1.SetActive(false);
        fisganimate2.SetActive(false);
        fishanimate3.SetActive(false);

        gumboanime1.SetActive(false);
        gumboanime2.SetActive(false);
        gumboanime3.SetActive(false);

        clamchowder1.SetActive(false);
        clamchowder2.SetActive(false);
        clamchowder3.SetActive(false);

        tast1.SetActive(false);
        tast2.SetActive(false);
        tast3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (orders != null)
        {
            //if (orders.spriteRenderer0.enabled == true)
            //{
                order = orders.pos[orders.another];
            //}
        }
        switch (order)
        {
            case 3:
                //fishfry
                //.Log("fishfry");
                recipe1.SetActive(false);
                recipe2.SetActive(false);
                recipe3.SetActive(false);
                recipe4.SetActive(true);
                break;
            case 2:
                //gumbo
                //.Log("gumbo");
                recipe1.SetActive(false);
                recipe2.SetActive(false);
                recipe3.SetActive(true);
                recipe4.SetActive(false);

                break;
            case 1:
                //clam chowder
                //.Log("clam chowder");
                recipe1.SetActive(false);
                recipe2.SetActive(true);
                recipe3.SetActive(false);
                recipe4.SetActive(false);

                break;
            case 0:
                //avocado toast
                //.Log("toast");
                recipe1.SetActive(true);
                recipe2.SetActive(false);
                recipe3.SetActive(false);
                recipe4.SetActive(false);

                break;
            default:
                ////.Log("error");
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
                //.Log("fishfry");
                break;

            case 2:
                //gumbo
                needsM = true;
                needsG = true;
                needsV = false;
                //.Log("gumbo");

                break;
            case 1:
                //clam chowder
                needsM = true;
                needsV = true;
                needsG = false;
                //.Log("clam chowder");

                break;
            case 0:
                //avocado toast
                needsG = true;
                needsV = true;
                needsM = false;
                //.Log("toast");

                break;
            default:
                ////.Log("error");
                break;
        };

        if (other.transform.tag == "cutting")
        {
            //for //
            //StartCoroutine(mini.ActivateGame());
            switch (order)
            {
                case 3:
                    if (hasVeggie && !ischopped)
                    {
                        //call minigame
                        fishanimate1.SetActive(true);
                        StartCoroutine(mini.ActivateGame());
                        //check minigame results
                        StartCoroutine(CheckMini(ischopped, button4, fishanimate1));
                        /**
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
                        */
                    }
                    break;
                case 2:
                    //gumbo
                    if (hasMeat && !ischopped)
                    {
                        //call minigame
                        gumboanime1.SetActive(true);
                        StartCoroutine(mini.ActivateGame());
                        //check minigame results
                        StartCoroutine(CheckMini(ischopped, button2, gumboanime1));
                        /**
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
                        */
                    }
                    break;
                case 1:
                    //clam chowder
                    if ((hasMeat && needsM) || (hasVeggie && needsV))
                    {
                        StartCoroutine(mini.ActivateGame());
                        //call minigame
                        
                        if (hasMeat)
                        {
                            clamchowder1.SetActive(true);
                            buttonmg = button2;
                            animemg = clamchowder1;

                        }
                        if (hasVeggie) {
                            clamchowder2.SetActive(true);
                            buttonmg = button4;
                            animemg = clamchowder2;

                        }
                        //check minigame results
                        if (prep)
                        {
                            prep = false;
                            StartCoroutine(CheckMini(ischopped, buttonmg, animemg));
                        }
                        else
                            StartCoroutine(CheckMini(prep, buttonmg, animemg));


                        /*
                        if (mini.mgFailed())
                        {
                            //The food did not get cooked.
                            hasVeggie = false;
                            hasMeat = false;
                            mini.ResetMG();
                            mini.ResetQuality();
                            //.Log("failed");
                            clamchowder1.SetActive(false);
                            clamchowder2.SetActive(false);

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
                            //.Log("won");
                            clamchowder1.SetActive(false);
                            clamchowder2.SetActive(
                        }
                        */
                    }
                    break;
                case 0:
                    //avocado toast
                    if (hasGrain && !ischopped)
                    {
                        //call minigame
                        tast1.SetActive(true);
                        StartCoroutine(mini.ActivateGame());
                        if (prep)
                        {
                            prep = false;
                            StartCoroutine(CheckMini(hasCookFood, button2, tast1));
                        }
                        else
                            StartCoroutine(CheckMini(prep, button2, tast1));

                        //check minigame results
                        if (hasCookFood)
                        {
                            _anim.SetLayerWeight(M, 0);
                            _anim.SetLayerWeight(rawlayer, 0);
                            _anim.SetLayerWeight(V, 0);
                            _anim.SetLayerWeight(M, 0);
                             _anim.SetLayerWeight(V, 0);
                            _anim.SetLayerWeight(layerfood, wieght);
                        }

                    }
                    if (hasVeggie && !ischopped)
                    {
                        tast3.SetActive(true);
                        //ischopped = true;
                        //call minigame
                        StartCoroutine(mini.ActivateGame());
                        //check minigame results
                        if (prep)
                        {
                            prep = false;
                            StartCoroutine(CheckMini(hasCookFood, button5, tast3));
                        }
                        else
                            StartCoroutine(CheckMini(prep, button5, tast3));
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
                    //.Log("error");
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
                        StartCoroutine(mini.ActivateGame());
                        //check minigame results
                        if (halfCooked)
                        {
                            StartCoroutine(CheckMini(hasCookFood, button2, fishanimate3));
                            //hasCookFood = true;
                            halfCooked = false;
                        }
                        else
                            StartCoroutine(CheckMini(halfCooked, button2, fishanimate3));

                        //hasMeat = false;
                        //hasMeat = false;
                        _anim.SetBool("raw", false);
                        _anim.SetBool("food", hasCookFood);
                        //StartCoroutine(mini.ActivateGame());
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
                        StartCoroutine(mini.ActivateGame());
                        //check minigame results
                        if (halfCooked)
                        {
                            StartCoroutine(CheckMini(hasCookFood, button3, fishanimate2));
                            //hasCookFood = true;
                            halfCooked = false;
                        }
                        else
                            StartCoroutine(CheckMini(halfCooked, button3, fishanimate2));

                        hasVeggie = false;
                        ischopped = false;
                        needsV = false;
                        _anim.SetBool("raw", hasMeat);
                        _anim.SetBool("food", hasCookFood);
                        //StartCoroutine(mini.ActivateGame());
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
                        StartCoroutine(mini.ActivateGame());
                        //check minigame results
                        if (halfCooked)
                        {
                            StartCoroutine(CheckMini(hasCookFood, button5, gumboanime3));
                            halfCooked = false;
                        }
                        else
                            StartCoroutine(CheckMini(halfCooked, button5, gumboanime3));

                        //if (mini.mgFailed())
                        //{
                        //    //The food did not get cooked.
                        //    hasGrain = false;
                        //    mini.ResetMG();
                        //    mini.ResetQuality();
                        //}
                        //else
                        //{
                        //    //The food was successfully cooked
                        //    if (halfCooked)
                        //    {
                        //        hasCookFood = true;
                        //        halfCooked = false;
                        //    }
                        //    else
                        //        halfCooked = true;
                        //    needsG = false;
                        //    button5.SetActive(true);
                        //}
                        //gumboanime3.SetActive(false);
                        //hasGrain = false;
                        //hasGrain = false;
                        _anim.SetBool("raw", hasMeat);
                        _anim.SetBool("food", hasCookFood);
                        //StartCoroutine(mini.ActivateGame());
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
                        StartCoroutine(mini.ActivateGame());
                        //check minigame results
                        if (halfCooked)
                        {
                            StartCoroutine(CheckMini(hasCookFood, button3, gumboanime2));
                            halfCooked = false;
                        }
                        else
                            StartCoroutine(CheckMini(halfCooked, button3, gumboanime2));

                  

                        hasMeat = false;
                        ischopped = false;
                        needsM = false;
                        _anim.SetBool("raw", hasMeat);
                        _anim.SetBool("food", hasCookFood);
                        //StartCoroutine(mini.ActivateGame());
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
                        StartCoroutine(mini.ActivateGame());
                        //check minigame results
                        
                         StartCoroutine(CheckMini(hasCookFood, button5, clamchowder3));

                        //if (mini.mgFailed())
                        //{
                        //    //The food did not get cooked.

                        //    mini.ResetMG();
                        //    mini.ResetQuality();
                        //}
                        //else
                        //{
                        //    //The food was successfully cooked
                        //    hasCookFood = true;

                        //    hasVeggie = false;
                        //    prep = false;
                        //    hasMeat = false;
                        //    ischopped = false;
                        //    needsM = false;
                        //    needsV = false;

                        //    button5.SetActive(true);
                        //}
                        //clamchowder3.SetActive(false);

                        //_anim.SetBool("raw", hasMeat);
                        //_anim.SetBool("food", hasCookFood);
                        //StartCoroutine(mini.ActivateGame());
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
                        StartCoroutine(mini.ActivateGame());
                        //check minigame results
                        if (halfCooked)
                        {
                            StartCoroutine(CheckMini(hasCookFood, button3, tast2));
                            halfCooked = false;
                        }
                        else
                            StartCoroutine(CheckMini(halfCooked, button3, tast2));


                        //if (mini.mgFailed())
                        //{
                        //    //The food did not get cooked.

                        //    mini.ResetMG();
                        //    mini.ResetQuality();
                        //}
                        //else
                        //{
                        //    //The food was successfully cooked
                        //    //hasCookFood = true;
                        //    if (halfCooked)
                        //    {
                        //        hasCookFood = true;
                        //        halfCooked = false;
                        //    }
                        //    else
                        //        halfCooked = true;
                        //    needsG = false;

                        //    button3.SetActive(true);
                        //}
                        //tast2.SetActive(false);

                        hasGrain = false;
                        ischopped = false;
                        _anim.SetLayerWeight(M, 0);
                        //_anim.SetLayerWeight(rawlayer, 0);
                        _anim.SetLayerWeight(V, 0);

                        _anim.SetBool("raw", hasGrain);
                        _anim.SetBool("food", hasCookFood);
                        //StartCoroutine(mini.ActivateGame());
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
                    //.Log("error");
                    break;
            };
        }
        if (other.transform.tag == "ingredents")
        {
            //.Log("has food");
            hasFood = true;
            _anim.SetLayerWeight(regurallayer, 0);
            _anim.SetLayerWeight(rawlayer, wieght);
            _anim.SetBool("raw", hasFood);
        }
        if (other.transform.tag == "Meat" && needsM)
        {
            //.Log("has food");
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
                    ////.Log("error");
                    break;
            };


        }
        if (other.transform.tag == "Veggie" && needsV)
        {
            //.Log("has food");
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
                    ////.Log("error");
                    break;
            };

        }
        if (other.transform.tag == "Grain" && needsG)
        {
            //.Log("has food");
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
                    ////.Log("error");
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
                //.Log("served food");
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
                //.Log("fishfry");
                break;
            case 2:
                //gumbo
                //.Log("gumbo");

                break;
            case 1:
                //clam chowder
                //.Log("clam chowder");

                break;
            case 0:
                //avocado toast
                //.Log("toast");

                break;
            default:
                ////.Log("error");
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
                //.Log("fishfry");
                break;
            case 2:
                //gumbo
                needsM = true;
                needsG = true;
                needsV = false;
                //.Log("gumbo");

                break;
            case 1:
                //clam chowder
                needsM = true;
                needsV = true;
                needsG = false;
                //.Log("clam chowder");

                break;
            case 0:
                //avocado toast
                needsG = true;
                needsV = true;
                needsM = false;
                //.Log("toast");

                break;
            default:
                ////.Log("error");
                break;
        };

        if (other.transform.tag == "cutting")
        {
            //for //
            //StartCoroutine(mini.ActivateGame());
            switch (order)
            {
                case 3:
                    if (hasVeggie && !ischopped)
                    {
                        //call minigame
                        StartCoroutine(mini.ActivateGame());
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
                        StartCoroutine(mini.ActivateGame());
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
                        StartCoroutine(mini.ActivateGame());
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
                        StartCoroutine(mini.ActivateGame());
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
                        StartCoroutine(mini.ActivateGame());
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
                    //.Log("error");
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
                        StartCoroutine(mini.ActivateGame());
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
                        //StartCoroutine(mini.ActivateGame());
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
                        StartCoroutine(mini.ActivateGame());
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
                        //StartCoroutine(mini.ActivateGame());
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
                        StartCoroutine(mini.ActivateGame());
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
                        //StartCoroutine(mini.ActivateGame());
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
                        StartCoroutine(mini.ActivateGame());
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
                        //StartCoroutine(mini.ActivateGame());
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
                        StartCoroutine(mini.ActivateGame());
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
                        //StartCoroutine(mini.ActivateGame());
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
                        StartCoroutine(mini.ActivateGame());
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
                        //StartCoroutine(mini.ActivateGame());
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
                    //.Log("error");
                    break;
            };
        }
        if (other.transform.tag == "ingredents")
        {
            //.Log("has food");
            hasFood = true;
            _anim.SetLayerWeight(regurallayer, 1);
            _anim.SetLayerWeight(rawlayer, wieght);
            _anim.SetBool("raw", hasFood);
        }
        if (other.transform.tag == "Meat" && needsM)
        {
            //.Log("has food");
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
            //.Log("has food");
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
            //.Log("has food");
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
                //.Log("served food");
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