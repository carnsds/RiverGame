using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	[SerializeField] private int health;
	[SerializeField] private GameObject projectile;

	private float time;

	public void Start()
	{
		time = Time.time;
	}

	public void Update()
	{
		if (health <= 0)
		{
			Destroy(gameObject);
		}

		if (time + 3f < Time.time)
		{
			time = Time.time;
			Shoot();
		}
	}

	public void Shoot()
	{
		Vector3 pos = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z + 2f);
		GameObject proj = Instantiate(projectile, pos, Quaternion.identity, transform.parent);
		proj.GetComponent<Rigidbody>().velocity = new Vector3(10, 0, 0);
	}
}
