using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{
	//Overall Information
	[SerializeField] private Text points;

	//Currently Selected Boat
	[SerializeField] private Text currentBoatName;
	[SerializeField] private Text currentBoatHealth;
	[SerializeField] private Text currentAnchor;
	private GameObject currentBoat;

	public void UpdateGUI()
	{
		points.text = "Points: " + PlayerStats.points;
	}

	public void UpdateSelected()
	{
		currentBoat = GameObject.FindGameObjectWithTag("Selected");
		if (currentBoat != null) 
		{
			currentBoatName.text = currentBoat.name;
			currentBoatHealth.text = "Health: " + currentBoat.GetComponent<BoatController> ().GetHealth();
			currentAnchor.text = currentBoat.GetComponent<BoatController>().GetAnchored() ? "Un-Anchor" : "Anchor";
		}
	}

	public void UpdateAnchor()
	{
		currentBoat = GameObject.FindGameObjectWithTag("Selected");
		if (currentBoat != null) 
		{
			currentBoat.GetComponent<BoatController>().Anchor();
			UpdateSelected();
		}
	}
}
