using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D _body;
    private Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = 0;
        float deltaY = 0;
        if (Input.GetAxis("Horizontal") != 0)
        {
            deltaY = 0;
            deltaX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            Vector2 movementX = new Vector2(deltaX, _body.velocity.y);
            _body.velocity = movementX;
        }
        else if (Input.GetAxis("Vertical") != 0)
        {
            deltaX = 0;
            deltaY = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            Vector2 movementY = new Vector2(_body.velocity.x, deltaY);
            _body.velocity = movementY; 
        }
        _anim.SetFloat("speedx", deltaX);
        //if (deltaX != 0)
        //{
        //   // Debug.Log("x");
        //    Debug.Log(deltaX);
        //}
        ////if (!Mathf.Approximately(deltaX, 0))
        ////{
        ////    Debug.Log("help");
        ////    transform.localScale = new Vector3(Mathf.Sign(deltaX), 1, 1);
        ////}
        //if (deltaY != 0)
        //{
        //    //Debug.Log("y");
        //    Debug.Log(deltaY);
        //}    
        _anim.SetFloat("speedy", deltaY);
        //this.transform.scale = 3;
        //transform.localScale = new Vector3(3, 3, 3);
    }
}
