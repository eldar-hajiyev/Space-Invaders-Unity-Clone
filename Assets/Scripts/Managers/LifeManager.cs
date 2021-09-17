using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour {

	public GameObject player;

	public static LifeManager Instance { get; private set; }

	public event Action<int> OnLivesCountChanged;
	public event Action OnLivesEnded;
	
	int lives = 3;
	bool isPlayerDead;

	void Awake() {
		Instance = this;
	}

	public void GetDamage(int damage = 1) {
		lives = Mathf.Max(0,lives - damage);
		OnLivesCountChanged?.Invoke(lives);
		if (lives == 0) {
			player.gameObject.SetActive(false);
			isPlayerDead = true;
			OnLivesEnded?.Invoke();
		}
	}

	public bool IsPlayerDead() {
		return isPlayerDead;
	}
}
