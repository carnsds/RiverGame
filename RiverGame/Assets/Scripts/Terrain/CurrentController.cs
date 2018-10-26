using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentController : MonoBehaviour {

	[SerializeField] private float strength;
	
	public void OnTriggerStay(Collider other)
	{
		if (other.gameObject.GetComponent<BoatController>() != null)
		{
			other.gameObject.transform.rotation = Quaternion.Euler(other.gameObject.transform.eulerAngles.x, transform.eulerAngles.y, 0);
		}
	}
}
