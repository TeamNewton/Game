using UnityEngine;
using System.Collections;

public class CompassScript : MonoBehaviour {

	void Point()
	{
		GameObject goal = Utility.FindNearestBodyWithTag ("Finish", this.gameObject);

		if (goal == null) {
			return;		
		}
		
		float deltaY = goal.transform.position.y - transform.position.y;
		float deltaX = goal.transform.position.x - transform.position.x;
		
		
		
		float angle = Mathf.Atan2 (deltaY, deltaX) * 180 / Mathf.PI;
		
		
		this.gameObject.transform.eulerAngles = new Vector3 (0, 0, angle);
	}

	void GoToCorner()
	{
		Camera camera = Camera.main;
		Vector3 rightCorner = camera.ViewportToWorldPoint(new Vector3(1, 0, camera.nearClipPlane));
		rightCorner.x = rightCorner.x - 3.2f;
		rightCorner.y = rightCorner.y + 3.2f;
		rightCorner.z = 0;
		this.gameObject.transform.position = rightCorner;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Point ();
		GoToCorner ();

	
	}
}
