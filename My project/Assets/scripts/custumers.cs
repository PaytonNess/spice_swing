using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class custumers : MonoBehaviour
{
    public SpriteRenderer spriteRenderer0;
    public SpriteRenderer spriteRenderer1;
    public SpriteRenderer spriteRenderer2;
    public SpriteRenderer spriteRenderer3;
    //public Animator anime0;
    //public Animator anime1;
    //public Animator anime2;
    //public Animator anime3;
    //public Rigidbody2D object0;
    //public Rigidbody2D object1;
    //public Rigidbody2D object2;
    //public Rigidbody2D object3;

    public Sprite image;
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
    //this is in seconds
    //delay before custumer shows up
    private int delay = 5;
    //max custumers that show up that day
    private int maxCustomers = 1;
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
    // Start is called before the first frame update
    void Start()
    {
        cust = new custmor[maxCustomers];
        spriteRenderer3.enabled = false;
        spriteRenderer2.enabled = false;
        spriteRenderer1.enabled = false;
        spriteRenderer0.enabled = false;
    }

    IEnumerator Example()
    {
        //Vector2 vec = new Vector2(-.5f, 1f);

        bool spawn = true;
        switch (j)
        {
            case 3:
                spawn = spriteRenderer3.enabled;
                //object3.transform.Translate(-5, 1, 0);
                //Vector2 vec = new Vector2(-.5f, 1f);
               // object3.MovePosition(vec);
                //j = 0;
                break;
            case 2:
                spawn = spriteRenderer2.enabled;
               // object2.transform.Translate(-5, 1, 0);
                //Vector2 vec = new Vector2(-.5f, 1f);
               // object2.MovePosition(vec);

                break;
            case 1:
                spawn = spriteRenderer1.enabled;
                //object1.transform.Translate(-5, 1, 0);
                //Vector2 vec = new Vector2(-.5f, 1f);
              //  object1.MovePosition(vec);

                break;
            case 0:
                spawn = spriteRenderer0.enabled;
                //object0.transform.Translate(-5, 1, 0);
                //Vector2 vec = new Vector2(-.5f, 1f);
               // object0.MovePosition(vec);

                break;
            default:
                Debug.Log("error");
                break;
        }
        
        yield return new WaitForSeconds(delay);
        if (!spawn)
        {
            if (temp < maxCustomers)
            {
              

                int food = randOrder();
                custmor person = new custmor(10, food);
                Debug.Log(person.getOrder());
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
                            Debug.Log("error");
                            break;
                    }
                    //Debug.Log("GOD WORK");
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
        if (loop)
        {
            //Debug.Log("start");
            StartCoroutine(Example());
            loop = false;
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
                Debug.Log("upset");
                notmad = false;
            }
            if (t > (cus.waitTime / 3) && !notmad)
            {
                yield return new WaitForSeconds(cus.waitTime / 3);
                cus.mood = 1;
                Debug.Log("angry");
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
            another += 1;
        }
        else if (spriteRenderer1.enabled == true && another == 1)
        {
            spriteRenderer1.enabled = false;
            another += 1;
        }
        else if (spriteRenderer2.enabled == true && another == 2)
        {
            spriteRenderer2.enabled = false;
            another += 1;
        }
        else if (spriteRenderer3.enabled == true && another == 3)
        {
            spriteRenderer3.enabled = false;
            another = 0;
        }
    }

}