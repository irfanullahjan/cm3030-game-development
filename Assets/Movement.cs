using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10.0f;

    public float jumpForce = 10.0f;

    public bool isGrounded = true;

    // gameobject that is the player rigidbody
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveHorizontal * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }

        // if crosses finish line, load next level
        // get position of finish line
        Vector3 finishLine = GameObject.FindGameObjectWithTag("Finish").transform.position;

        if (transform.position.x > finishLine.x)
        {
            // load next level
            Application.LoadLevel(Application.loadedLevel + 1);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
