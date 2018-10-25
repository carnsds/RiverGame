using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
	public int boatHealth;

	private int id;

	public void Start()
	{
		
	}
	
	public void Update()
	{
		if (boatHealth <= 0)
		{
			Destroy(gameObject);
		}
	}

	/**
	 * When a boat is clicked on, mark it as selected.
	 **/
	public void OnMouseDown()
	{
		tag = "Selected";
		GetComponentInParent<BoatManager>().setCurrentSelected(id);
	}

	public void setID(int id)
	{
		this.id = id;
	}

	public int getID()
	{
		return id;
	}
}
