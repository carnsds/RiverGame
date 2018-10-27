using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	private FleetManager fleet;
	private GameObject followBoat;

	public void Start()
	{
		fleet = GameObject.Find("Boats").GetComponent<FleetManager>();
	}

	public void Update()
	{
		followBoat = boatToFollow();
	}

	public GameObject boatToFollow()
	{
		foreach (GameObject boat in fleet.boats)
		{
			if (boat != null)
			{
				if (followBoat == null)
				{
					return boat;
				}
				/*else if (boat.GetComponent<BoatController>().isSelected())
				{
					return boat;
				}*/
				else if (boat.transform.position.z < followBoat.transform.position.z)
				{
					return boat;
				}
			}
		}

		return null;
	}

	public void FixedUpdate()
	{
		if (followBoat != null)
		{
			Vector3 boatPos = followBoat.transform.position;
			Vector3 newPos = new Vector3(boatPos.x, 30, boatPos.z);
			transform.position = Vector3.Lerp(transform.position, newPos, 2f);
		}
	}
}
