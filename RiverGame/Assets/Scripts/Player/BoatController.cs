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
	private const int BOAT_NUM = 2;

	private int id;

	public void Start()
	{
		foreach (Transform t in transform.GetChild(SEATS_NUM).transform) {
			GameObject member = Instantiate(crewMember, new Vector3(t.position.x, t.position.y + 2.5f, t.position.z + 0.5f), Quaternion.identity, transform.GetChild(CREW_NUM));
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
		GetComponentInParent<FleetManager>().SetCurrentSelected(id);
	}

	public void SetID(int id)
	{
		this.id = id;
	}

	public int GetID()
	{
		return id;
	}

	public bool IsSelected()
	{
		return GetComponentInParent<FleetManager>().GetCurrentSelected() == id;
	}

	public float GetSpeed()
	{
		return speed;
	}

	public void SetSpeed(float speed)
	{
		this.speed = speed;
	}

	public int GetHealth()
	{
		return health;
	}

	public void SetHealth(int health)
	{
		this.health = health < 0 ? 0 : health;
		StartCoroutine(TakeDamage());
	}
	
	public IEnumerator TakeDamage() {
		Color oldColor = transform.GetChild(BOAT_NUM).GetComponent<Renderer>().material.color;

		transform.GetChild(BOAT_NUM).GetComponent<Renderer>().material.color = Color.red;
		yield return new WaitForSeconds(0.5f);
		transform.GetChild(BOAT_NUM).GetComponent<Renderer>().material.color = oldColor;
	} 
}
