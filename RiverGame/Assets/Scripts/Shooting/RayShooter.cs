﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
	[SerializeField] private GameObject projectile;

	private List<string> targets;
	private Vector3 target;
	[SerializeField] private float interval;
	private bool shouldShoot;

	private float time;

	public void Start()
	{
		Vector3 pos = new Vector3 (transform.position.x + 10, transform.position.y, transform.position.z);
		time = Time.time;

		targets = new List<string>();
		if (CompareTag("Enemy"))
		{
			targets.Add("Selected");
			targets.Add("Unselected");
		}
		else
		{
			targets.Add("Enemy");
			targets.Add("Enemy");
		}
	}

	public void Update()
	{
		shouldShoot = false;
		Collider[] objects = Physics.OverlapSphere(transform.position, 10f);
		for (int i = 0; i < objects.Length; i++) {
			
			if ((objects[i].CompareTag (targets[0]) || objects[i].CompareTag (targets[1]))) {
				target = objects[i].transform.position;
				shouldShoot = true;
				//Debug.Log(objects[i].name + " " + target);
				Shoot (target);
				return;
			}
		}
	}

	public void Shoot(Vector3 target)
	{
		//float speed = 0.1f; //projectile.GetComponent<ObstacleController>
		if (Time.time >= time + interval) 
		{
			time = Time.time;
			Vector3 pos;
			float x = target.x < transform.position.x ? -2f : 2f; 
			pos = new Vector3(transform.position.x + x, transform.position.y + 1.5f, transform.position.z);
			GameObject proj = Instantiate(projectile, pos, Quaternion.identity);
			proj.transform.localScale = new Vector3(1 / transform.localScale.x, 1 / transform.localScale.y, 1 / transform.localScale.z);
			float accuracy = 10f - GetComponent<AIController>().GetAccuracy();
			proj.GetComponent<ProjectileController>().SetTarget(new Vector3(target.x + Random.Range(-accuracy, accuracy),
																			target.y,
																			target.z + Random.Range(-accuracy, accuracy)));

		}
	}
}
