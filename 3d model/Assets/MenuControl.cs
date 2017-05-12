using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Leap;
using Leap.Unity;

public class MenuControl : MonoBehaviour {

	LeapProvider provider;
	// Use this for initialization
	void Start () {
		provider = FindObjectOfType<LeapProvider>() as LeapProvider;
		this.gameObject.GetComponent<MenuManager>().enabled = false;
		GameObject.Find ("ColourCanvas").GetComponent<ColourMenuManager> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		Frame frame = provider.CurrentFrame;
		if (frame.Hands.Count > 1 && frame.Hands [0].GrabStrength == 0 && frame.Hands [1].GrabStrength == 1) {
			this.gameObject.GetComponent<MenuManager>().enabled = true;
		}
	}
}
