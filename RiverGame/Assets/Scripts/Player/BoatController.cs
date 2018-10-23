using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Anything marked with the comment "RL", or surrounded
 * with that comment, indicates it needs to be removed
 * later once we're done using the examples.
 **/
public class BoatController : MonoBehaviour
{
	public int boatHealth;

	private EnemyController[] enemies; //RL
	private EnemyController enemy; //RL

	public void Start()
	{
		//RL TOP
		GameObject[] obj = GameObject.FindGameObjectsWithTag ("Enemy");
		enemies = new EnemyController[obj.Length];
		for (int i = 0; i < obj.Length; i++)
		{
			enemies[i] = obj[i].GetComponent<EnemyController>();
		}
		//RL BOTTOM
	}
	
	public void Update()
	{
		if (boatHealth >= 0)
		{
			Destroy(gameObject);
		}

		//RL TOP
		if (Input.GetKeyDown(KeyCode.F))
		{
			foreach (EnemyController i in enemies)
			{
				i.health -= 10;
			}
		}
		//RL BOTTOM
	}
}
