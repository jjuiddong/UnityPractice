using UnityEngine;
using System.Collections;

public class Debri : MonoBehaviour {

	public float angle = 30f;
	public int score = 10;
	private Vector3 targetPos;

	// Use this for initialization
	void Start () {
		Transform target = GameObject.Find ("Earth").transform;
		targetPos = target.position;
		transform.LookAt (targetPos);
		transform.Rotate (new Vector3(0, 0, Random.Range(0,360)), Space.World);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 axis = transform.TransformDirection (Vector3.up);
		transform.RotateAround(targetPos, axis, angle * Time.deltaTime);
	}

	void OnMouseDown()
	{
		GameObject.Find ("Score").SendMessage ("AddScore", score);
		Destroy (gameObject);
	}
}
