using UnityEngine;
using System.Collections;

[ExecuteInEditMode()]
public class LESSON34HUD : MonoBehaviour {

	public GUISkin krSkin;
	public GUISkin usSkin;
	private int lngValue = 0;
	private string[] lngStrings = { "Korean", "English" };

    void OnGUI(){
        
		lngValue = GUI.Toolbar (new Rect (Screen.width - 230, 30, 200, 30),
		                       lngValue, lngStrings);

		if (lngValue == 0) {
			GUI.skin = krSkin;
		} else {
			GUI.skin = usSkin;
		}

        GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
            GUILayout.FlexibleSpace();
            drawLayout();
            GUILayout.FlexibleSpace();
        GUILayout.EndArea();
    }
    
    void drawLayout(){
        GUILayout.BeginVertical();
            GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                GUILayout.Label("", "title style");
                GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                GUILayout.Button("", "start style");
                GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                GUILayout.Button("", "exit style");
		        GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
        GUILayout.EndVertical();

    }
}
