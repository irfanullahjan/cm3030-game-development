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

    private GameObject GameController;
    private EventManager EventManager;

    // Start is called before the first frame update
    void Start()
    {
        GameController = GameObject.FindGameObjectWithTag("GameController");
        EventManager = GameController.GetComponent<EventManager>();
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

    IEnumerator WaitToDisplayWin()
    {
        //yield return new WaitForSeconds(this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + deathDelay);
        yield return new WaitForSeconds(3);
        EventManager.PlayerWins();
    }

    void Die()
    {
        Debug.Log("Enemy Died");

        //Die animation
        animator.SetBool("IsDead", true);
        isDead = true;
        //Despawn Enemy

        // make sure it is in the final phase.
        if (gameObject.name == "WrathP2") {
            // allow the boss to die.
            StartCoroutine(WaitToDisplayWin());
        }
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
