using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
	[SerializeField] private int damage;

	public void OnCollisionEnter(Collision other)
	{
		if (other.transform.CompareTag("Player"))
		{
			if (other.gameObject.GetComponent<CrewController>() != null)
			{
				CrewController crew = other.gameObject.GetComponent<CrewController>();
				crew.SetHealth(crew.GetHealth() - damage);
			}
			else
			{
				print("Entering this");
				BoatController boat = other.gameObject.GetComponentInParent<BoatController>();
				boat.SetHealth(boat.GetHealth() - damage);
			}
		}
		else if (other.gameObject.GetComponent<EnemyController>() != null)
		{
			EnemyController enemy = other.gameObject.GetComponent<EnemyController>();
			enemy.SetHealth(enemy.GetHealth() - damage);
		}
	}

	public void SetDamage(int damage) {
		this.damage = damage;
	}

	public int GetDamage() {
		return damage;
	}
}
