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
			Debug.Log("Boat");
			BoatController boat = other.gameObject.GetComponentInParent<BoatController>();
			boat.SetHealth(boat.GetHealth() - damage);
		}
	}

	public void SetDamage(int damage) {
		this.damage = damage;
	}

	public int GetDamage() {
		return damage;
	}
}
