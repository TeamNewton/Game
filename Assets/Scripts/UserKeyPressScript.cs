using UnityEngine;
using System.Collections;

public class UserKeyPressScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Escape)) {
			Debug.Log ("Quitter");
			Application.Quit();
		} else if (Input.GetKey (KeyCode.F5)) {
			Utility.DestroyShip();
			Application.LoadLevel("alus1scene");
		}


	}
}
