using UnityEngine;
using System.Collections;

[ExecuteInEditMode()]
public class MessageConsole : MonoBehaviour {
	private string[] messages;
	private int linenum=0;
	private TextLoader textLoader;
	private bool blinkFlg;

	// Use this for initialization
	void Start () {
		TextAsset txt = (TextAsset)Resources.Load("messages");
		messages = txt.text.Split('\n');
		
		textLoader = new TextLoader("strings");
		
		StartCoroutine("blinkTimer");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.anyKeyDown){
			linenum++;
			if(linenum>=messages.Length){
				linenum = 0;
			}
		}
		
	}
	
	void OnGUI(){
		GUI.Box(new Rect(10, Screen.height-100, Screen.width-20, 90), "");
		GUI.Label(new Rect(20, Screen.height-90, Screen.width-40, 80), messages[linenum]);
		if((linenum+1)<messages.Length){
			if(blinkFlg){
				GUI.Label (new Rect(Screen.width-50, Screen.height-35, 45, 30), textLoader.getString("next"));
			}
		}
	}
				
	IEnumerator blinkTimer(){
		while(true){
			blinkFlg = !blinkFlg;
			yield return new WaitForSeconds(1.0f);
		}
	}
}
