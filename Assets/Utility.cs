
using UnityEngine;


public class Utility {

	public static GameObject FindNearestBodyWithTag(string tag, GameObject gameObject) {
		float distance = Mathf.Infinity;
		GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);
		GameObject nearestObj = null;

		foreach (GameObject obj in objects) {
			
			var objectPos = obj.transform.position;
			float newDistance = (objectPos - gameObject.transform.position).sqrMagnitude;
			
			if (newDistance < distance) {
				nearestObj = obj;
				distance = newDistance;
			}
		}

		return nearestObj;
	}


}