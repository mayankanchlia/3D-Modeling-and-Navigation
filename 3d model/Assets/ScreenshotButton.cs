using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Leap;
using Leap.Unity;

public class ScreenshotButton : MonoBehaviour {

	Button myButton;
	public string path = "Screenhot-Unity.png";
	// Use this for initialization
	void Start () {
		this.GetComponentInChildren<Text>().text = "Screenshot";
	}

	void Awake()
	{
		myButton = GetComponent<Button>(); // <-- you get access to the button component here

		myButton.onClick.AddListener(screenshot); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void screenshot(){
		Vector3 pos = GameObject.Find ("Canvas").GetComponent<RectTransform> ().position;
		GameObject.Find ("Canvas").GetComponent<MenuManager> ().enabled = false;
		GameObject.Find ("Canvas").GetComponent<RectTransform> ().position = new Vector3(1000,-1000,-1000);
		Application.CaptureScreenshot (path);
		Debug.Log ("Taken");
		GameObject.Find ("Canvas").GetComponent<MenuManager> ().enabled = true;
		GameObject.Find ("Canvas").GetComponent<RectTransform> ().position = pos;
	}
}
