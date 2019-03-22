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
			float roty = transform.eulerAngles.y;
			other.gameObject.transform.rotation = Quaternion.Euler(0f, roty, 0f);

			float rotx = roty < 180f ? boat.GetSpeed() * strength * (roty / 62.5f) : boat.GetSpeed() * strength * ((roty - 270f) / -90f);
			float rotz = boat.GetSpeed() * strength;
			Rigidbody rigidbody = other.GetComponent<Rigidbody>();
			rigidbody.velocity = new Vector3(rotx, 1f, rotz);
		}
	}
}
