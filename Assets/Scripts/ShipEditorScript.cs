using UnityEngine;
using System.Collections;

public class ShipEditorScript : MonoBehaviour {
	
	
	private Vector3 offset;
	private Vector3 oldMousePosition;
	private Vector3 screenPoint;
	// Use this for initialization
	void Start () {
		
	}	
	
	void OnMouseDown() {
		
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		oldMousePosition = Input.mousePosition;
	}
	
	void OnMouseDrag()
	{
		if (Input.GetKey (KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
			Vector3 currentMousePosition = Input.mousePosition;
			float difference = oldMousePosition.x - currentMousePosition.x; 
			transform.Rotate(new Vector3(0, 0, 1*difference));		
			oldMousePosition = Input.mousePosition;
		} else {


			Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
			Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
			transform.position = curPosition;
		}

		

	}


	void OnTriggerEnter(Collider collider) {
		Utility.RegisterConnection (gameObject, collider.gameObject);

	}

	void OnTriggerExit(Collider collider) {
		Utility.UnregisterConnection (gameObject, collider.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
