using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyMovementScript : MonoBehaviour {

	public static float moveSpeed;
	
	Rigidbody2D collection;
	BoxCollider2D box;
	bool right = true;

	const float enemySize = 0.75f;
	
	void Start () {
		box = GetComponent<BoxCollider2D> ();
		collection = GetComponent<Rigidbody2D> ();
		MoveRight ();

		foreach (Transform child in transform) {
			child.gameObject.AddComponent<DestroyEventBehaviour>().OnDestroyEvent += OnColumnDestroy;
		}

		collection.velocity = Vector2.zero;
		LifeManager.Instance.OnLivesEnded += () => collection.velocity = Vector2.zero;
		GameFlowManager.Instance.OnGameStarted += MoveRight;
		var enemyCounterManager = EnemyCounterManager.Instance;
		enemyCounterManager.OnEnemyCountChanged += UpdateSpeed;
		UpdateSpeed(enemyCounterManager.GetEnemyCount());
	}

	void UpdateSpeed(int enemyCount) {
		moveSpeed = Mathf.Pow ((Mathf.Sqrt (56 - enemyCount) / (Mathf.Sqrt (Mathf.Pow (56, 2) - Mathf.Pow (enemyCount, 2)))) * 10, 3) - 0.25f;
	}

	void OnColumnDestroy() {
		UpdateBoxSize();
	}

	[ContextMenu("UpdateBoxSize")]
	void UpdateBoxSize() {
		if (box == null)
			box = GetComponent<BoxCollider2D> ();
		var children = transform.Cast<Transform>().ToArray();
		var maxXPosition = children.Max(child => child.transform.localPosition.x);
		var minXPosition = children.Min(child => child.transform.localPosition.x);
		var distance = maxXPosition - minXPosition;
		box.offset = new Vector2 ((maxXPosition + minXPosition) / 2f, box.offset.y);
		box.size = new Vector2 ((distance + enemySize), box.offset.y);
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.CompareTag(Tags.SideCollider)) {
			if (right) {
				right = false;
				MoveLeft ();
			} else {
				right = true;
				MoveRight ();
			}

			MoveDown ();
		} else if (col.gameObject.CompareTag(Tags.EndGame)) {
			LifeManager.Instance.GetDamage(int.MaxValue);
		}
	}

	void MoveRight () {
		collection.velocity = new Vector2 (moveSpeed, 0);
	}

	void MoveLeft () {
		collection.velocity = new Vector2(-moveSpeed, 0);
	}

	void MoveDown () {
		float x = transform.position.x;
		float y = transform.position.y - 0.2f;
		transform.position = new Vector2 (x, y);
	}
}
