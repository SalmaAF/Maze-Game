using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


	private Rigidbody2D rb;
	private Animator ani;

	public float speed;

	private bool facingRight;

	void Start () {
		facingRight = true;
		rb = GetComponent<Rigidbody2D> ();//player
		ani = GetComponent<Animator> ();

	}
	

	void FixedUpdate () {
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");	

		Movement (horizontal, vertical);
		Flip(horizontal);
	}

	void Movement(float horizontal, float vertical ){
		rb.velocity = new Vector2 (horizontal*speed,vertical*speed);//move the player by arrows
		ani.SetFloat("speed2",Mathf.Abs( vertical));
		ani.SetFloat("speed",Mathf.Abs( horizontal));//to change the movement to run
	}

	void Flip(float horizontal ){//to make the player flip
		if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight) {
			facingRight = !facingRight;
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}
}
