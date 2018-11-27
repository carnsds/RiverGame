using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{
	//Overall Information
	[SerializeField] private GameObject lost;
	[SerializeField] private GameObject win;
	[SerializeField] private Text points;

	//Currently Selected Boat
	[SerializeField] private Text currentBoatName;
	[SerializeField] private Text currentBoatInfo;
	[SerializeField] private Text currentAnchor;
	private GameObject currentBoat;

	public void Update()
	{
		if (GameObject.FindGameObjectsWithTag("Selected") == null
		    && GameObject.FindGameObjectsWithTag("Unselected") == null)
		{
			lost.SetActive(true);
		}
	}

	public void RestartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void WinGame()
	{
		win.SetActive(true);
	}

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
			currentBoatInfo.text = "Health: " + currentBoat.GetComponent<BoatController> ().GetHealth()
								   + "\nDefense: " + currentBoat.GetComponent<BoatController>().GetDefense();
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
