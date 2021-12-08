using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class custumers : MonoBehaviour
{
    public SpriteRenderer spriteRenderer0;
    public SpriteRenderer spriteRenderer1;
    public SpriteRenderer spriteRenderer2;
    public SpriteRenderer spriteRenderer3;
    public Animator anime0;
    public Animator anime1;
    public Animator anime2;
    public Animator anime3;
    public Rigidbody2D object0;
    public Rigidbody2D object1;
    public Rigidbody2D object2;
    public Rigidbody2D object3;
    public bool tut = false;
    public int custServe = 0;

  
    public class custmor
    {

        public int order = -1;
        public int waitTime = 90;
        public int mood = 3;
        public int position;
        public custmor(int wait, int ord)
        {
            order = ord;
            waitTime = wait;
        }
        public int getOrder()
        {
            return order;
        }

    }
    public custmor[] cust;
    //delay before custumer shows up (this is in seconds)

    private int delay = 5;
    //max custumers that show up that day
    public int maxCustomers = 15;
    //the time that has passed for that one custumer
    private int timepassed;
    //should custumers still spawn
    private bool loop = true;
    //temp varible 
    private int temp = 0;
    //are they still waiting
    private bool wait = true;
    //postition of the customer
    public int[] pos = new int[4];

    //loop compent of spawning
    private int j = 0;
    //loop for the smaller serving area
    public int another = 0;
    private bool once = false;
    // Start is called before the first frame update
    void Start()
    {
        cust = new custmor[maxCustomers];
        spriteRenderer3.enabled = false;
        spriteRenderer2.enabled = false;
        spriteRenderer1.enabled = false;
        spriteRenderer0.enabled = false;
        pos[0] = -1;
        pos[1] = -1;
        pos[2] = -1;
        pos[3] = -1;
    }
    int getmax() { return maxCustomers; }
    void setmax(int max) { maxCustomers = max; }

    IEnumerator Example()
    {
        Vector2 LOL = new Vector2(-.5f,0f);

        bool spawn = true;
        switch (j)
        {
            case 3:
                spawn = spriteRenderer3.enabled = true;
                object3.velocity = LOL;
                anime3.SetBool("walking", true);

                j = 0;
                break;
            case 2:
                spawn = spriteRenderer2.enabled; 
                object2.velocity = LOL;
                anime2.SetBool("walking", true);


                break;
            case 1:
                spawn = spriteRenderer1.enabled; 
                object1.velocity = LOL;
                anime1.SetBool("walking", true);


                break;
            case 0:
                spawn = spriteRenderer0.enabled;
                object0.velocity = LOL;
                anime0.SetBool("walking", true);

                break;
            default:
                //.Log("error");
                break;
        }
        
        yield return new WaitForSeconds(delay);
        if (!spawn)
        {
            if (temp < maxCustomers)
            {
              

                int food = randOrder();
                custmor person = new custmor(10, food);
                //Debug.Log(person.getOrder());
                cust[temp] = person;
                //StartCoroutine(waitTimer(cust[temp]));
                temp++;
                    
                    
                    pos[j] = food;
                    
                    switch (j)
                    {
                        case 3:
                            spriteRenderer3.enabled = true;
                            break;
                        case 2:
                            spriteRenderer2.enabled = true;
                            break;
                        case 1:
                            spriteRenderer1.enabled = true;
                            break;
                        case 0:
                            spriteRenderer0.enabled = true;
                            break;
                        default:
                            //Debug.Log("error");
                            break;
                    }
                //Debug.Log("GOD WORK");
                //Debug.Log(j + " this is j");

                j += 1;
                if (j >= 4)
                    {
                        //Debug.Log("j = 0");
                        j = 0;
                    }
                }
                //Debug.Log(temp);
            }
        loop = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (!tut)
        {
            if (loop)
            {
                //Debug.Log("start");
                StartCoroutine(Example());
                loop = false;
            }
            if (object0.position.x <= -.9)
            {
                object0.velocity = new Vector2(0f, 0f);
                anime0.SetBool("walking", false);
            }
            if (object1.position.x <= -.7)
            {
                object1.velocity = new Vector2(0f, 0f);
                anime1.SetBool("walking", false);
            }

            if (object2.position.x <= -.5)
            {
                object2.velocity = new Vector2(0f, 0f);
                anime2.SetBool("walking", false);
            }

            if (object3.position.x <= -.3)
            {
                object3.velocity = new Vector2(0f, 0f);
                anime3.SetBool("walking", false);
            }
        }
        else
        {
            if (!once)
            {
                
                spriteRenderer3.enabled = true;
                spriteRenderer2.enabled = true;
                spriteRenderer1.enabled = true;
                spriteRenderer0.enabled = true;
            }
            Vector2 LOL = new Vector2(-.5f, 0f);
            /////////spawn = spriteRenderer3.enabled = true;
            object3.velocity = LOL;
            anime3.SetBool("walking", true);

            //pawn = spriteRenderer2.enabled;
            object2.velocity = LOL;
            anime2.SetBool("walking", true);

            //spawn = spriteRenderer1.enabled;
            object1.velocity = LOL;
            anime1.SetBool("walking", true);

            //spawn = spriteRenderer0.enabled;
            object0.velocity = LOL;
            anime0.SetBool("walking", true);
            
            if (object0.position.x <= -.9)
            {
                object0.velocity = new Vector2(0f, 0f);
                anime0.SetBool("walking", false);
            }
            if (object1.position.x <= -.7)
            {
                object1.velocity = new Vector2(0f, 0f);
                anime1.SetBool("walking", false);
            }

            if (object2.position.x <= -.5)
            {
                object2.velocity = new Vector2(0f, 0f);
                anime2.SetBool("walking", false);
            }

            if (object3.position.x <= -.3)
            {
                object3.velocity = new Vector2(0f, 0f);
                anime3.SetBool("walking", false);
            }
            if (!once)
            {
                setmax(4);
                //custmor person = new custmor(10, 0);
                pos[0] = 0;
                //person = new custmor(10, 1);
                pos[1] = 1;
                //person = new custmor(10, 2);
                pos[2] = 2;
                //person = new custmor(10, 3);
                pos[3] = 3;
                once = true;
            }
        }
    }
    //working 0,1,2,3
    public int randOrder()
    {
        return Random.Range(0, 4);
    }


    IEnumerator waitTimer(custmor cus)
    {
        bool notmad = true;
        int t = 0;
        while (wait)
        {
            yield return new WaitForSeconds(1);
            t++;
            if (t > (cus.waitTime / 2) && notmad)
            {

                cus.mood = 2;
                //Debug.Log("upset");
                notmad = false;
            }
            if (t > (cus.waitTime / 3) && !notmad)
            {
                yield return new WaitForSeconds(cus.waitTime / 3);
                cus.mood = 1;
                //Debug.Log("angry");
            }
            if (t > (cus.waitTime))
            {
                wait = false;
            }
        }
    }
    public void leave()
    {
        //Debug.Log("called");

        if (spriteRenderer0.enabled == true && another == 0)
        {
            spriteRenderer0.enabled = false;
            object0.transform.Translate(5, 0, 0);
            another += 1;
            custServe++;
            //os[0] = -1;
            //Debug.Log(another +"this is another");
        }
        else if (spriteRenderer1.enabled == true && another == 1)
        {
            spriteRenderer1.enabled = false;
            object1.transform.Translate(5, 0, 0);
            custServe++;
            another += 1;
            //pos[1] = -1;
        }
        else if (spriteRenderer2.enabled == true && another == 2)
        {
            spriteRenderer2.enabled = false;
            object2.transform.Translate(5, 0, 0);
            custServe++;
            another += 1;
            //pos[2] = -1;
        }
        else if (spriteRenderer3.enabled == true && another == 3)
        {
            spriteRenderer3.enabled = false;
            object3.transform.Translate(5, 0, 0);
            another = 0;
            custServe++;
            //pos[3] = -1;
        }
    }

}