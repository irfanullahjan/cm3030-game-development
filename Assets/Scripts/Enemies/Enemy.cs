using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public float deathDelay = 0f;
    public int maxHealth = 100;
    int currentHealth;
    bool isDead = false;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("Hurt");

        //play get hit animation

        if(currentHealth <=0)
       {
           Die();
       }
    }
   
    void Die()
    {
        Debug.Log("Enemy Died");

        //Die animation
        animator.SetBool("IsDead", true);
        isDead = true;
        //Despawn Enemy
        Destroy (gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + deathDelay); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isDead)
        {
            if (collision.gameObject.tag == "Player")
            {
                animator.SetTrigger("Attack");
            }
        }
    }
}
