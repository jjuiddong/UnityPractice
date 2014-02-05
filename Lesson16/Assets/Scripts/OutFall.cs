using UnityEngine;
using System.Collections;

public class OutFall : MonoBehaviour {
	
	private GameObject pinballMachine;
		
	void Start() {
		pinballMachine = GameObject.Find("PinballMachine");
	}
	
	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.tag == "Player") {
			pinballMachine.SendMessage("BallSpawn");
			Destroy(collider.gameObject);
		}
	}
}
