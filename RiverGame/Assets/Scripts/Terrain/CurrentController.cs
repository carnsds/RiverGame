﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentController : MonoBehaviour {

	[SerializeField] private float strength;
	
	public void OnTriggerStay(Collider other)
	{
		if (other.gameObject.GetComponent<BoatController>() != null)
		{
			other.gameObject.transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);

			float rotx = other.gameObject.GetComponent<BoatController>().GetSpeed() * strength * (transform.eulerAngles.y / 62.5f);
			float rotz = other.gameObject.GetComponent<BoatController>().GetSpeed() * strength;
			Rigidbody rigidbody = other.GetComponent<Rigidbody>();
			rigidbody.velocity = new Vector3(rotx, 0, rotz);
		}
	}
}
