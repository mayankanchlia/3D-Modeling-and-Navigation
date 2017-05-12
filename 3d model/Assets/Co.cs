using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;
public class Co : MonoBehaviour {


	LeapProvider provider;
	public Vector3 sprayPosition;
	Texture2D tex;
	Renderer rd;
	Camera camera;
	GameObject ps;
	public Color paintColour = Color.red;
	public int sprayRadius = 10;

	void Start ()
	{
		provider = FindObjectOfType<LeapProvider>() as LeapProvider;
		rd = GetComponent<Renderer> ();
		//ps = GameObject.Find("Particle Systefm");

		//camera = GetComponent<Camera>();
		//Texture2D tex = (Texture2D) Resources.Load("circle-512");

		//Graphics.DrawTexture(
		//	new Rect(new Vector2(0,0),new Vector2(0.1f, 0.1f)),tex);
		sprayRadius = 3;

	}

	void Update ()
	{
		//this.gameObject.GetComponent<Rigidbody> ().isKinematic = true;
		this.gameObject.GetComponent<MeshCollider> ().enabled = true;
		this.gameObject.GetComponent<MeshCollider> ().convex = false;
		if(this.gameObject.GetComponent<Rigidbody>())
			this.gameObject.GetComponent<Rigidbody> ().isKinematic = true;

		Frame frame = provider.CurrentFrame;

		//ps.GetComponent<ParticleSystem> ().startColor = paintColour; 

		//ParticleSystem.MainModule settings = ps.GetComponent<ParticleSystem>().main;
		//settings.startColor = new ParticleSystem.MinMaxGradient(paintColour);

		foreach (Hand hand in frame.Hands)
		{
			/*
				if (hand.IsLeft) {
				/*transform.position = hand.PalmPosition.ToVector3 () +
				hand.PalmNormal.ToVector3 () *
				(transform.localScale.y * .5f + .02f);
					//GetComponent<Renderer> ().material.color = Color.black;
				// MENU
				if(hand.GrabStrength > 0.9)
					Debug.Log(hand.PalmPosition.ToVector3());
					
				}
			*/
			if(hand.IsRight && !(hand.GrabStrength == 1)){
				//GetComponent<Renderer> ().material.color = Color.red;
				//Vector3 PalmDir = Quaternion.LookRotation (hand.PalmNormal.ToVector3 (), hand.Direction.ToVector3 ());

				Vector3 headpos = GameObject.Find ("LMHeadMountedRig").transform.position;
				Vector3 diff = this.transform.position - headpos;
				float diffmag = diff.sqrMagnitude;

				if (diffmag < 50) {

					RaycastHit hitInfo = new RaycastHit ();
					Ray ray = new Ray (hand.PalmPosition.ToVector3 (), hand.PalmNormal.ToVector3 ());
					bool hit = Physics.Raycast (ray, out hitInfo);
					if (hit) {
						Debug.Log ("Hit " + hitInfo.transform.gameObject.name);
						Debug.Log (this.name);
						if (hitInfo.transform.gameObject.name == this.name) {
							//selection = hitInfo.transform.gameObject;
							Debug.Log ("CHALO");
							Texture2D tex = rd.material.mainTexture as Texture2D;
							Vector2 pixelUV = hitInfo.textureCoord;

							pixelUV.x *= tex.width;
							pixelUV.y *= tex.height;
							Debug.Log (pixelUV);
							Debug.Log (hitInfo.transform.gameObject.name);
							Debug.Log (tex);

							Circle (tex, (int)pixelUV.x, (int)pixelUV.y, sprayRadius, paintColour);

							if (hand.GrabStrength == 1)
							//selected = true;
							;
						} else {
							Debug.Log ("nopz");
						}
					} else {
						Debug.Log ("No hit");
					}
				}
			}
		}
	}



public void Circle(Texture2D tex, int cx, int cy, int r, Color col) 
{
		int x, y, px, nx, py, ny, d;
		Color32[] tempArray = tex.GetPixels32();

		for (x = 0; x <= r; x++)
		{
			d = (int)Mathf.Ceil(Mathf.Sqrt(r * r - x * x));
			for (y = 0; y <= d; y++)
			{
				px = cx + x;
				nx = cx - x;
				py = cy + y;
				ny = cy - y;

				try {
					tempArray[py*tex.width + px] = col;
					tempArray[py*tex.width + nx] = col;
					tempArray[ny*tex.width + px] = col;
					tempArray[ny*tex.width + nx] = col;
				}
				catch{
				}

			}
		}    
		tex.SetPixels32(tempArray);
		tex.Apply ();
}

}
