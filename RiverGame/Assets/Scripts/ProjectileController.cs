using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : ObstacleController
{
	void OnCollisionEnter(Collision other)
	{
		base.OnCollisionEnter(other);
		Destroy(gameObject);
	}
}
