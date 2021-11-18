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
            Vector2 movementX = new Vector2(deltaX, 0);
            _body.velocity = movementX;
            //_anim.SetFloat("speedx", movementX);
        }
        else if (Input.GetAxis("Vertical") != 0)
        {
            deltaX = 0;
            deltaY = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            Vector2 movementY = new Vector2(0, deltaY);
            _body.velocity = movementY;
            //_anim.SetFloat("speedy", movementY);
        }
        else
        {
            Vector2 movement = new Vector2(0, 0);
            _body.velocity = movement;
        }
        _anim.SetFloat("speedx", deltaX);

        _anim.SetFloat("speedy", deltaY);
        //this.transform.scale = 3;
        //transform.localScale = new Vector3(3, 3, 3);
    }
}
