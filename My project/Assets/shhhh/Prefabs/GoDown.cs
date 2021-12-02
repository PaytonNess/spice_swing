using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GoDown : MonoBehaviour 
{ 
	public Rigidbody2D rb;
	void Start(){
		rb.velocity = new Vector2(0, -1);
	}
}