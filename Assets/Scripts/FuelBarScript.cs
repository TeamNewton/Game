using UnityEngine;
using System.Collections;

public class FuelBarScript : MonoBehaviour {
	//[Range(0,1)]
	private float percent;
	private float oldPercent = 0;

	private float maxFuel;

	// Use this for initialization
	void Start () {

		transform.localScale = new Vector3(Screen.width/1920f, Screen.height/1080f,  1);

		var v3Pos = new Vector3(0.06f, 0.95f, -Camera.main.transform.position.z);
		transform.position = Camera.main.ViewportToWorldPoint(v3Pos);
		maxFuel = Utility.GetShipScript ().TotalFuel ();
		transform.parent = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {
		var script = Utility.GetShipScript ();
		percent = script.RemainingFuel () / maxFuel;

		// I don't even try to pretend how this actually works
		// I've just determined that when the equation 1 - 2*percent has value of 0.27, fuel bar disappears
		// and when it has 0.74, fuel bar is completely visible

		if (oldPercent != percent) {
			Debug.Log("Percent: " +  percent);
			oldPercent = percent;
			percent = percent * 0.47f + 0.27f;
			renderer.material.SetTextureOffset ("_MaskTex", Vector2.right * (1 - 2*percent));

		}
	}
}
