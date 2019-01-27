using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
	[SerializeField] private GameObject main;
	[SerializeField] private GameObject setNameMenu;

	public void NewGame(int game_state)
	{
		UnloadMenu(GameObject.Find("NewGame"));
		LoadMenu(setNameMenu);

		DBManager.GAME_STATE = game_state;
	}

	public void StartNewGame()
	{
		string gameName = setNameMenu.GetComponentInChildren<InputField>().text;
		if (gameName.Equals("") || gameName == null)
		{
			gameName = "Captain Bob";
		}
		PlayerStats.gameName = gameName;
		//DBManager.DropRow();
		SceneManager.LoadScene("SampleScene");
	}

	public void LoadGame(int game_state)
	{
		DBManager.GAME_STATE = game_state;
		PlayerStats.gameName = (string) DBManager.GetData()[0];

		SceneManager.LoadScene("SampleScene");
	}

	public void LoadMenu(GameObject menu)
	{
		menu.SetActive(true);
		main.SetActive(false);

	}

	public void UnloadMenu(GameObject menu)
	{
		menu.SetActive(false);
		main.SetActive(true);
	}
}
