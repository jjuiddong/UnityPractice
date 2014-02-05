using UnityEngine;
using System.Collections;

public class TextLoader {
	private Hashtable tbl = new Hashtable();
	
	public TextLoader(){
	}
	
	public TextLoader(string filename){
		Debug.Log(Application.systemLanguage);
		string text = ((TextAsset)Resources.Load(filename)).text;
		Load(text);
	}
	
	public bool Load(string txt){
		string[] strings = txt.Split('\n');
		if(strings!=null && strings.Length>0){
			foreach(string s in strings){
				string[] pair = s.Split('=');
				if(pair!=null && pair.Length == 2){
					tbl.Add(pair[0].Trim(), pair[1].Trim());
				}
			}
			
			return true;
		}
		return false;
	}
	
	public string getString(string key){
		return (string)tbl[key];
	}
}
