using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
	private int value;
	public int store;

	private EnemyController[] enemies;

	//private GameObject enemy;
	private EnemyController enemy;

	// Use this for initialization
	void Start()
	{
		GameObject[] obj = GameObject.FindGameObjectsWithTag ("Enemy");
		enemies = new EnemyController[obj.Length];
		for (int i = 0; i < obj.Length; i++)
		{
			enemies[i] = obj[i].GetComponent<EnemyController>();
		}
	}
	
	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown (KeyCode.F)) {
			foreach (EnemyController i in enemies)
			{
				i.health -= 10;
			}
		}
	}
}
