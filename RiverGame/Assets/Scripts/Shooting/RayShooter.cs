using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
	[SerializeField] private GameObject projectile;
	[SerializeField] private float range;

	[SerializeField] private List<string> targets;

	[SerializeField] private float interval;
	private float time;

	public void Start()
	{
		Vector3 pos = new Vector3 (transform.position.x + 10, transform.position.y, transform.position.z);
		time = Time.time;

		targets = new List<string>();
		if (CompareTag("Enemy"))
		{
			SetTargets("Selected", "Unselected", "Player");
		}
		else
		{
			SetTargets("Enemy", "Enemy", "Enemy");
		}
	}

	public void SetTargets(string t1, string t2, string t3)
	{
		targets = new List<string>();
		targets.Add(t1);
		targets.Add(t2);
		targets.Add(t3);
	}

	public void Update()
	{
		Collider[] objects = Physics.OverlapSphere(transform.position, range);
		for (int i = 0; i < objects.Length; i++) {
			
			if (objects[i].CompareTag(targets[0])
				|| objects[i].CompareTag(targets[1])
				|| objects[i].CompareTag(targets[2])) {
				Vector3 target = objects[i].transform.position;
				Shoot (target);
				return;
			}
		}
	}

	public void Shoot(Vector3 target)
	{
		if (Time.time >= time + interval) 
		{
			time = Time.time;
			Vector3 pos;
			float x = target.x < transform.position.x ? -2f : 2f; 
			pos = new Vector3(transform.position.x + x, transform.position.y + 1.5f, transform.position.z);
			GameObject proj = Instantiate(projectile, pos, Quaternion.identity);
			if (tag.Equals("Player"))
			{
				proj.tag = "Player";
			}
			proj.transform.localScale = new Vector3(1 / transform.localScale.x, 1 / transform.localScale.y, 1 / transform.localScale.z);
			float accuracy = 10f - GetComponent<AIController>().GetAccuracy();
			proj.GetComponent<ProjectileController>().SetTarget(new Vector3(target.x + Random.Range(-accuracy, accuracy),
																			target.y,
																			target.z + Random.Range(-accuracy, accuracy)));

		}
	}
}
