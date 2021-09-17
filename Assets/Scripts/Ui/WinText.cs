using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinText : MonoBehaviour {

	private static Text winLabel;

	void Start () {
		winLabel = GetComponent<Text> ();
		winLabel.text = "";

		EnemyCounterManager.Instance.OnAllEnemiesDestroyed += DisplayScore;
	}

	void DisplayScore () {
		if (winLabel == null)
			return;
		winLabel.text = "You Win!\r\nScore: " + ScoreManager.Instance.GetPoints();
	}
}
