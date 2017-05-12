using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Leap;
using Leap.Unity;
using Leap.Unity.DetectionExamples;

public class PinchButton : MonoBehaviour {

	Button myButton;
	// Use this for initialization
	void Start () {
		this.GetComponentInChildren<Text>().text = "Pinch";
	}

	void Awake()
	{
		myButton = GetComponent<Button>(); // <-- you get access to the button component here

		myButton.onClick.AddListener(EnterPinchMode); 
		myButton.onClick.AddListener(ChangeColour); 
	}

	// Update is called once per frame
	void Update () {
		
	}

	void EnterPinchMode(){
		Vector3 menuPosition = GameObject.Find ("Canvas").GetComponent<RectTransform> ().position;
		Debug.Log ("Here");
		GameObject.Find ("Canvas").GetComponent<MenuManager> ().enabled = false;
		GameObject.Find ("Canvas").GetComponent<RectTransform> ().position = new Vector3 (1000, -1000, 1000);
		Debug.Log ("Herejkhkj");
		GameObject.Find ("ColourCanvas").GetComponent<RectTransform> ().position = menuPosition;
		GameObject.Find ("ColourCanvas").GetComponent<ColourMenuManager>().enabled = true;

		GameObject.Find ("Pinch Drawing").GetComponent<PinchDraw> ().enabled = true;
	}

	public void ChangeColour(){
		/*Color pressed_colour = Color.cyan;
		Color not_pressed = Color.white;
		ColorBlock cb = this.GetComponent<Button> ().colors;
		cb.normalColor = pressed_colour;

		cb = GameObject.Find ("Paint").GetComponent<Button> ().colors;
		cb.normalColor = not_pressed;

		cb = GameObject.Find ("Build").GetComponent<Button> ().colors;
		cb.normalColor = not_pressed;
	*/
		Button b = this.GetComponent<Button>(); 
		ColorBlock cb = b.colors;
		cb.normalColor = Color.red;
		b.colors = cb;

		b = GameObject.Find ("Paint").GetComponent<Button> ();
		cb = b.colors;
		cb.normalColor = Color.white;
		b.colors = cb;

		b = GameObject.Find ("Build").GetComponent<Button> ();
		cb = b.colors;
		cb.normalColor = Color.white;
		b.colors = cb;
	}
}
