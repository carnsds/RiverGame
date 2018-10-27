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
		int id = fleet.getCurrentSelected();
		return fleet.findBoatWithID(id);
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
