using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	private FleetManager fleet;
	private GameObject lastBoat;

	public void Start()
	{
		fleet = GameObject.Find("Boats").GetComponent<FleetManager>();
	}

	public void Update()
	{
		foreach (GameObject boat in fleet.boats)
		{
			if (boat != null && lastBoat == null)
			{
				lastBoat = boat;
			}
			else if (boat != null && boat.transform.position.z < lastBoat.transform.position.z)
			{
				lastBoat = boat;
			}
		}
	}

	public void FixedUpdate()
	{
		if (lastBoat != null)
		{
			Vector3 boatPos = lastBoat.transform.position;
			Vector3 newPos = new Vector3(boatPos.x, 30, boatPos.z);
			transform.position = Vector3.Lerp(transform.position, newPos, 2f);
		}
	}
}
