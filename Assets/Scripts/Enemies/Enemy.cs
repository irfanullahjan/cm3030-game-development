using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public float deathDelay = 0f;
    public int maxHealth = 100;
    int currentHealth;
    bool isDead = false;
    public bool isInvulnerable = false;
    public Slider healthBar;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (isInvulnerable)
            return;

        currentHealth -= damage;
        healthBar.value -= damage;
        animator.SetTrigger("Hurt");

        if (currentHealth <= 200)
        {
            GetComponent<Animator>().SetBool("IsEnraged", true);
        }

        if (currentHealth <=0)
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
        //Destroy (gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + deathDelay); 
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
