using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Leap;
using Leap.Unity;

public class ColourMenuManager : MonoBehaviour {

	LeapProvider provider;
	GameObject head;
	GameObject headmount;
	public bool isactive = false;
	// Use this for initialization
	void Start () {
		provider = FindObjectOfType<LeapProvider>() as LeapProvider;
		head = GameObject.Find ("CenterEyeAnchor");
		headmount = GameObject.Find ("LMHeadMountedRig");

		Vector3 headDirection = head.transform.forward;
		headDirection.y = 0;

		this.gameObject.GetComponent<RectTransform> ().position = new Vector3(100,-1000,100);
	}
	
	// Update is called once per frame
	void Update () {
		Frame frame = provider.CurrentFrame;

		Vector3 headDirection = head.transform.forward;
		Quaternion RotationVe	= head.transform.rotation;
		headDirection.y = 0;

		Vector3 headmountPosition = headmount.transform.position; 
		this.gameObject.GetComponent<RectTransform> ().position = headmountPosition + 0.35F * headDirection;
		this.gameObject.GetComponent<RectTransform> ().rotation = RotationVe;
	}
}
