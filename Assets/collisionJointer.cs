using UnityEngine;
using System.Collections;

public class collisionJointer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnCollisionEnter(Collision coll)
	{
		Debug.Log ("Colliding!");
		JointScript.Attach (this.gameObject, coll.gameObject);
		JointScript.Detach (this.gameObject, coll.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
