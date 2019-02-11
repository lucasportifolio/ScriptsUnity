using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

	public float speed;
	public int jumpForce;

	public Transform groundCheck;
	public LayerMask layerGround;
	public float radiusCheck; 
	public bool grounded;

	private bool jumping;
	private bool facingRight = true;

	private Rigidbody2D rb2D;




	// Use this for initialization
	void Start () {

		rb2D = GetComponent<Rigidbody2D> ();

		
	}
	
	// Update is called once per frame
	void Update () {

		grounded = Physics2D.OverlapCircle (groundCheck.position, 0.2f, layerGround);	

		if (Input.GetButtonDown ("Jump") && grounded) {
		
			jumping = true;
		}	


	}

	void FixedUpdate() {

		float move = 0f;

		move = Input.GetAxis ("Horizontal");

		rb2D.velocity = new Vector2 (move * speed, rb2D.velocity.y);

		if ((move < 0 && facingRight) || (move > 0 && !facingRight))
			Flip ();
			
		if (grounded && rb2D.velocity.x != 0) {


			if (jumping) {
				rb2D.AddForce (new Vector2 (0f, jumpForce));
				jumping = false;

			}
		}
	}

			void Flip() {
				facingRight = !facingRight;
				transform.localScale = new Vector3( -transform.localScale.x, transform.localScale.y, transform.localScale.z);
	}

	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.CompareTag ("Enemy")) {
			Destroy (this.gameObject);

			GameManager.instance.SetOverlay (GameManager.GameStatus.DIE);

		}
	}

	void OnTriggerEnter2D (Collider2D other) {

		if (other.CompareTag ("exit")) {
			
			GameManager.instance.SetOverlay (GameManager.GameStatus.WIN);
			
		}

	}

				
}

