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
			boat.setHealth(boat.getHealth() - damage);
		}
	}

	public void SetDamage(int damage) {
		this.damage = damage;
	}

	public int GetDamage() {
		return damage;
	}
}
