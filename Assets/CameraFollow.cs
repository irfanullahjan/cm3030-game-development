using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float smoothSpeed = 0.125f;

    private Vector3 offset;

    private float rightBound;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
        target = GameObject.FindGameObjectWithTag("Player").transform; 
        rightBound = GameObject.FindGameObjectWithTag("Finish").transform.position.x;  
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        if (transform.position.x > rightBound)
        {
            transform.position = new Vector3(rightBound, transform.position.y, transform.position.z);
        }
    }
}
