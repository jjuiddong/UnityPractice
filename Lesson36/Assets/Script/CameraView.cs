using UnityEngine;
using System.Collections;

public class CameraView : MonoBehaviour {
	private WebCamDevice[] devices;
	private string deviceName;
	private WebCamTexture webcamTexture;
	public int width;
	public int height;
	public int fps;

	// Use this for initialization
	IEnumerator  Start () {
		this.name = "CameraView";
		
		yield return Application.RequestUserAuthorization(UserAuthorization.WebCam | UserAuthorization.Microphone);
	    if (Application.HasUserAuthorization(UserAuthorization.WebCam | UserAuthorization.Microphone)) {
			devices = WebCamTexture.devices;
			deviceName = devices[0].name;
			webcamTexture = new WebCamTexture(deviceName, width, height, fps);
			renderer.material.mainTexture = webcamTexture;
			webcamTexture.Play();
			Debug.Log("FINE "+deviceName);
	    } else {
			Debug.Log("ERROR");
	    }
	}
	
	
	public bool isPlaying(){
		return webcamTexture.isPlaying;
	}
	
	public void Pause(){
		webcamTexture.Pause();
	}
	
	public void Play(){
		webcamTexture.Play();
	}
		
}
