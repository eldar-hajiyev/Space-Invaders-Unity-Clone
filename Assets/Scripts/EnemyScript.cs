using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour, IEnemyHit, IEnemyScore {

	public Rigidbody2D bullet;
	public int score;

	public void Fire () {
		float x = transform.position.x;
		float y = transform.position.y - 0.4f;
		Instantiate (bullet, new Vector2 (x, y), Quaternion.identity);
	}

	public void Hit() {
		Destroy(gameObject);
	}

	public int GetScore() {
		return score;
	}
}
