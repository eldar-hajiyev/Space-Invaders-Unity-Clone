﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnControllerScript : MonoBehaviour {

	public float min = 0;
	public float max = 10;

	void Start () {
		GameFlowManager.Instance.OnGameStarted += FireInRandomTime;
	}

	void Update () {
		if (transform.childCount == 0)
			Destroy (gameObject);
	}

	void SelectForFire () {
		if (!LifeManager.Instance.IsPlayerDead() && transform.childCount > 0)
		{
			transform.GetChild (0).gameObject.GetComponent<EnemyScript> ().Fire ();
			FireInRandomTime();
		} 
	}

	private void FireInRandomTime() {
		float rand = Random.Range(min, max / 4);
		Invoke(nameof(SelectForFire), rand);
	}
}
