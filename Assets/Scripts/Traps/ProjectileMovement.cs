using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float speed = 2.0f;
    public float distanceBeforeDestroy = 20f;

    //public Direction direction;

    private float distanceTravelled = 0;
    private Vector3 lastPos;

    private Rigidbody2D rb;

    //private float velocityX = 0.0f;
    //private float velocityY = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        lastPos = transform.position;
        rb = GetComponent<Rigidbody2D>();

        //if(direction == Direction.Left)
        //{
        //    velocityX = speed * -1;
        //}
        //if (direction == Direction.Right)
        //{
        //    velocityX = speed * 1;
        //}
        //if (direction == Direction.Up)
        //{
        //    velocityY = speed * 1;
        //}
        //if (direction == Direction.Down)
        //{
        //    velocityY = speed * -1;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = -transform.right * speed;
        distanceTravelled += Vector3.Distance(transform.position, lastPos);
        lastPos = transform.position;

        // check if gone too far.
        if(distanceTravelled >= distanceBeforeDestroy)
        {
            Destroy(gameObject);
        }
        //if(rb.transform.position.x < -50 || rb.transform.position.x > 250)
        //{
        //    Destroy(gameObject);
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
