using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
	[SerializeField] private int health;
	[SerializeField] private float accuracy;
	[SerializeField] private int reward;
	public void Update()
	{
		if (health <= 0)
		{
			if(CompareTag("Enemy"))
			{
				PlayerStats.points += reward;
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
		GetComponent<Animator>().SetBool("isHit", true);
		Color oldColor = GetComponent<Renderer>().material.color;

		GetComponent<Renderer>().material.color = Color.white;
		yield return new WaitForSeconds(0.5f);
		GetComponent<Renderer>().material.color = oldColor;
		GetComponent<Animator>().SetBool("isHit", false);
	} 

	public float GetAccuracy() {
		return accuracy;
	}

	public void OnCollisionEnter(Collision other)
	{
		if ((CompareTag("Player") && other.gameObject.CompareTag("Obstacle"))
			|| (CompareTag("Enemy") && (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Obstacle"))))
		{
			ObstacleController obst = other.gameObject.GetComponent<ObstacleController>();
			SetHealth(health - obst.GetDamage());
		}
	}
}
