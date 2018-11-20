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

	public void UpdateGUI()
	{
		points.text = "Points: " + PlayerStats.points;
	}

	public void UpdateSelected()
	{
		GameObject boat = GameObject.FindGameObjectWithTag("Selected");
		currentBoatName.text = boat.name;
		currentBoatHealth.text = "Health: " + boat.GetComponent<BoatController>().GetHealth();
	}
}
