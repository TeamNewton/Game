using UnityEngine;
using System.Collections;

public class OnSceneLoad : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log ("Hello!");
//		Application.LoadLevelAdditive ("uiscene");
	}

	void OnLevelWasLoaded() {
		Debug.Log ("Hello!");
	//	Application.LoadLevelAdditive ("uiscene");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
