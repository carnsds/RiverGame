using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
	[SerializeField] private int health;
	[SerializeField] private int defense;
	[SerializeField] private float speed;

	[SerializeField] private GameObject crewMember;
	private int numberOfSeats;
	private const int SEATS_NUM = 0;
	private const int CREW_NUM = 1;

	private int id;

	public void Start()
	{
		foreach (Transform t in transform.GetChild(SEATS_NUM).GetChild(SEATS_NUM).transform) {
			Instantiate(crewMember, t.position, Quaternion.identity, transform.GetChild(SEATS_NUM));
		}
	}

	public void Update()
	{
		if (tag.Equals("Selected"))
		{
			transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime,
											0,
											Input.GetAxisRaw("Vertical") * speed * Time.deltaTime));
		}

		if (health <= 0)
		{
			// FleetManager fleet = GetComponentInParent<FleetManager>();
			// fleet.RemoveBoat(gameObject);
			// fleet.UpdateIDs();


			// if (tag.Equals("Selected"))
			// {
			// 	fleet.setCurrentSelected(0);
			// }
			// Destroy(gameObject);
			tag = "Unselected";
			gameObject.SetActive(false);
		}
	}

	/**
	 * When a boat is clicked on, mark it as selected.
	 **/
	public void OnMouseDown()
	{
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
		StartCoroutine(TakeDamage());
	}
	
	public IEnumerator TakeDamage() {
		Color oldColor = GetComponent<Renderer>().material.color;

		GetComponent<Renderer>().material.color = Color.red;
		yield return new WaitForSeconds(0.5f);
		GetComponent<Renderer>().material.color = oldColor;
	} 
}
