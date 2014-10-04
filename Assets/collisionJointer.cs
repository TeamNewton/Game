using UnityEngine;
using System.Collections;

public class collisionJointer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnCollisionEnter(Collision coll)
	{
		JointScript.attach (this.gameObject, coll.gameObject);
		JointScript.detach (this.gameObject, coll.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
