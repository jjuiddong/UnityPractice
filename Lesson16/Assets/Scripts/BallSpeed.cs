using UnityEngine;
using System.Collections;

public class BallSpeed : MonoBehaviour {
	
	public float maxVelocity = 30f;

	private float maxSqrVelocity;
	
	void Start () {
		maxSqrVelocity = maxVelocity * maxVelocity;
	}
	
	void FixedUpdate () {
		if (rigidbody.velocity.sqrMagnitude > maxSqrVelocity) {
			rigidbody.velocity = rigidbody.velocity.normalized * maxVelocity;
		}
	}
}
