using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Leap;
using Leap.Unity;
using Leap.Unity.Interaction;
using Leap.Unity.DetectionExamples;

public class buildButton : MonoBehaviour {
	public Mesh spheremesh;
	Button myButton;
	Joint[] g;
	// Use this for initialization
	void Start () {
		this.GetComponentInChildren<Text>().text = "Build";
	}

	void Awake()
	{
		myButton = GetComponent<Button>(); // <-- you get access to the button component here

		myButton.onClick.AddListener(EnterBuildMode); 
		myButton.onClick.AddListener(ChangeColour); 
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void EnterBuildMode(){
		//GameObject.Find("s")
		g = GameObject.FindObjectsOfType<Joint>();
		for (int i = 0; i < g.Length; i++) {
			g [i].gameObject.GetComponent<Co>().enabled = false;
			g [i].gameObject.GetComponent<MeshCollider>().enabled = false;
			g [i].gameObject.GetComponent<MeshCollider>().convex = true;
			if (g [i].gameObject.name == "Sphere")
				g [i].gameObject.GetComponent<MeshCollider> ().sharedMesh = spheremesh; 
			Debug.Log(g [i].gameObject.GetComponent<MeshCollider> ().sharedMesh);
			g [i].gameObject.GetComponent<Joint> ().enabled = true;
			g [i].gameObject.GetComponent<InteractionBehaviour>().enabled = true;
		}

		GameObject.Find ("Canvas").GetComponent<MenuManager> ().enabled = false;
		GameObject.Find ("Canvas").GetComponent<RectTransform> ().position = new Vector3 (1000, -1000, 1000);

		GameObject.Find ("Pinch Drawing").GetComponent<PinchDraw>().enabled = false;

		//Debug.Log (GameObject.Find ("Pinch Drawing").GetComponent<PinchDraw>().enabled);
	}

	public void ChangeColour(){
		Color pressed_colour = Color.cyan;
		Color not_pressed = Color.white;
		//ColorBlock cb = this.GetComponent<Button> ().colors;
		//cb.normalColor = pressed_colour;

		Button b = this.GetComponent<Button>(); 
		ColorBlock cb = b.colors;
		cb.normalColor = Color.red;
		b.colors = cb;

		b = GameObject.Find ("Paint").GetComponent<Button> ();
		cb = b.colors;
		cb.normalColor = Color.white;
		b.colors = cb;

		b = GameObject.Find ("Pinch").GetComponent<Button> ();
		cb = b.colors;
		cb.normalColor = Color.white;
		b.colors = cb;
	}
}
