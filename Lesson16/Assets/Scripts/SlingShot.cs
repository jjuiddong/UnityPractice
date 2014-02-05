using UnityEngine;
using System.Collections;

public class SlingShot : MonoBehaviour {
	
	
	public Vector3 power = Vector3.zero;
	
	void OnCollisionEnter (Collision collision) {
		collision.rigidbody.AddForce(power);
	}
	
	
}
