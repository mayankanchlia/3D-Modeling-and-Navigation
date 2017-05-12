using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Leap;
using Leap.Unity;

public class ButtonSetup : MonoBehaviour {

	public string buttonText = "Close";
	Button myButton;
	LeapProvider provider;

	void Start(){
		provider = FindObjectOfType<LeapProvider>() as LeapProvider;

		this.GetComponentInChildren<Text>().text = buttonText;
	}

	void Awake()
	{
		myButton = GetComponent<Button>(); // <-- you get access to the button component here

		myButton.onClick.AddListener(closeMenu); 
	}

	void Update(){
	}

	void closeMenu(){
		GameObject.Find ("Canvas").GetComponent<MenuManager>().isactive = false;
	}
}
