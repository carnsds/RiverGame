using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	public int health;
	
	public void Update()
	{
		if (health <= 0)
		{
			Destroy(gameObject);
		}
	}
}
