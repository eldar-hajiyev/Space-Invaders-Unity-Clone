using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {

	[SerializeField] Text gameoverLabel;
	[SerializeField] Text restartLabel;

	void Start () {
		gameoverLabel = GetComponent<Text> ();

		gameoverLabel.text = "";
		restartLabel.text = "";

		LifeManager.Instance.OnLivesEnded += OnLivesEnded;
		GameFlowManager.Instance.OnGameEnded += OnGameEnded;
	}

	private void OnLivesEnded() {
		gameoverLabel.text = "GAME OVER!";
	}

	private void OnGameEnded() {
		if (Application.platform == RuntimePlatform.Android)
			restartLabel.text = "Tap to restart game";
		else
			restartLabel.text = "press Space to restart game";
	}
}
