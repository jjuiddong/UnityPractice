using UnityEngine;
using System.Collections;

public class BallTrail : MonoBehaviour {
	
	public float trailEnableSpeed = 6f;

	private TrailRenderer trailRenderer;
	
	void Start () {
		trailRenderer = GetComponent<TrailRenderer>();
	}
	
	void Update () {
		trailRenderer.enabled = (rigidbody.velocity.magnitude > trailEnableSpeed);
	}
	
}
