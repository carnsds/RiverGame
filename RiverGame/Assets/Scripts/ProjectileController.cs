using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : ObstacleController
{
	private Vector3 target;
	[SerializeField] private float speed;


	new void OnCollisionEnter(Collision other)
	{
		base.OnCollisionEnter(other);
		Destroy(gameObject);
	}

	public void Update() {

		transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
		if(transform.position == target && gameObject != null) {
			Destroy(gameObject);
		}

	}

	public void SetTarget(Vector3 target) {
		this.target = target;

	}

}
