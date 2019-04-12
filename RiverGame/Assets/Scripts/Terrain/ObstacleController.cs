using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
	[SerializeField] private int damage;
	[SerializeField] private int health;

	public void Update()
	{
        float lastBoat = GameObject.Find("Boats").GetComponent<FleetManager>().FindLastBoatPosition();
        if (lastBoat - transform.position.z > 40f)
        {
            Destroy(gameObject);
        }

		if (health <= 0)
		{
			if(CompareTag("Enemy") || CompareTag("Obstacle"))
			{
				PlayerStats.points += 5;
				GameObject.Find("Canvas").GetComponent<GUIController>().UpdateGUI();
			}
			Destroy(gameObject);
		}
	}

	public int GetHealth()
	{
		return health;
	}

	public void SetHealth(int health)
	{
		this.health = health < 0 ? 0 : health;
		StartCoroutine(TakeDamage());
	}
	
	public IEnumerator TakeDamage() {
		Color oldColor = GetComponent<Renderer>().material.color;

		GetComponent<Renderer>().material.color = Color.white;
		yield return new WaitForSeconds(0.5f);
		GetComponent<Renderer>().material.color = oldColor;
	} 

	public void OnCollisionEnter(Collision other)
	{
		if (!CompareTag("Player") && other.gameObject.GetComponent<BoatController>() != null)
		{
			BoatController boat = other.gameObject.GetComponentInParent<BoatController>();
			boat.SetHealth(boat.GetHealth() - damage);
		}

		if (!CompareTag("Player") && other.gameObject.CompareTag("Player"))
		{
			ObstacleController obst = other.gameObject.GetComponent<ObstacleController>();
			SetHealth(health - obst.GetDamage());
		}
		
	}

	public void SetDamage(int damage) {
		this.damage = damage;
	}

	public int GetDamage() {
		return damage;
	}
}
