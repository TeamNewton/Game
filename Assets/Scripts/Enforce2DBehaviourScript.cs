using UnityEngine;
using System.Collections;

public class Enforce2DBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (rigidbody != null) {
			rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionZ;
		}

	}

	// enforce 2d behaviour as due to joint limitations we are forced to use 3d
	void Update () {
	}
}
