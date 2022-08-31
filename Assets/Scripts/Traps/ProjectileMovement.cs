using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 2.0f;
    [SerializeField]
    private float distanceBeforeDestroy = 20f;

    public float respawnPointX;
    public float respawnPointY;

    //public Direction direction;

    private float distanceTravelled = 0;
    private Vector3 lastPos;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        lastPos = transform.position;
        rb = GetComponent<Rigidbody2D>();

        GetComponent<RespawnPlayer>().respawnPointX = respawnPointX;
        GetComponent<RespawnPlayer>().respawnPointY = respawnPointY;
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
