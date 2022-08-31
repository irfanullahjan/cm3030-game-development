using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Boss_Move : StateMachineBehaviour
{
    public float speed = 2.5f;
    public float attackRange = 3f;
    private int rand;


    Transform player;
    Rigidbody2D rb;
    BossTurn boss;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.Find("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<BossTurn>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        boss.LookAtPlayer();

        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);

        if (Vector2.Distance(target, newPos) <= attackRange)
        {
            rand = Random.Range(0, 3);

            if (rand == 1)
            {
                animator.SetTrigger("Attack");
            }
            else if (rand == 2)
            {
                animator.SetTrigger("Attack3");
            }
            else
            {
                animator.SetTrigger("Attack2");
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
        animator.ResetTrigger("Attack2");
        animator.ResetTrigger("Attack3");
    }
}

















