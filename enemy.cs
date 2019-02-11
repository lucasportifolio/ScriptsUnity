using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

	SpriteRenderer spriteinimigo;
	float v;


	void Start () {
		spriteinimigo = GetComponent<SpriteRenderer> ();
		v = 0.03f;
		spriteinimigo.flipX = false;
	}
	

	void Update () {

		transform.Translate (Vector3.left * v);

		if (transform.position.x >= 4.51f) {
			spriteinimigo.flipX = false;
			v = v * (-1);

		}

		if (transform.position.x <= 0.62f) {
			spriteinimigo.flipX = true;
			v = v * (-1);

		}
		
	}
}
