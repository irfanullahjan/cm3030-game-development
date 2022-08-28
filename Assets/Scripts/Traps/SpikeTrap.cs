using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public float timeBeforeRetract = 1.0f;

    private bool isRising = false;
    private bool isRetracting = false;

    [SerializeField]
    private GameObject[] points;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isRising)
        {
            if (Vector2.Distance(points[1].transform.position, transform.parent.gameObject.transform.position) > .1f)
            {
                transform.parent.gameObject.transform.position = Vector2.MoveTowards(transform.parent.gameObject.transform.position, points[1].transform.position, 10f * Time.deltaTime);
            }
            else
            {
                isRising = false;
            }
        }
        if (isRetracting)
        {
            if (Vector2.Distance(points[0].transform.position, transform.parent.gameObject.transform.position) > .1f)
            {
                transform.parent.gameObject.transform.position = Vector2.MoveTowards(transform.parent.gameObject.transform.position, points[0].transform.position, 10f * Time.deltaTime);
            }
            else
            {
                isRetracting = false;
            }
        }
    }

    IEnumerator WaitToRetract()
    {
        yield return new WaitForSeconds(timeBeforeRetract);
        isRetracting = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isRising = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (timeBeforeRetract > 0)
            {
                StartCoroutine(WaitToRetract());
            }
        }
    }
}
