using UnityEngine;
using System.Collections;

public class FuelBarScript : MonoBehaviour {
	//[Range(0,1)]
	private float percent;
	private float oldPercent = 0;

	private float maxFuel;

	// Use this for initialization
	void Start () {
		maxFuel = Utility.GetShipScript ().TotalFuel ();
	}
	
	// Update is called once per frame
	void Update () {
		var script = Utility.GetShipScript ();
		percent = script.RemainingFuel () / maxFuel;

		// I don't even try to pretend how this actually works
		// I've just determined that when the equation 1 - 2*percent has value of 0.27, fuel bar disappears
		// and when it has 0.74, fuel bar is completely visible


		if (oldPercent != percent) {
			oldPercent = percent;
			percent = percent * 0.47f + 0.27f;
			renderer.material.SetTextureOffset ("_MaskTex", Vector2.right * (1 - 2*percent));

		}
	}
}
