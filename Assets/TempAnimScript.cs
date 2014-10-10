using UnityEngine;
using System.Collections;

public class TempAnimScript : MonoBehaviour {
	private bool animating;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animating = false;
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.KeypadEnter)) {
		
			animator.SetBool("isOn", true);

		} else {
			animator.SetBool("isOn", false);
		}
	}
}
