using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFab : MonoBehaviour {
	public Transform brick;
	// Use this for initialization
	void Start () {
		Instantiate(brick, new Vector3(5, 10, 10), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
