using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;
public class hit : MonoBehaviour {

	LeapProvider provider;

	GameObject selection;
	bool selected = false;
	// Use this for initialization
	void Start () {
		provider = FindObjectOfType<LeapProvider>() as LeapProvider;
	}
	
	// Update is called once per frame
	void Update () {
		Frame frame = provider.CurrentFrame;

		foreach (Hand hand in frame.Hands) {
			/*RaycastHit hitInfo = new RaycastHit ();
			Ray ray = new Ray (hand.PalmPosition.ToVector3 (), hand.PalmNormal.ToVector3 ());
			bool hit = Physics.Raycast (ray, out hitInfo);
			if (hit) {
				Debug.Log ("Hit " + hitInfo.transform.gameObject.name);
				if (hitInfo.transform.gameObject.name == "Cube") {
					selection = hitInfo.transform.gameObject;
					if (hand.GrabStrength == 1)
						selected = true;
				} else {
					Debug.Log ("nopz");
				}
			} else {
				Debug.Log ("No hit");
			}
			//hitInfo.

			if (hand.GrabStrength == 0)
				selected = false;
			

			//if (selected)
				//selection.transform.position += new Vector3 (0.01f, 0.01f, 0.01f);
		*/}
	}
}
