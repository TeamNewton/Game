﻿using UnityEngine;
using System.Collections;

public class DamageOnCollisionScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionStay(Collision collision) {
		Debug.Log ("Damage on collision hit something...");
		collision.collider.gameObject.SendMessage ("TakeDamage");
	}
}
