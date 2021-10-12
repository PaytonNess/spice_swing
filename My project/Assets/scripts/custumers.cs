using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class custumers : MonoBehaviour
{
    public class custmor
    {
        public int order = -1;
        public int waitTime = 90;
        public int mood = 3;

        public custmor(int wait, int ord)
        {
            order = ord;
            waitTime = wait;
        }


    }

    //this is in seconds

    private int delay = 5;
    private int maxCustomers = 15;
    private int timepassed;
    private bool loop = true;
    private int temp = 0;
    private bool wait = true;
    private custmor[] cust;
    // Start is called before the first frame update
    void Start()
    {
        cust = new custmor[maxCustomers];
    }

    IEnumerator Example()
    {


        Debug.Log("working");
        yield return new WaitForSeconds(delay);
        if (temp < maxCustomers)
        {
            int food = randOrder();
            cust[temp] = new custmor(10, food);
            StartCoroutine(waitTimer(cust[temp]));
            temp++;

            Debug.Log(temp);
        }
        loop = true;

    }
    // Update is called once per frame
    void Update()
    {
        if (loop)
        {
            Debug.Log("start");
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
                cus.mood = 1;
                Debug.Log("angry");
            }
            if (t > (cus.waitTime))
            {
                wait = false;
            }
        }

    }
}