using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
	[SerializeField] private int health;
	[SerializeField] private int defense;
	[SerializeField] private float speed;

	private int id;

	public void Update()
	{
		if (tag.Equals("Selected"))
		{
			transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime,
											Input.GetAxisRaw("Vertical") * speed * Time.deltaTime,
											0));
		}

		if (health <= 0)
		{
			if (isSelected()) {
				GetComponentInParent<FleetManager>().setCurrentSelected(-1);
			}
			Destroy(gameObject);
		}
	}

	/**
	 * When a boat is clicked on, mark it as selected.
	 **/
	public void OnMouseDown()
	{
		tag = "Selected";
		GetComponentInParent<FleetManager>().setCurrentSelected(id);
	}

	public void setID(int id)
	{
		this.id = id;
	}

	public int getID()
	{
		return id;
	}

	public bool isSelected()
	{
		return GetComponentInParent<FleetManager>().getCurrentSelected() == id;
	}

	public float getSpeed()
	{
		return speed;
	}

	public void setSpeed(float speed)
	{
		this.speed = speed;
	}

	public int getHealth()
	{
		return health;
	}

	public void setHealth(int health)
	{
		this.health = health < 0 ? 0 : health;
	}
}
