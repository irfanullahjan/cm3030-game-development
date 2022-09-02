 using UnityEngine;
 using System.Collections;
 
 public class EnemyAI : MonoBehaviour {
 
    public Animator animator;
    public Transform target;
    public Transform attackPoint;
    public LayerMask playerLayers;

    public float speed = 2f;
    public float range = 15f;
    public float attackRange = 3f;
    public float attackDelay = 1;
    public float deathDelay = 0f;
    public int maxHealth = 100;

    private float timePassed = 1;
    // private bool isRunning = false;
    private float distance;
    private bool facingRight = false;
    private Vector3 previous;
    private float velocity = 0;
    private int currentHealth;
    private bool isDead = false;

    private Rigidbody2D _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
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
        _rigidbody.constraints = RigidbodyConstraints2D.FreezePositionY; // stop them from falling when we disable the collider
        this.GetComponent<BoxCollider2D>().enabled = false;
        Destroy (gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + deathDelay); 
    }

    void Attack()
    {
        new WaitForSeconds(0.5f);

        animator.SetTrigger("Attack");

        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);

        foreach (Collider2D player in hitPlayers)
        {
            player.GetComponent<PlayerHealth>().TakeDamage(10);
        }
    }

    void FixedUpdate ()
    {
        if (!isDead) 
        {
            distance = Vector2.Distance(transform.position, target.position);
            previous = transform.position;

            if (distance <= attackRange)
            {
                // wait for attack to be ready
                if (timePassed >= attackDelay) {
                    timePassed = 0;
                    Attack();
                }
            }

            if (distance > attackRange && distance <= range)
            {
                // Flip enemy if moving other way
                if (((transform.position - target.position)[0] > 0 && facingRight) 
                    || ((transform.position - target.position)[0] < 0 && !facingRight))
                {
                    Flip();
                }
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, transform.position.y), speed * Time.deltaTime);
            }

            if (timePassed < attackDelay) 
            {
                // increment passed time
                timePassed += Time.deltaTime;
            }

            velocity = ((transform.position - previous).magnitude) / Time.deltaTime;
            animator.SetFloat("Velocity", velocity);
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