using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float timeBeforeFall = 3.0f;
    public float timeBeforeReappear = 6.0f;
    public float speed = 2.0f;

    private bool isFalling = false;
    private bool isRising = false;

    [SerializeField]
    private GameObject[] points;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = transform.parent.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFalling)
        {
            anim.SetBool("hasStoodOn", false);
            if (Vector2.Distance(points[1].transform.position, transform.parent.gameObject.transform.position) > .1f)
            {
                transform.parent.gameObject.transform.position = Vector2.MoveTowards(transform.parent.gameObject.transform.position, points[1].transform.position, speed * Time.deltaTime);
            }
            else
            {
                // disable colliders
                transform.parent.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;

                isFalling = false;
                anim.SetBool("isFalling", isFalling);

                if (timeBeforeReappear > 0)
                {
                    StartCoroutine(WaitToReappear());
                }
            }
        }
        if (isRising)
        {
            if (Vector2.Distance(points[0].transform.position, transform.parent.gameObject.transform.position) > .1f)
            {
                transform.parent.gameObject.transform.position = Vector2.MoveTowards(transform.parent.gameObject.transform.position, points[0].transform.position, speed * Time.deltaTime);
            }
            else
            {
                // enable colliders
                transform.parent.gameObject.GetComponent<PolygonCollider2D>().enabled = true;
                gameObject.GetComponent<BoxCollider2D>().enabled = true;

                isRising = false;
                anim.SetBool("isRising", isRising);
            }
        }
    }

    IEnumerator WaitToReappear()
    {
        yield return new WaitForSeconds(timeBeforeReappear);
        isRising = true;
        anim.SetBool("isRising", isRising);
    }

    IEnumerator WaitToFall()
    {
        yield return new WaitForSeconds(timeBeforeFall);
        isFalling = true;
        anim.SetBool("isFalling", isFalling);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("hasStoodOn", true);
            StartCoroutine(WaitToFall());
            return;
        }
    }
}
