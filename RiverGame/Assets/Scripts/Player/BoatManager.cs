using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatManager : MonoBehaviour
{
	private List<GameObject> boats;
	private List<BoatController> boatControllers;

	public void Start()
	{
		/**
		 * Fetches all the boats loaded into the scene and
		 * adds them to our BoatManager.
		 **/ 
		GameObject[] boats = GameObject.FindGameObjectsWithTag("Boat");
		foreach (GameObject boat in boats)
		{
			this.boats.Add(boat);
			boatControllers.Add(boat.GetComponent<BoatController>());
		}
	}
}
