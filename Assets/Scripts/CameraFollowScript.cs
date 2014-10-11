using UnityEngine;
using System.Collections;

public class CameraFollowScript : MonoBehaviour {

	private const float MAX_X_DIFFERENCE = 15f;
	private const float MAX_Y_DIFFERENCE = 15f;

	private const float MAX_SPANNING_SPEED = 0.1f;
	private const float MIN_CAMERA_PANNING_SPEED = 0.01f;
	private const float PANNING_DIVISOR = 10f;

	GameObject command;
	// Use this for initialization
	void Start () {
		command = GameObject.FindGameObjectWithTag ("Command");	

	}

	void Update () {
		camera.transform.position = new Vector3 (command.transform.position.x, command.transform.position.y, camera.transform.position.z);
	}

}
