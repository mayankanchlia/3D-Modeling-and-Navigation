using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTrigger : MonoBehaviour {
	public GameObject menu;
	public GameObject cam;
	// Use this for initialization
	void Start () {
		menu = GameObject.Find ("Canvas");
		Vector3 temp = new Vector3(0,3.5f,0.5f);
		menu.transform.position = temp; 
		Debug.Log (menu.transform.position.y);

		//menu.SetActive (false);

		//	menu.SetActive (true);
	}
	
	// Update is called onc	e per frame

/*	void Update () {
		
	//	menu.transform.position= new Vector3(0, 0, 0.5);
	}
	 private bool IsSwiping(bool left) // probably return a swipe enum? with every swipe
        {
            // Retrieve the most recent frame
            Leap.Frame frame = (_buffer.GetFrame() as LeapFrameAdapter).SDKFrame;

            if (!frame.IsValid)
            {
                return false;
            }

            Hand hand = frame.Hands.Rightmost;
            FingerList fingerList = hand.Fingers;
            GestureList gestureList = frame.Gestures();


            if (fingerList.Extended().Count >= 4 && gestureList.Count > 0)
            {
                bool allSwipe = true;

                string sDirection = string.Empty;

                foreach (Gesture gesture in gestureList)
                {
                    if (gesture.Type != Gesture.GestureType.TYPESWIPE || gesture.State != Gesture.GestureState.STATESTART)
                    {
                        allSwipe = false;
                        break;
                    }

                    SwipeGesture swipe = new SwipeGesture(gesture);
                    float fAbsX = Math.Abs(swipe.Direction.x);
                    float fAbsY = Math.Abs(swipe.Direction.y);
                    float fAbsZ = Math.Abs(swipe.Direction.z);

                    float handRoll = hand.PalmNormal.Roll;

                    if (fAbsX > fAbsY && fAbsX > fAbsZ)
                    {
                        if (swipe.Direction.x > 0 && handRoll > 0.5)
                        {
                            sDirection = "Right";

                        }
                        else if (swipe.Direction.x < 0 && handRoll < -0.5)
                        {
                            sDirection = "Left";
                        }
                    }
                }

                if (!allSwipe)
                    return false;

                if (sDirection.Equals("Right"))
                {
                    if (left)
                    {
                        return false;
                    }
                    return true; // right
                }
                else if (sDirection.Equals("Left"))
                {
                    if (left)
                    {
                        return true;
                    }
                    return false; // right
                }
            }

            return false;
        }

	*/


}
