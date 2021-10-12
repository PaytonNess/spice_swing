using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D _body;
    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            float deltaX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            Vector2 movementX = new Vector2(deltaX, _body.velocity.y);
            _body.velocity = movementX;
        }
        else
        {
            float deltaY = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            Vector2 movementY = new Vector2(_body.velocity.x, deltaY);
            _body.velocity = movementY; 
        }
    }
}
