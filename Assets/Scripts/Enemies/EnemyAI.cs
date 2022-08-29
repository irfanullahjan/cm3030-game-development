 using UnityEngine;
 using System.Collections;
 
 public class EnemyAI : MonoBehaviour {
 
    public Animator animator;
    public Transform target;
    public float speed = 2f;
    public float range = 15f;
    private bool isRunning = false;
    private float minDistance = 3f;
    private float distance;
    private bool facingRight = false;

    void FixedUpdate ()
    {
        distance = Vector2.Distance(transform.position, target.position);

        if (distance > minDistance && distance <= range)
        {
            if (!isRunning) {
                animator.SetBool("IsRunning", true);
                isRunning = true;    
            }

            // Flip enemy if moving other way
            if (((transform.position - target.position)[0] > 0 && facingRight) 
                || ((transform.position - target.position)[0] < 0 && !facingRight))
            {
                Flip();
            }

            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else if (isRunning)
        {
            animator.SetBool("IsRunning", false);
            animator.SetTrigger("StopRunning");
            isRunning = false;
        }
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
 }