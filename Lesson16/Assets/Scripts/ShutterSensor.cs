using UnityEngine;
using System.Collections;

public class ShutterSensor : MonoBehaviour {

	GameObject shutter;
	
	void Start() {
		shutter = GameObject.Find("Shutter");
	}
	
	void OnTriggerExit(Collider other) {
		if (other.tag == "Player") {
			shutter.SetActive(true);
		}
	}
}
