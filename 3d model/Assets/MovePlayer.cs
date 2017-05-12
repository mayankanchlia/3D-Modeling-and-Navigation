using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

public class MovePlayer : MonoBehaviour {

	public float velocity = 0.01f;
	LeapProvider provider;
	GameObject head;
	// Use this for initialization
	void Start () {
		provider = FindObjectOfType<LeapProvider>() as LeapProvider;
		head = GameObject.Find ("CenterEyeAnchor");
	}
	void position_update(){
		if (this.transform.position.x >= 49){
			//Debug.Log ("Asdasd");
			this.transform.position = new Vector3(49f,this.transform.position.y,this.transform.position.z) ; 	
		}
		if (this.transform.position.x <= -49){
			//Debug.Log ("Asdasd");
			this.transform.position = new Vector3(-49f,this.transform.position.y,this.transform.position.z) ; 	
		}
		if (this.transform.position.z >= 49){
			//Debug.Log ("Asdasd");
			this.transform.position = new Vector3(this.transform.position.x,this.transform.position.y,49f) ; 	
		}
		if (this.transform.position.z <= -49){
			//Debug.Log ("Asdasd");
			this.transform.position = new Vector3(this.transform.position.x,this.transform.position.y,-49f) ; 	
		}
	}
	// Update is called once per frame
	void Update () {
		
		//Debug.Log (this.transform.position.x);
		position_update();
		Frame frame = provider.CurrentFrame;
		//Debug.Log (Screen.width);
		Vector3 headDirection = head.transform.forward;
		headDirection.y = 0;

		foreach (Hand hand in frame.Hands) {
			if (hand.IsLeft) {
				if (hand.GrabStrength == 0  )
					this.transform.position -= velocity * headDirection;
				else if (hand.GrabStrength == 1)
					this.transform.position += velocity * headDirection;

			//	Debug.Log (headDirection);
			}
		}
	}
}
