using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

public class Splatter : MonoBehaviour {

	LeapProvider provider;
	Renderer rd;
	GameObject ps;
	Color colour;
	GameObject cube;
	// Use this for initialization
	void Start () {
		provider = FindObjectOfType<LeapProvider>() as LeapProvider;
		rd = GetComponent<Renderer> ();
		ps = GameObject.Find("Particle Systefm");
		cube = GameObject.Find ("Cube");
	}
	
	// Update is called once per frame
	void Update () {
		Frame frame = provider.CurrentFrame;

		foreach (Hand hand in frame.Hands)
		{
			if(hand.IsRight && hand.PinchStrength == 1){
				//GetComponent<Renderer> ().material.color = Color.red;
				//Vector3 PalmDir = Quaternion.LookRotation (hand.PalmNormal.ToVector3 (), hand.Direction.ToVector3 ());
				if(ps.GetComponent<ParticleSystem>().emission.enabled){
					RaycastHit hitInfo = new RaycastHit ();
					Ray ray = new Ray (hand.PalmPosition.ToVector3 (), hand.PalmNormal.ToVector3 ());
					bool hit = Physics.Raycast (ray, out hitInfo);
					if (hit) {
						Debug.Log ("Hit " + hitInfo.transform.gameObject.name);
						Debug.Log (this.name);
						if (hitInfo.transform.gameObject.name == this.name) {
						//selection = hitInfo.transform.gameObject;
							Debug.Log("CHALO");
							Texture2D tex = rd.material.mainTexture as Texture2D;
							Vector2 pixelUV = hitInfo.textureCoord;

							pixelUV.x *= tex.width;
							pixelUV.y *= tex.height;
							Debug.Log (pixelUV);
							Debug.Log (hitInfo.transform.gameObject.name);
							Debug.Log (tex);

							colour = cube.GetComponent<Colour>().paintColour;

							Splash(tex, (int)pixelUV.x, (int)pixelUV.y, 50, colour);

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
		
	public Color32[] getCircle(Texture2D tex, int cx, int cy, int r, Color col) 
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

		return tempArray;
	}

	public Color32[] getModifiedTexture(Texture2D tex,Color32[] tempArray, int cx, int cy, int r, Color col) 
	{
		int x, y, px, nx, py, ny, d;

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

		return tempArray;
	}


	public void Splash(Texture2D tex, int cx, int cy, int r, Color col){
		Color32[] splash = getCircle(tex,cx,cy,20, col);

		int n = 200;
		while (n-- > 0) {
			int x = Random.Range(0,r-20);
			int y = Random.Range(0,r-20);
			int sign = Random.Range (0, 4);
			int dir = Random.Range (0, 4);

			if (dir == 0) {
				if (sign == 0) {
					int x_center = cx + 20 + x;
					int y_center = cy + 20 - y;
					splash = getModifiedTexture (tex, splash, x_center, y_center, 2, col);
				} else if (sign == 1) {
					int x_center = cx + 20 - x;
					int y_center = cy + 20 + y;
					splash = getModifiedTexture (tex, splash, x_center, y_center, 2, col);
				} else if (sign == 2) {
					int x_center = cx + 20 + x;
					int y_center = cy + 20 + y;
					splash = getModifiedTexture (tex, splash, x_center, y_center, 2, col);
				} else if (sign == 3) {
					int x_center = cx + 20 - x;
					int y_center = cy + 20 - y;
					splash = getModifiedTexture (tex, splash, x_center, y_center, 2, col);
				}
			} else if(dir == 1){
				if (sign == 0) {
					int x_center = cx - 20 + x;
					int y_center = cy - 20 - y;
					splash = getModifiedTexture (tex, splash, x_center, y_center, 2, col);
				} else if (sign == 1) {
					int x_center = cx - 20 - x;
					int y_center = cy - 20 + y;
					splash = getModifiedTexture (tex, splash, x_center, y_center, 2, col);
				} else if (sign == 2) {
					int x_center = cx - 20 + x;
					int y_center = cy - 20 + y;
					splash = getModifiedTexture (tex, splash, x_center, y_center, 2, col);
				} else if (sign == 3) {
					int x_center = cx - 20 - x;
					int y_center = cy - 20 - y;
					splash = getModifiedTexture (tex, splash, x_center, y_center, 2, col);
				}
			} else if(dir == 2){
				if (sign == 0) {
					int x_center = cx + 20 + x;
					int y_center = cy - 20 - y;
					splash = getModifiedTexture (tex, splash, x_center, y_center, 2, col);
				} else if (sign == 1) {
					int x_center = cx + 20 - x;
					int y_center = cy - 20 + y;
					splash = getModifiedTexture (tex, splash, x_center, y_center, 2, col);
				} else if (sign == 2) {
					int x_center = cx + 20 + x;
					int y_center = cy - 20 + y;
					splash = getModifiedTexture (tex, splash, x_center, y_center, 2, col);
				} else if (sign == 3) {
					int x_center = cx + 20 - x;
					int y_center = cy - 20 - y;
					splash = getModifiedTexture (tex, splash, x_center, y_center, 2, col);
				}
			} else if(dir == 3){
				if (sign == 0) {
					int x_center = cx - 20 + x;
					int y_center = cy + 20 - y;
					splash = getModifiedTexture (tex, splash, x_center, y_center, 2, col);
				} else if (sign == 1) {
					int x_center = cx - 20 - x;
					int y_center = cy + 20 + y;
					splash = getModifiedTexture (tex, splash, x_center, y_center, 2, col);
				} else if (sign == 2) {
					int x_center = cx - 20 + x;
					int y_center = cy + 20 + y;
					splash = getModifiedTexture (tex, splash, x_center, y_center, 2, col);
				} else if (sign == 3) {
					int x_center = cx - 20 - x;
					int y_center = cy + 20 - y;
					splash = getModifiedTexture (tex, splash, x_center, y_center, 2, col);
				}
			}

		}

		tex.SetPixels32(splash);
		tex.Apply ();
	}
		
}
	