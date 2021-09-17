using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreUpdateScript : MonoBehaviour {

	private Text highScoreLabel;

	void Start () {
		highScoreLabel = GetComponent<Text> ();
		ScoreManager scoreManager = ScoreManager.Instance;
		UpdateHighscore(scoreManager.GetHighscore());
		scoreManager.OnHighScoreChanged += UpdateHighscore;
	}

	void UpdateHighscore(int score)
	{
		highScoreLabel.text = $"HIGHSCORE: {score}";
	}
}
