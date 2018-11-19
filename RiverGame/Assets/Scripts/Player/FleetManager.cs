using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Unity in Action 2nd Edition
public class FleetManager : MonoBehaviour
{
	public static int points;
	public List<GameObject> boats;

	private List<BoatController> boatControllers;
	private int currentSelected;

	public void Start()
	{
		currentSelected = 0;

		boatControllers = new List<BoatController>();
		/**
		 * Loads our boats into the scene.
		 **/
		Vector3 spawn = transform.position;
		for (int i = 0; i < boats.Capacity; i++)
		{
			Vector3 rot = new Vector3(90, 0, 0);

			GameObject inst = Instantiate(boats[i], transform.position, Quaternion.Euler(rot), transform);
			inst.name = "Boat" + i;
			{
				inst.transform.position = new Vector3 (spawn.x + (i * 4f),
					spawn.y,
					Random.Range (spawn.z - 3.5f, spawn.z + 3.5f));
			}
			

			//This replaces the prefab in the List with the actual object.
			boats[i] = inst;

			BoatController controller = (BoatController) inst.GetComponent<BoatController>();
			controller.SetID(i); //Assigns IDs based on order of instantiation.
			boatControllers.Add(controller);
		}
		boats[0].tag = "Selected";
	}
		

	/**
	 * This marks the ID of the currently selected boat. If no
	 * boat is selected (currentSelected = -1), then we only
	 * need to set currentSelected to the ID.
	 * 
	 * @param id The ID of the boat we're selecting
	 **/
	public void SetCurrentSelected(int id)
	{
		if (currentSelected != id)
		{
			FindBoatWithID(currentSelected).tag = "Unselected";
			FindBoatWithID(id).tag = "Selected";
			currentSelected = id;
		}
		else
		{
			currentSelected = id;
		}
	}

	public int GetCurrentSelected()
	{
		return currentSelected;
	}

	// public void UpdateIDs()
	// {
	// 	for (int i = 0; i < boats.ToArray ().Length; i++) 
	// 	{
	// 		boats[i].name = "Boat" + i;
	// 		boatControllers[i].setID(i);
	// 	}
	// }

	/**
	 * Looks through the list and returns the boat with the specified ID.
	 * 
	 * @param id The ID of the boat we're searching for.
	 * @return The boat with the given ID (null if there are none).
	 **/
	public GameObject FindBoatWithID(int id)
	{
		foreach (GameObject boat in boats)
		{
			if (boat != null && boat.GetComponent<BoatController>().GetID() == id)
			{
				return boat;
			}
		}
		return null;
	}

	// public void RemoveBoat(GameObject boat)
	// {
	// 	boatControllers.Remove(boat.GetComponent<BoatController>());
	// 	boats.Remove(boat);
	// }
}
