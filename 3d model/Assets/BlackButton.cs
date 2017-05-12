using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Leap;
using Leap.Unity;
using Leap.Unity.DetectionExamples;


public class BlackButton : MonoBehaviour {

	Button myButton;
	Co[] g;
	// Use this for initialization
	void Start () {
		this.GetComponentInChildren<Text>().text = "Black";
	}

	void Awake()
	{
		myButton = GetComponent<Button>(); // <-- you get access to the button component here

		myButton.onClick.AddListener(SetPaintAsBlack); 
		myButton.onClick.AddListener(closeColorMenu); 
	}

	// Update is called once per frame
	void Update () {
		
	}

	void SetPaintAsBlack(){
		g = GameObject.FindObjectsOfType<Co>();
		for (int i = 0; i < g.Length; i++) {
			g [i].gameObject.GetComponent<Co> ().paintColour = Color.black;
		}

		GameObject.FindObjectOfType<PinchDraw>().GetComponent<PinchDraw>().DrawColor = Color.black;
		//GameObject.Find ("ColourCanvas").GetComponent<ColourMenuManager>().isactive = false;
	}


	void closeColorMenu(){
		GameObject.Find ("ColourCanvas").GetComponent<ColourMenuManager>().enabled = false;
		GameObject.Find ("ColourCanvas").transform.position = new Vector3 (-1000f, -1000f, -1000f);
		GameObject.Find ("Canvas").GetComponent<MenuManager>().enabled = false;
		GameObject.Find ("Canvas").GetComponent<RectTransform>().position = new Vector3 (-1000, -1100, -1000);
	}

}
