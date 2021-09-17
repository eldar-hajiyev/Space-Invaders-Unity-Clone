using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public static ScoreManager Instance { get; private set; }
	
	public event Action<int> OnScoreChanged; 
	public event Action<int> OnHighScoreChanged; 
	
	private int points;
	private int highscore;
	
	private const string HighscoreKey = nameof(HighscoreKey);
	
	void Awake() {
		Instance = this;
		highscore = PlayerPrefs.GetInt(HighscoreKey, 0);
	}

	void Start()
	{
		GameFlowManager.Instance.OnGameEnded += UpdateHighScore;
	}

	void OnDestroy() {
		if (points > highscore) {
			PlayerPrefs.SetInt (HighscoreKey, points);
		}
	}

	public void AddScore(int score) {
		points += score;
		OnScoreChanged?.Invoke(points);
	}

	public int GetHighscore() {
		return highscore;
	}

	public int GetPoints() {
		return points;
	}

	public void UpdateHighScore() {
		if (points > highscore) {
			OnHighScoreChanged?.Invoke(points);
			PlayerPrefs.SetInt (HighscoreKey, points);
		}
	}
}
