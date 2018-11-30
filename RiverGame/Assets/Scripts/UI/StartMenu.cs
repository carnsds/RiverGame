using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
	[SerializeField] private GameObject main;

	public void NewGame()
	{
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
