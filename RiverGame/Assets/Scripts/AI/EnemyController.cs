using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : AIController
{

    [SerializeField] private float speed;

    // Use this for initialization
    void Start()
    {
        if (speed <= 0) speed = 0.25f;
    }

    // Update is called once per frame
    new void Update()
    {
		base.Update();

        float lastBoat = GameObject.Find("Boats").GetComponent<FleetManager>().FindLastBoatPosition();
        if (lastBoat - transform.position.z > 20f)
        {
            Destroy(gameObject);
        }

        Collider[] objects = Physics.OverlapSphere(transform.position, 3f);
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i].CompareTag("Current"))
            {
                return;
            }
        }
		transform.Translate(0f, 0f, speed * Time.deltaTime);
    }

    public float GetSpeed()
    {
        return speed;

    }
}

