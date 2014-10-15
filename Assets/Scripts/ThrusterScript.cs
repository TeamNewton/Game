using UnityEngine;
using System.Collections;

public class ThrusterScript : MonoBehaviour {

	private float FUEL_CONSUMPTION = 1;
	private KeyCode keyCode;

	private Animator animator;
	// Use this for initialization
	void Start () {

		animator = GetComponent<Animator> ();
		
	}

	public void setKeyCode(KeyCode key)
	{
		keyCode = key;
	}

	void FixedUpdate() {

		var shipScript = Utility.GetShipScript ();
		if (Input.GetKey (keyCode) && shipScript.IsConnectedToShip(gameObject) && shipScript.ConsumeFuelIfEnough(FUEL_CONSUMPTION)) {
			if (animator) {
				animator.SetBool("isOn", true);
			}

			if (audio && !audio.isPlaying) {
				audio.Play();
			}

			Debug.Log("Actived engine with key: " + keyCode);
			rigidbody.AddForceAtPosition(transform.right * 0.3f, transform.position);

		} else {
			if (animator) {
				animator.SetBool("isOn", false);
			}

			if (audio && audio.isPlaying) {
				audio.Stop();
			}
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
