using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour
{
    [SerializeField]
    private float force = 10f;

    private bool hasTriggered = false;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = transform.parent.gameObject.GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (hasTriggered && rb.angularVelocity==0)
        {
            Destroy(transform.parent.gameObject);
        }
    }
    IEnumerator minimumTime()
    {
        yield return new WaitForSeconds(1);
        hasTriggered = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rb.freezeRotation = false;
            rb.velocity = -transform.right * force;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(minimumTime());
        }
    }
}
