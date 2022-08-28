using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crusher : MonoBehaviour
{
    public float timeBeforeFall = 4.0f;
    public float timeBeforeRise = 2.0f;
    public float speed = 10.0f;

    private bool hasFallen = false;
    private bool isRising = false;
    private bool isFalling = false;

    [SerializeField]
    private GameObject[] points;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    IEnumerator WaitToRise()
    {
        yield return new WaitForSeconds(timeBeforeRise);
        isRising = true;
    }

    IEnumerator WaitToFall()
    {
        yield return new WaitForSeconds(timeBeforeFall);
        isFalling = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasFallen)
        {
            hasFallen = true;
            anim.SetBool("isFlashingRed", true);
            StartCoroutine(WaitToFall());
        }

        if (isFalling)
        {
            anim.SetBool("isFlashingRed", false);
            if (Vector2.Distance(points[1].transform.position, gameObject.transform.position) > .1f)
            {
                transform.position = Vector2.MoveTowards(gameObject.transform.position, points[1].transform.position, speed * Time.deltaTime);
            }
            else
            {
                isFalling = false;
                StartCoroutine(WaitToRise());
            }
        }

        if (isRising)
        {
            if (Vector2.Distance(points[0].transform.position, gameObject.transform.position) > .1f)
            {
                transform.position = Vector2.MoveTowards(gameObject.transform.position, points[0].transform.position, speed * Time.deltaTime);
            }
            else
            {
                isRising = false;
                hasFallen = false;
            }
        }
    }
}
