using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Leap;
using Leap.Unity;
using Leap.Unity.Interaction;
using Leap.Unity.DetectionExamples;

public class paintButton : MonoBehaviour {

	public Mesh cylindermesh;

	Button myButton;
	Joint[] g;

	// Use this for initialization
	void Start () {
		this.GetComponentInChildren<Text>().text = "Paint";

	}

	void Awake()
	{
		myButton = GetComponent<Button>(); // <-- you get access to the button component here

		myButton.onClick.AddListener(EnterPaintMode); 
		myButton.onClick.AddListener(ChangeColour); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void EnterPaintMode(){
		//GameObject.Find("s")
		g = GameObject.FindObjectsOfType<Joint>();
		for (int i = 0; i < g.Length; i++) {
			g [i].gameObject.GetComponent<Joint> ().enabled = false;
			g [i].gameObject.GetComponent<InteractionBehaviour> ().enabled = false;
			if (g [i].gameObject.name == "Sphere")
				g [i].gameObject.GetComponent<MeshCollider> ().sharedMesh = cylindermesh; 
			//Debug.Log("adshksdhkj " + g [i].gameObject.GetComponent<MeshCollider> ().sharedMesh);
			g [i].gameObject.GetComponent<Co>().enabled = true;
		}

		Vector3 menuPosition = GameObject.Find ("Canvas").GetComponent<RectTransform> ().position;
		Debug.Log ("Here");
		GameObject.Find ("Canvas").GetComponent<MenuManager> ().enabled = false;
		GameObject.Find ("Canvas").GetComponent<RectTransform> ().position = new Vector3 (1000, -1000, 1000);
		Debug.Log ("Herejkhkj");
		GameObject.Find ("ColourCanvas").GetComponent<RectTransform> ().position = menuPosition;
		GameObject.Find ("ColourCanvas").GetComponent<ColourMenuManager>().enabled = true;

		GameObject.Find ("Pinch Drawing").GetComponent<PinchDraw> ().enabled = false;
	}

	public void ChangeColour(){
		/*Color pressed_colour = Color.cyan;
		Color not_pressed = Color.white;
		ColorBlock cb = this.GetComponent<Button> ().colors;
		cb.normalColor = pressed_colour;

		Debug.Log (Color.cyan);
		Debug.Log ("Paint colour change" + this.GetComponent<Button> ().colors.normalColor);
		cb = GameObject.Find ("Build").GetComponent<Button> ().colors;
		cb.normalColor = not_pressed;

		cb = GameObject.Find ("Pinch").GetComponent<Button> ().colors;
		cb.normalColor = not_pressed;
*/
		Button b = this.GetComponent<Button>(); 
		ColorBlock cb = b.colors;
		cb.normalColor = Color.red;
		b.colors = cb;

		Debug.Log (Color.cyan);
		Debug.Log ("Paint colour change" + this.GetComponent<Button> ().colors.normalColor);
		b = GameObject.Find ("Build").GetComponent<Button> ();
		cb = b.colors;
		cb.normalColor = Color.white;
		b.colors = cb;

		b = GameObject.Find ("Pinch").GetComponent<Button> ();
		cb = b.colors;
		cb.normalColor = Color.white;
		b.colors = cb;
	}
}
