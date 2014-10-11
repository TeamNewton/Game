using UnityEngine;
using System.Collections;

public class ThrusterScript : MonoBehaviour {

	private static int key = 0;
	private KeyCode keyCode;

	private Animator animator;
	// Use this for initialization
	void Start () {

		animator = GetComponent<Animator> ();
		Debug.Log ("Assigning key for engine " + key);

		// test code, replace with something more robust
		switch (key) {
		case 0:
			
			keyCode = KeyCode.Keypad0;
			break;

		case 1:
			
			keyCode = KeyCode.Keypad1;
			break;

		case 2:
			
			keyCode = KeyCode.Keypad2;
			break;
		case 3:
			
			keyCode = KeyCode.Keypad3;
			break;
		case 4:
			
			keyCode = KeyCode.Keypad4;
			break;

		default:
			keyCode = KeyCode.Keypad5;
			break;
		
		}

		++key;
	}

	void FixedUpdate() {

		if (Input.GetKey (keyCode) && Utility.GetShipScript().IsConnectedToShip(gameObject)) {
			if (animator) {
				animator.SetBool("isOn", true);
			}

			this.gameObject.rigidbody.AddForceAtPosition(transform.right * 0.3f, transform.position);

		} else {
			if (animator) {
				animator.SetBool("isOn", false);
			}
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
