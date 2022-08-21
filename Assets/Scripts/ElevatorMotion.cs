using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMotion : MonoBehaviour
{
    // gameobject to move (gameobject script is attached to)
    private GameObject elevator;

    [SerializeField]
    private float speed = 10.0f;
    [SerializeField]
    private float lowerBound = -10.0f;
    [SerializeField]
    private float upperBound = 10.0f;
    private float direction = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        elevator = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // move elevator
        elevator.transform.Translate(Vector3.up * speed * direction * Time.deltaTime);
        // check if elevator is at upper or lower bound
        if (elevator.transform.position.y >= upperBound)
        {
            direction = -1.0f;
        }
        else if (elevator.transform.position.y <= lowerBound)
        {
            direction = 1.0f;
        }
        // wait for a bit
        // StartCoroutine(Wait());
    }
}
