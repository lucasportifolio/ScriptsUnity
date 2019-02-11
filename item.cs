﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour {

	public AnimationCurve curve;
	public bool inverted;

	private Vector3 cachimboPosition;

	// Use this for initialization
	void Start () {

		curve = new AnimationCurve (new Keyframe (0, 0), new Keyframe (0.8f, 0.2f));
		curve.preWrapMode = WrapMode.PingPong;
		curve.postWrapMode = WrapMode.PingPong;

		cachimboPosition = transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {

		if (inverted)
			transform.position = new Vector3 (cachimboPosition.x, cachimboPosition.y - curve.Evaluate (Time.time), cachimboPosition.z);
		else
			transform.position = new Vector3 (cachimboPosition.x, cachimboPosition.y + curve.Evaluate (Time.time), cachimboPosition.z);
		
	}
}
