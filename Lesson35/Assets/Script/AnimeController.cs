using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AnimeFrame))]

public class AnimeController : MonoBehaviour {
private float animTime;
	private int index;
	private Mesh mesh;
	public float width;
	public float height;
	public AnimeFrame[] animeFrams;

	// Use this for initialization
	void Start () {	
		MeshFilter meshfilter = (MeshFilter)GetComponent("MeshFilter");
		mesh = meshfilter.mesh;
	}
	
	// Update is called once per frame
	void Update () {
		animTime += Time.deltaTime*100;
		
		if(animTime > animeFrams[index].timing){
			animTime = 0;
			index++;
			if(index>=animeFrams.Length){
				index = 0;
			}
		}
		
		Vector2 b = new Vector2(animeFrams[index].x, animeFrams[index].y);
		
	    Vector2[] uv = new Vector2[mesh.vertices.Length];
	    uv[0] = b + new Vector2(width, 0.0f);
	    uv[1] = b + new Vector2(0.0f, height);
	    uv[2] = b + new Vector2(0.0f, 0.0f);
	    uv[3] = b + new Vector2(width, height);
	    mesh.uv = uv;
	}

	[System.Serializable]
	public class AnimeFrame {
		public float timing;
		public float x;
		public float y;
	}
}
