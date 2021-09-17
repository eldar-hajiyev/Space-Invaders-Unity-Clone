using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunkerScript : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.CompareTag(Tags.EnemyBullet) || col.gameObject.CompareTag(Tags.PlayerBullet)) {
			Destroy (gameObject);
			Destroy (col.gameObject);
		}
	}
}
