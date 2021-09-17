using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionScript : MonoBehaviour {
	
	private Rigidbody2D laser;
	private Rigidbody2D player;

	public int fireBullet = 100;
	public float moveSpeed = 6f;
	public Rigidbody2D bullet;

	private GameFlowManager gameFlowManager;
	
	void Start () {
		player = GetComponent<Rigidbody2D> ();
		gameFlowManager = GameFlowManager.Instance;
	}

	void Update ()
	{
		if (!gameFlowManager.IsGameStarted())
			return;

		if (gameFlowManager.IsGameEnded()) {
			player.velocity = Vector2.zero;
			return;
		}
		
		if (Application.platform == RuntimePlatform.Android) {
			transform.Translate (new Vector3 (Input.acceleration.x, 0f, 0f));

			if (fireBullet > 0 && Input.touchCount > 0) {
				fireBullet--;
				float x = transform.position.x;
				float y = transform.position.y + 0.35f;
				laser = Instantiate (bullet, new Vector2 (x, y), Quaternion.identity);
			}

			if (laser == null)
				fireBullet = 1;
		} else {
			if (transform.position.x > -5.925f && Input.GetKey (KeyCode.A))
				player.velocity = new Vector2 (-moveSpeed, 0);
			else if (transform.position.x < 5.925f && Input.GetKey (KeyCode.D))
				player.velocity = new Vector2 (moveSpeed, 0);
			else
				player.velocity = Vector2.zero;

			if (fireBullet > 0 && Input.GetKeyDown (KeyCode.Space)) {
				fireBullet--;
				float x = transform.position.x;
				float y = transform.position.y + 0.35f;
				laser = Instantiate (bullet, new Vector2 (x, y), Quaternion.identity);
			}

			if (laser == null)
				fireBullet = 1;
		}
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.CompareTag(Tags.EnemyBullet)) {
			Destroy (col.gameObject);
			LifeManager.Instance.GetDamage();
		}
	}
}
