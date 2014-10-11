using UnityEngine;
using System.Collections;

public class Enforce2DBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	// enforce 2d behaviour as due to joint limitations we are forced to use 3d
	void Update () {
		transform.position = new Vector3 (transform.position.x, transform.position.y, 0);
		transform.localEulerAngles = new Vector3 (0, 0, transform.localEulerAngles.z);
	}
}
