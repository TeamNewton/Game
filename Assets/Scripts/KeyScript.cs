using UnityEngine;
using System.Collections;

public class KeyScript : MonoBehaviour {

	public KeyCode key = KeyCode.None;
	private bool selected = false;

	// Use this for initialization
	void Start () {
	
	}

	void OnMouseOver()
	{

		if (Input.GetMouseButtonDown (1)) 
		{
			selected = true;
		}
	}

	void OnGUI()
	{
		if (selected) 
		{
			key = findKey (Event.current);
		}
	}

	KeyCode findKey(Event e)
	{

		if (e.isKey) 
		{
			if(e.keyCode != KeyCode.None)
			{
				selected = false;
				transform.Find ("EngineKeyText").gameObject.GetComponent<TextMesh>().text = e.keyCode.ToString();
	
				return e.keyCode;
			}
		} 
		return key;

	}

	
	// Update is called once per frame
	void Update () {
	}


}
