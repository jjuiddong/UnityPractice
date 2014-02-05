using UnityEngine;
using System.Collections;

public class SoundEffect : MonoBehaviour {

	public AudioClip seClear;
	public AudioClip seScream;
	
	public void PlayClear() {
		audio.PlayOneShot(seClear);
	}
	
	public void PlayScream() {
		audio.PlayOneShot(seScream);
	}
}
