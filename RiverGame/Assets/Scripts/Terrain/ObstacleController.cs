using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
	[SerializeField] private int damage;

	public void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.GetComponent<BoatController>() != null)
		{	
			BoatController boat = other.gameObject.GetComponent<BoatController>();
			boat.SetHealth(boat.GetHealth() - damage);
		}
		else if (other.gameObject.GetComponent<AIController>() != null)
		{
			AIController ai = other.gameObject.GetComponent<AIController>();
			ai.SetHealth(ai.GetHealth() - damage);
		}
	}

	public void SetDamage(int damage) {
		this.damage = damage;
	}

	public int GetDamage() {
		return damage;
	}
}
