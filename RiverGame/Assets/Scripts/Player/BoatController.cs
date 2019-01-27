using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoatController : MonoBehaviour
{
	private int level;
	[SerializeField] private int health;
	[SerializeField] private int defense;
	[SerializeField] private float speed;
	private float constSpeed;
	private bool anchored;

	[SerializeField] private Sprite img;

	[SerializeField] private GameObject crewMember;
	private int numberOfSeats;
	private const int SEATS_NUM = 0;
	private const int CREW_NUM = 1;
	private const int BOAT_NUM = 2;

	private Vector3 waypoint;

	private int id;

	public void Start()
	{
		waypoint = Vector3.zero;
		constSpeed = speed;
		anchored = false;
		Anchor();
		GameObject.Find("Canvas").GetComponent<GUIController>().UpdateSelected();

		foreach (Transform t in transform.GetChild(SEATS_NUM).transform) {
			GameObject member = Instantiate(crewMember, new Vector3(t.position.x, t.position.y + 1f, t.position.z), Quaternion.identity, transform.GetChild(CREW_NUM));
		}
	}

	public void Update()
	{
		if (tag.Equals("Selected"))
		{
			transform.Translate(new Vector3(Input.GetAxisRaw("Vertical") * speed * Time.deltaTime,
											0f,
											-Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime));

			if (Input.GetMouseButtonDown(0)) {
				
				Ray point = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast(point, out hit, 50f)) {
					Debug.Log("Collider tag: " + hit.collider.tag + " Pos: " + hit.point);
					if (hit.collider.tag == "Current") {
						waypoint = new Vector3(hit.point.x, transform.position.y, hit.point.z);
						Debug.Log("Waypoint: " + waypoint + " Transform: " + transform.position);
					}
				}
			}								
		}
        Collider[] objects = Physics.OverlapSphere(waypoint, 0.1f);
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i].CompareTag("Selected") || objects[i].CompareTag("Unselected"))
            {
                SetAnchored(true);
				waypoint = Vector3.zero;
            }
        }
		if (waypoint != Vector3.zero) 
		{
			transform.position = Vector3.MoveTowards(transform.position, waypoint, speed * Time.deltaTime);
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
			GameObject.Find("Canvas").GetComponent<GUIController>().DisableText(id);
		}
	}

	public void Anchor()
	{
		anchored = !anchored;
		speed = anchored ? 0 : constSpeed;
		GameObject.Find("Canvas").GetComponent<GUIController>().UpdateSelected();
	}

	public void SetAnchored(bool anchor)
	{
		anchored = anchor;
		speed = anchored ? 0 : constSpeed;
		GameObject.Find("Canvas").GetComponent<GUIController>().UpdateSelected();
	}

	public bool GetAnchored()
	{
		return anchored;
	}

	/**
	 * When a boat is clicked on, mark it as selected.
	 **/
	public void OnMouseDown()
	{
		GetComponentInParent<FleetManager>().SetCurrentSelected(id);
		GameObject.Find("Canvas").GetComponent<GUIController>().UpdateSelected();
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
		GameObject.Find("Canvas").GetComponent<GUIController>().UpdateSelected();

		StartCoroutine(TakeDamage());
	}

	public int GetDefense()
	{
		return defense;
	}

	public void SetDefense(int defense)
	{
		this.defense = defense < 0 ? 0 : defense;
	}

	public Sprite GetImage() {
		return img;
	}
	
	public IEnumerator TakeDamage() 
	{
		Color oldColor = transform.GetChild(BOAT_NUM).GetComponent<Renderer>().material.color;

		transform.GetChild(BOAT_NUM).GetComponent<Renderer>().material.color = Color.red;
		yield return new WaitForSeconds(0.5f);
		transform.GetChild(BOAT_NUM).GetComponent<Renderer>().material.color = oldColor;
	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name.Equals("EndOfLevel"))
		{
			GameObject.Find("Canvas").GetComponent<GUIController>().WinGame();
		}
	}
}
