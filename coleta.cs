﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coleta : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other) {

		if (other.CompareTag ("Player")) {
			GameManager.instance.pontos++;
			Destroy (gameObject);
		
		}

	}

}
