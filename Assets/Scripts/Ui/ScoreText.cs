using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    private Text scoreLabel;
    
    void Start()
    {
        ScoreManager scoreManager = ScoreManager.Instance;
        scoreLabel = GetComponent<Text> ();
        UpdateScoreLabel(scoreManager.GetPoints());
        scoreManager.OnScoreChanged += UpdateScoreLabel;
    }

    void UpdateScoreLabel(int score) {
        scoreLabel.text = $"SCORE: {score}";
    }
}
