using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletScript : MonoBehaviour {
	
	private Rigidbody2D bullet;

	public float speed = 5f;

	void Start () {
		bullet = GetComponent<Rigidbody2D> ();	
		bullet.velocity = new Vector2 (0, speed);
	}


	void OnBecameInvisible () {
		Destroy (gameObject);
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (GameFlowManager.Instance.IsGameEnded())
			return;
		if (col.gameObject.CompareTag(Tags.Enemy))
			Annihilate (col.gameObject);
		else if (col.gameObject.CompareTag(Tags.EnemyBullet) || col.gameObject.CompareTag(Tags.SideCollider))
			Destroy (gameObject);
	}

	void Annihilate (GameObject enemyGameObject) {
		Destroy (gameObject);
		enemyGameObject.GetComponent<IEnemyHit>()?.Hit();
		int? score = enemyGameObject.GetComponent<IEnemyScore>()?.GetScore();
		ScoreManager.Instance.AddScore(score ?? 0);
	}
}
