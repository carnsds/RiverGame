using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{
	//Menuing
	[SerializeField] private GameObject pauseMenu;
	[SerializeField] private GameObject pauseButton;

	//Overall Information
	[SerializeField] private GameObject lost;
	[SerializeField] private GameObject win;
	[SerializeField] private Text points;

	//Currently Selected Boat
	[SerializeField] private Text currentBoatName;
	[SerializeField] private Text currentBoatInfo;
	[SerializeField] private Text currentAnchor;

	[SerializeField] private FleetManager fleetManager;
	[SerializeField] private GameObject imageButton;
	private GameObject currentBoat;
	private List<GameObject> boatSprites;

	public void Start() 
	{
		boatSprites = new List<GameObject>();
		int index = 1;
		foreach(BoatController boat in fleetManager.GetBoatControllers()) 
		{
			Vector3 position = new Vector3(800 + 50 * index, 500, 0);
			GameObject obj = Instantiate(imageButton, position, Quaternion.identity, transform);
			obj.GetComponent<SelectButton>().SetIndex(index - 1);
			obj.GetComponent<Image>().sprite = boat.GetImage();
			obj.GetComponent<Button>().onClick.AddListener(delegate(){obj.GetComponent<SelectButton>().Select();});
			boatSprites.Add(obj);
			index++;
		}
	}

	public void Update()
	{
		if (GameObject.FindGameObjectsWithTag("Selected") == null
		    && GameObject.FindGameObjectsWithTag("Unselected") == null)
		{
			lost.SetActive(true);
		}
	}

	public void PauseGame()
	{
		if (Time.timeScale > 0)
		{
			Time.timeScale = 0;
			pauseMenu.SetActive (true);
			pauseButton.GetComponentInChildren<Text> ().text = "\u25B6";
		}
		else
		{
			Time.timeScale = 1;
			pauseMenu.SetActive (false);
			pauseButton.GetComponentInChildren<Text> ().text = " \u258C\u258C";
		}
	}

	public void RestartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void QuitGame()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("StartScene");
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

	public List<GameObject> GetSprites() 
	{
		return boatSprites;
	} 

	public void DisableText(int id)
	{
		boatSprites[id].GetComponentInChildren<Text>().text = "X";
		boatSprites[id].GetComponent<Button>().enabled = false;
	}
}
