using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	[SerializeField] private int health;
	[SerializeField] private float accuracy;

	public void Update()
	{
		if (health <= 0)
		{
			Destroy(gameObject);
		}
	}

	public float GetAccuracy() {
		return accuracy;
	}
}
