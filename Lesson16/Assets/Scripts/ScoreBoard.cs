using UnityEngine;
using System.Collections;

public class ScoreBoard : MonoBehaviour {
	
	private int totalScore;
	
	void ApplyPoint(int score) {
		totalScore += score;
		guiText.text = "Score:" + totalScore;
	}
}
