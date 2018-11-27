using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentController : MonoBehaviour {

	[SerializeField] private float strength;
	
	public void OnTriggerStay(Collider other)
	{
		if (other.gameObject.GetComponent<BoatController>() != null)
		{
			BoatController boat = other.gameObject.GetComponent<BoatController> ();
			other.gameObject.transform.rotation = Quaternion.Euler(0f, transform.eulerAngles.y - 90f, 0f);

			float rotx = boat.GetSpeed() * strength * (transform.eulerAngles.y / 62.5f);
			float rotz = boat.GetSpeed() * strength;
			Rigidbody rigidbody = other.GetComponent<Rigidbody>();
			rigidbody.velocity = new Vector3(rotx, 1f, rotz);
		}
	}
}
