using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectButton : MonoBehaviour {

	// Use this for initialization
	private FleetManager fleetManager;
	private GUIController controller;
	private int index;

	public void Start() {
		fleetManager = GameObject.Find("Boats").GetComponent<FleetManager>();
		controller = GameObject.Find("Canvas").GetComponent<GUIController>();
	}

	public void Select() {
		foreach(GameObject obj in controller.GetSprites())	
		{
			obj.GetComponent<Image>().color = Color.white;
		}
		GetComponent<Image>().color = Color.red;
		fleetManager.SetCurrentSelected(index);
		controller.UpdateSelected();
	}

	public void SetIndex(int i) {
		index = i;
	}
}
