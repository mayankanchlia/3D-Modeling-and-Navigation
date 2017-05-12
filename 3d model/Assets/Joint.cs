using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

public class Joint : MonoBehaviour {

	LeapProvider provider;
	public bool hasCollided = false;
	int time=0;
	// Use this for initialization
	void Start () {
		provider = FindObjectOfType<LeapProvider>() as LeapProvider;

	}
	
	// Update is called once per frame
	void Update () {
		if (hasCollided && this.gameObject.GetComponent<Rigidbody> ().isKinematic){
			Debug.Log ("mayank");
		this.gameObject.GetComponent<Rigidbody> ().isKinematic = false;
	}
	}

	void OnCollisionEnter (Collision collision)
	{
		Frame frame = provider.CurrentFrame;

		foreach (Hand hand in frame.Hands) {
			
			foreach (ContactPoint contact in collision.contacts)
			{	
				time = 0;
				Debug.Log ("Some collision");
				Debug.Log (collision.gameObject.name);
 				Debug.Log (hand.GrabStrength);
				if (hand.GrabStrength >= 0.8 && !collision.gameObject.name.Equals("Plane_playground")) {
					Debug.Log ("Collision detect");
					Debug.Log ( collision.gameObject.name);
					FixedJoint fixedJoint = this.gameObject.AddComponent<FixedJoint> () as FixedJoint;
					//fixedJoint.gameObject = this.gameObject;
					fixedJoint.anchor = contact.point - new Vector3 (0f, 0.1f, 0f);
					fixedJoint.connectedBody = collision.rigidbody;

					this.gameObject.GetComponent<Rigidbody> ().isKinematic = false;
					collision.rigidbody.GetComponent<Rigidbody> ().isKinematic = false;

					hasCollided = true;
				}
			}
		}
	}
}
