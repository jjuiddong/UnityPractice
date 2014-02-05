using UnityEngine;
using System.Collections;

public class PinballMachine: MonoBehaviour {
	
	public GameObject ballPrefab;
	public Transform ballSpawnPoint;
	public Vector3 gravity;
	
	private GameObject shutter;

	void Start () {
		Physics.gravity = gravity;
		shutter = GameObject.Find("Shutter");
		BallSpawn();
	}
	
	void BallSpawn() {
		shutter.SetActive(false);
		Instantiate(ballPrefab, ballSpawnPoint.transform.position, Quaternion.identity);
	}
	
}
