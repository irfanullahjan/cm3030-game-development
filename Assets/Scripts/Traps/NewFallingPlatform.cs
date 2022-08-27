using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewFallingPlatform : MonoBehaviour
{
    public float timeBeforeFall = 3f;
    public float timeBeforeRise = 6f;
    public float speed = 2f;

    [SerializeField] private GameObject[] points;
    //private int pointIndex = 0;

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitToRise()
    {
        yield return new WaitForSeconds(timeBeforeRise);

        // rise distance
        // go opaque
        // turn on collider and trigger
    }

    IEnumerator WaitToFall()
    {
        Debug.Log("waiting");
        yield return new WaitForSeconds(timeBeforeFall);

        // animation stop flashing red

        // fall distance
        // and go transparent
        // turn off collider and trigger
        Debug.Log("falling");
        while (Vector2.Distance(points[0].transform.position, transform.parent.gameObject.transform.position) < .1f)
        {
            transform.position = Vector2.MoveTowards(transform.parent.gameObject.transform.position, points[1].transform.position, Time.deltaTime * speed);
        }

        if (timeBeforeRise > 0)
        {
            StartCoroutine(WaitToRise());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("landed");
            // animation start flashing red
            StartCoroutine(WaitToFall());
            return;
        }
    }
}
