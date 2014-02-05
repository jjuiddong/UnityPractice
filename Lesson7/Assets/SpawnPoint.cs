using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {

	public GameObject debri;
	public float interval = 1f;
	private bool spawnStarted = false;

	void StartSpawn() {
		if (!spawnStarted) {
			spawnStarted = true;
			StartCoroutine("SpawnDebris");
		}
	}

	void StopSpawn() {
		if (spawnStarted) {
			spawnStarted = false;
			StopCoroutine("SpawnDebris");
		}
	}

	// Use this for initialization
	void Start () {
		//StartCoroutine ("SpawnDebris");	
	}
	
	// Update is called once per frame
	void Update () {
	}

	IEnumerator SpawnDebris() {
		while (true) {
			Instantiate (debri, transform.position, Quaternion.identity);
			yield return new WaitForSeconds(interval);
		}
	}

}
