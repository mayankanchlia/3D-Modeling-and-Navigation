using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Leap;
using Leap.Unity;

public class MenuManager : MonoBehaviour {


	LeapProvider provider;
	GameObject head;
	GameObject headmount;
	public bool isactive = false;

	// Use this for initialization
	void Start () {
		provider = FindObjectOfType<LeapProvider>() as LeapProvider;

		GameObject.Find ("ColourCanvas").GetComponent<ColourMenuManager>().enabled = false;

		head = GameObject.Find ("CenterEyeAnchor");
		headmount = GameObject.Find ("LMHeadMountedRig");

		Vector3 headDirection = head.transform.forward;
		headDirection.y = 0;

		Debug.Log (this.gameObject.GetComponent<RectTransform> ().position);
		Vector3 h = headmount.transform.position;
		this.gameObject.GetComponent<RectTransform> ().position = new Vector3(100,1000,100);
		Debug.Log (this.gameObject.GetComponent<RectTransform> ().position);
	}
	
	// Update is called once per frame
	void Update () {
		Frame frame = provider.CurrentFrame;

		Vector3 headDirection = head.transform.forward;
		Quaternion RotationVe	= head.transform.rotation;
		headDirection.y = 0;

		Vector3 headmountPosition = headmount.transform.position; 

		if ((frame.Hands.Count > 1 && frame.Hands[0].GrabStrength == 0 && frame.Hands[1].GrabStrength == 1) || isactive ) {
			this.gameObject.GetComponent<RectTransform> ().position = headmountPosition + 0.35F * headDirection;
			this.gameObject.GetComponent<RectTransform> ().rotation = RotationVe;
			isactive = true;
		} else {
			this.gameObject.GetComponent<RectTransform> ().position = new Vector3(100,-1000,100);
			this.gameObject.GetComponent<RectTransform> ().rotation = RotationVe;
		}
	}
		
}
