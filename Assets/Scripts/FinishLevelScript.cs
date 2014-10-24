using UnityEngine;
using System.Collections;


public class FinishLevelScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.tag == "Command") {
			Utility.DestroyShip();
			Application.LoadLevel("Winner");
		}

	}
}
