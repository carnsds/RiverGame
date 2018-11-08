using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{
	[SerializeField] private Text points;

	public void UpdateGUI()
	{
		points.text = "Points: " + PlayerStats.points;
	}
}
