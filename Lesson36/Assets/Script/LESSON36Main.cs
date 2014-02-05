using UnityEngine;
using System.Collections;

[ExecuteInEditMode()]
public class LESSON36Main: MonoBehaviour {
	public GUISkin guiskin;
	public Light mainLight;
	private CameraView cameraView;
	private float rotY=0.0f;
	private bool visibleWindow = false;
	private Rect windowRect = new Rect(Screen.width/2-100, Screen.height/2-50, 200, 100);

	// Use this for initialization
	void  Start () {
		cameraView = (CameraView)GetComponent("CameraView");
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnGUI(){
		GUI.skin = guiskin;
		//title bar
		GUI.Box(new Rect(0, 0, Screen.width, 36), "Lesson36", "Titlebar");
		
		//menu box
		GUI.Box(new Rect(0, Screen.height-72, Screen.width, Screen.height), "", "Menubar");
		GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
			GUILayout.FlexibleSpace();
			GUILayout.BeginHorizontal();
				GUILayout.FlexibleSpace();
		        if (GUILayout.Button("Shot", "Shot"))
		        {
					if(cameraView.isPlaying()){
			            cameraView.Pause();
					}
					else{
			            cameraView.Play();
					}
		        }
				GUILayout.FlexibleSpace();
		        if (GUILayout.Button("Rotete", "Rotate"))
		        {
					rotY+=90.0f;
					Vector3 rot = new Vector3(0, rotY, 0);
					transform.parent.Rotate(rot);
				}
				GUILayout.FlexibleSpace();
		        if (GUILayout.Button("Brightness", "Brightness"))
		        {
		            mainLight.enabled = !mainLight.enabled;
				}
				GUILayout.FlexibleSpace();
		        if (GUILayout.Button("About", "About"))
		        {
					visibleWindow = true;
				}
		
				GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
		GUILayout.EndArea();
		
		if(visibleWindow){
			windowRect = GUI.Window(0, windowRect, DoMyWindow, "About");
		}
	}
	
	void DoMyWindow(int windowID) {
		
		//Label Text
		GUI.Label (new Rect(60, 25, 240, 30), "Hello PhotoEater");
		
		//Button
		if(GUI.Button(new Rect(30, 60, 140, 30), "Close")){
			visibleWindow = false;
		}
		
		GUI.DragWindow(new Rect(0, 0, 10000, 20));
    }
}
