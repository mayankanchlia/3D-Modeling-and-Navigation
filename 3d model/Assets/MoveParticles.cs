using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

public class MoveParticles : MonoBehaviour {

	private ParticleSystem ps;
	LeapProvider provider;
	GameObject wallObject;
	Gradient grad = new Gradient();
	Color sprayColour;

	// Use this for initialization
	void Start () {
		provider = FindObjectOfType<LeapProvider>() as LeapProvider;
		ps = GetComponent<ParticleSystem>();

		var col = ps.colorOverLifetime;
		col.enabled = true;

		wallObject = GameObject.Find("Cube");
		Colour colour = wallObject.GetComponent<Colour>();
		sprayColour = colour.paintColour; 
		//Gradient grad = new Gradient();
		grad.SetKeys( new GradientColorKey[] { new GradientColorKey(sprayColour, 0.0f), new GradientColorKey(Color.red, 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) } );
		col.color = grad;

		var emission = ps.emission;
		emission.enabled = false;
	}

	// Update is called once per frame
	void Update () {
		Frame frame = provider.CurrentFrame;
		var emission = ps.emission;

		emission.enabled = false;

		GameObject wallObject = GameObject.Find("Cube");
		//if()

		wallObject = GameObject.Find("Cube");
		Colour colour = wallObject.GetComponent<Colour>();
		sprayColour = colour.paintColour; 
		//Gradient grad = new Gradient();
		grad.SetKeys( new GradientColorKey[] { new GradientColorKey(sprayColour, 0.0f), new GradientColorKey(Color.red, 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) } );
		ps = GetComponent<ParticleSystem>();
		var col = ps.colorOverLifetime;
		col.color = grad;


		foreach (Hand hand in frame.Hands) {
			if (hand.IsRight) {
				/*transform.position = hand.PalmPosition.ToVector3 () +
				hand.PalmNormal.ToVector3 () *
				(transform.localScale.y * .5f + .02f);*/
				emission.enabled = true;
				transform.position = hand.PalmPosition.ToVector3 ();
				//transform.rotation = hand.PalmNormal.ToVector4 ();
				transform.rotation = Quaternion.LookRotation (hand.PalmNormal.ToVector3 (), hand.Direction.ToVector3 ());
				//if (hand.GrabStrength >= 0.9)
				//	emission.enabled = false;
			} else {
				emission.enabled = false;
				if (hand.GrabStrength > 0.9)
					emission.enabled = true;
			}
		}
		//var c = GameObject.Find("Cube");
		//if (Physics.Linecast(transform.position, c.transform.position)) {
		//	Debug.Log ("blocked");
		//}
	}
}
