using UnityEngine;
using System.Collections;

public class Bumper : MonoBehaviour {

	public float power = 2f;
	public int point = 20;
	
	private GameObject scoreBoard;
	
	void Start() {
		scoreBoard = GameObject.Find("ScoreBoard");
	}
	
	void OnCollisionEnter(Collision collisionInfo) {
		Vector3 vel = (collisionInfo.transform.position - transform.position).normalized * power;
		collisionInfo.rigidbody.AddForce(vel);
		scoreBoard.SendMessage("ApplyPoint", point);
	}
}
