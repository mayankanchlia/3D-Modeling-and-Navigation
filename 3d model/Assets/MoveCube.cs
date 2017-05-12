using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

public class MoveCube : MonoBehaviour {

	bool AdjustZoom = false; 

	LeapProvider provider;
	GameObject wallObject;

	// Use this for initialization
	void Start () {
		provider = FindObjectOfType<LeapProvider>() as LeapProvider;

		wallObject = GameObject.Find("Cube");
		wallObject.transform.position = new Vector3(2, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		Frame frame = provider.CurrentFrame;

		foreach (Hand hand in frame.Hands) 
		{
			if (hand.IsLeft)
			{
				if (hand.GrabStrength == 1) 
				{
					wallObject.transform.position = wallObject.transform.position - (new Vector3(0.01f,0f,0f));
				}
				else if(hand.GrabStrength == 0)
					wallObject.transform.position = wallObject.transform.position + (new Vector3(0.01f,0f,0f));
			}
		}
	}
}
