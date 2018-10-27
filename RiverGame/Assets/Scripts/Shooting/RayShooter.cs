using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
	[SerializeField] private GameObject projectile;

	private Ray ray;
	private float time;

	public void Start()
	{
		Vector3 pos = new Vector3 (transform.position.x + 10, transform.position.y, transform.position.z);
		ray = new Ray(transform.position, pos);
		time = Time.time;
	}

	public void Update()
	{
		RaycastHit hit;
		if(Physics.Raycast(transform.position, transform.right, out hit, 10))
		{
			if (Time.time >= time + 2f)
			{
				time = Time.time;
				Shoot ();
			}
		}
	}

	public void Shoot()
	{
		Vector3 pos = new Vector3(ray.origin.x + 2f, ray.origin.y + 1.5f, ray.origin.z);
		GameObject proj = Instantiate(projectile, pos, Quaternion.identity, transform.parent);
		proj.GetComponent<Rigidbody>().velocity = new Vector3(10, 0, 0);
	}
}
