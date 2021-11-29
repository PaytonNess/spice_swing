using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelWinFail : MonoBehaviour
{

    private Animator _anim;

    public GameObject scriptHolder;
    public custumers customerFunc;

    //Minimum number of customers need to be served in ordered for win condition to be applied
    private int custServedMin = 5;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        scriptHolder = GameObject.Find("character");
        customerFunc = scriptHolder.GetComponent<custumers>();
    }

    // Update is called once per frame
    public void winOrFail()
    {
        _anim.SetBool("levelFail", customerFunc.custServe < custServedMin); 
        _anim.SetBool("levelWin", customerFunc.custServe >= custServedMin);

        Debug.Log("LevelFail" + _anim.GetBool("levelFail"));
        Debug.Log("LevelWin" + _anim.GetBool("levelWin"));
    }
}
