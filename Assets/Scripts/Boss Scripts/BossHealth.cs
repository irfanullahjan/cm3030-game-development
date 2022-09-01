using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{

	public int health = 500;

	public bool isInvulnerable = false;

	private GameObject GameController;
	private EventManager EventManager;

	// Start is called before the first frame update
	void Start()
	{
		GameController = GameObject.FindGameObjectWithTag("GameController");
		EventManager = GameController.GetComponent<EventManager>();
	}

	public void TakeDamage(int damage)
	{
		if (isInvulnerable)
			return;

		health -= damage;

		//if (health <= 200)
		//{
		//	GetComponent<Animator>().SetBool("IsEnraged", true);
		//}

		if (health <= 0)
		{
			Die();
        }
	}

	void Die()
	{
		GetComponent<Animator>().SetBool("IsDead", true);

		EventManager.PlayerWins();
	}

}