using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	enum DIRECTION {Right, Left}
	[SerializeField] private float rate;
	[SerializeField] private List<GameObject> enemies;
	private DIRECTION direction;
	private int num_enemies;
	private float length;
	private float width;
	private bool hasHappened;
	private BoxCollider _collider;
	// Use this for initialization
	void Start () {
		direction = (DIRECTION) Random.Range(0, 2);
		if (direction == DIRECTION.Left)
		{
			transform.Rotate(0f, 180f, 0f);
		}

		num_enemies = enemies.Count;
		_collider = GetComponent<BoxCollider>();
		length = _collider.size.z / 2f;	
		width = _collider.size.x / 2f;
		hasHappened = false;
	}
	
	public void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Unselected") || other.gameObject.CompareTag("Selected"))
		{
			for (int i = 0; i < num_enemies && !hasHappened; i++) {
				int r = Random.Range(0, num_enemies);

				Vector3 pos;
				if (direction == DIRECTION.Right)
				{
					pos = new Vector3(Random.Range(-width - 20f, -width) + transform.position.x,
									3.3f,
									Random.Range(-length, length) + transform.position.z);
				}
				else
				{
					pos = new Vector3(Random.Range(width, width + 20f) + transform.position.x,
									3.3f,
									Random.Range(-length, length) + transform.position.z);
				}
				Instantiate(enemies[r], pos, Quaternion.Euler(transform.rotation.eulerAngles));
			}

			hasHappened = true;
		}
	}
}
