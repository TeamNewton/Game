using UnityEngine;
using System.Collections;

public class AttractorAnimationScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.transform.localPosition = new Vector3 (0, 0, 0);

		Color originalColor = renderer.material.color;
		gameObject.transform.localScale = new Vector3 (2, 2, 1);
		renderer.material.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0.0f);
	
	}
	
	// Update is called once per frame
	void Update () {
		Color originalColor = renderer.material.color;
		if (gameObject.transform.localScale.x <= 0.1f) 
		{
			gameObject.transform.localScale = new Vector3 (2, 2, 1);
			renderer.material.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0.0f);
		} 
		else 
		{
			gameObject.transform.localScale -= new Vector3 (1.0f*Time.deltaTime, 1.0f*Time.deltaTime, 0);
			renderer.material.color = new Color(originalColor.r, originalColor.g, originalColor.b, originalColor.a + 0.15f*Time.deltaTime);
		}
	}
}
