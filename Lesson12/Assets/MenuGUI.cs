using UnityEngine;
using System.Collections;

public class MenuGUI : MonoBehaviour {

	void OnGUI() {
		// Stage 01ボタン表示
		if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 50, 100, 50), "Stage 01")) {
			// クリックされたらStage01シーンをロードする
			Application.LoadLevel("Stage01");
		}
		// Stage 02ボタン表示
		if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 110, 100, 50), "Stage 02")) {
			// クリックされたらStage02シーンをロードする
			Application.LoadLevel("Stage02");
		}
	}
}
