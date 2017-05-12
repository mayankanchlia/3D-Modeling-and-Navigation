using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;
public class Colour : MonoBehaviour {
	

	LeapProvider provider;
	public Vector3 sprayPosition;
	Texture2D tex;
	Renderer rd;
	Camera camera;
	GameObject ps;
	public Color paintColour = Color.red;
	public int sprayRadius = 3;

		void Start ()
		{
			provider = FindObjectOfType<LeapProvider>() as LeapProvider;
			rd = GetComponent<Renderer> ();
		ps = GameObject.Find("Particle Systefm");
			
		camera = GetComponent<Camera>();
		//Texture2D tex = (Texture2D) Resources.Load("circle-512");

		//Graphics.DrawTexture(
		//	new Rect(new Vector2(0,0),new Vector2(0.1f, 0.1f)),tex);

		}

		void Update ()
		{
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
			if(hand.IsRight && ps.GetComponent<ParticleSystem>().emission.enabled){
					//GetComponent<Renderer> ().material.color = Color.red;
					//Vector3 PalmDir = Quaternion.LookRotation (hand.PalmNormal.ToVector3 (), hand.Direction.ToVector3 ());
					Ray ray = new Ray(hand.PalmPosition.ToVector3 (), hand.PalmNormal.ToVector3 ());

				// PLANE SHUD BE ALIGNED
				Plane wall = new Plane(new Vector3(0.95f,0,0), transform.position);
				float distance = 0; 
				// if the ray hits the plane...
				RaycastHit hit;
				if (Physics.Raycast(ray,out hit )){//wall.Raycast(ray, out distance)){
					Texture2D tex = rd.material.mainTexture as Texture2D;
					Debug.Log (rd.material.mainTexture);
					MeshCollider meshCollider = hit.collider as MeshCollider;
					if (meshCollider == null)
						Debug.Log ("no collider");
					Vector2 pixelUV = hit.textureCoord;
					//Debug.Log (pixelUV);
					pixelUV.x *= tex.width;
					pixelUV.y *= tex.height;

					Circle (tex,(int) pixelUV.x, (int)pixelUV.y, sprayRadius, paintColour);
					//tex.SetPixel((int)pixelUV.x, (int)pixelUV.y, Color.black);
					//tex.Apply();
					// get the hit point:
					//temp.transform.position = ray.GetPoint(distance);

					//sprayPosition = ray.GetPoint(distance);

					//Vector3 screenPos = camera.WorldToScreenPoint(sprayPosition);
					//tex = (Texture2D) rd.material.mainTexture;
					//Debug.Log (tex.height);
					//Debug.Log (tex.width);

					//Circle (tex, (int) sprayPosition.x, (int) sprayPosition.y,1,Color.green);
					//tex.Apply ();
					//Texture2D tex = (Texture2D) Resources.Load("circle-512");
					//tex = (Texture2D) (Resources.Load("/walls/Texture/NewRenderTexture") as Texture);
					//GL.PushMatrix();
					//GL.LoadOrtho();
					//Graphics.DrawTexture(
						//new Rect(new Vector2((float) sprayPosition.x,(float) sprayPosition.y),new Vector2(0.1f, 0.1f)),tex);
					//Graphics.DrawTexture(
					//		new Rect(new Vector2(1,0),new Vector2(0.1f, 0.1f)),tex);
					//GL.PopMatrix();
					//Debug.Log(tex.dimension);
					//Debug.Log(sprayPosition);

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
