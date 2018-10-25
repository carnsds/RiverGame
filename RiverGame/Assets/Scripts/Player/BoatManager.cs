using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatManager : MonoBehaviour
{
	public List<GameObject> boats;

	private List<BoatController> boatControllers;
	private int currentSelected;
	private int lastSelected;

	public void Start()
	{
		currentSelected = -1;
		lastSelected = -1;

		boatControllers = new List<BoatController>();

		/**
		 * Loads our boats into the scene.
		 **/
		for (int i = 0; i < boats.Capacity; i++)
		{
			Vector3 rot = new Vector3(0, 0, 90);

			GameObject inst = Instantiate(boats[i], transform.position, Quaternion.Euler(rot), transform);
			inst.name = "Boat" + i;
			inst.transform.position = new Vector3 (Random.Range(-10, 10), 1, Random.Range(-10, 10));

			//This replaces the prefab in the List with the actual object.
			boats[i] = inst;

			BoatController controller = (BoatController) inst.GetComponent<BoatController>();
			controller.setID(i); //Assigns IDs based on order of instantiation.
			boatControllers.Add(controller);
		}
	}

	/**
	 * This marks the ID of the currently selected boat. If there is
	 * a previous it's saved to compare so we only deselect the boat
	 * if a new one is being selected.
	 * 
	 * @param id The ID of the boat we're selecting
	 **/
	public void setCurrentSelected(int id)
	{
		if (lastSelected != currentSelected)
		{
			findBoatWithID(currentSelected).tag = "Unselected";
			lastSelected = currentSelected;
			currentSelected = id;
		}
		else
		{
			currentSelected = id;
		}
	}

	public int getCurrentSelected()
	{
		return currentSelected;
	}

	/**
	 * Looks through the list and returns the boat with the specified ID.
	 * 
	 * @param id The ID of the boat we're searching for.
	 * @return The boat with the given ID (null if there are none).
	 **/
	public GameObject findBoatWithID(int id)
	{
		foreach (GameObject boat in boats)
		{
			if (boat.GetComponent<BoatController>().getID() == id)
			{
				return boat;
			}
		}
		return null;
	}
}
