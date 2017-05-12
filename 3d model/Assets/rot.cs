using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

public class rot : MonoBehaviour {
	private Gyroscope gyro;
	LeapProvider provider;
	GameObject cam;
	GameObject hands;
	// Use this for initialization
	private float initialYAngle = 0f;
    private float appliedGyroYAngle = 0f;
    private float calibrationYAngle = 0f;
	void Start () {
		gyro = Input.gyro;
		Input.gyro.enabled = true;
		provider = FindObjectOfType<LeapProvider>() as LeapProvider;
		cam = GameObject.Find("LMHeadMountedRig");
		hands = GameObject.Find ("HandModels");
	}
	 void ApplyGyroRotation()
    {
        transform.rotation = Input.gyro.attitude;
        transform.Rotate( 0f, 0f, 180f, Space.Self ); // Swap "handedness" of quaternion from gyro.
        transform.Rotate( 90f, 180f, 0f, Space.World ); // Rotate to make sense as a camera pointing out the back of your device.
        appliedGyroYAngle = transform.eulerAngles.y; // Save the angle around y axis for use in calibration.
    }
	void ApplyCalibration()
    {
        transform.Rotate( 0f, -calibrationYAngle, 0f, Space.World ); // Rotates y angle back however much it deviated when calibrationYAngle was saved.
    }

	// Update is called once per frame
	/*void OnGUI(){
		GUILayout.Label ("Gyroscope attitude : " + gyro.attitude);
		GUILayout.Label ("Gyroscope gravity : " + gyro.gravity);
		GUILayout.Label ("Gyroscope rotationRate : " + gyro.rotationRate);
		GUILayout.Label ("Gyroscope rotationRateUnbiased : " + gyro.rotationRateUnbiased);
		GUILayout.Label ("Gyroscope updateInterval : " + gyro.updateInterval);
		GUILayout.Label ("Gyroscope userAcceleration : " + gyro.userAcceleration);
	}*/

void Update () {
		//		Vector3 inc = new Vector3 (0, 1, 0);
		//Vector3 init = this.gameObject.transform.eulerAngles;
		ApplyGyroRotation();
        ApplyCalibration();
		// cam.transform.rotation = Input.gyro.attitude;
		// Debug.Log (cam.transform.rotation);
	}
	
}
