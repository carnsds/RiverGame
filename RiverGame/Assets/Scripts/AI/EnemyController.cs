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
    void Update()
    {
		base.Update();
        RaycastHit hit;
        Collider[] objects = Physics.OverlapSphere(transform.position, 2f);
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i].CompareTag("Current"))
            {
                return;
            }
        }
		transform.Translate(speed * Time.deltaTime, 0f, 0f);
    }

    public float GetSpeed()
    {
        return speed;

    }
}

