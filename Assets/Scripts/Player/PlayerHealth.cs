﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
	public int health = 100;

	// Where the player will respawn.
	private float respawnPointX;
	private float respawnPointY;
	public Slider healthBar;

	public GameObject deathEffect;

	private GameObject GameController;
	private EventManager EventManager;

	// Start is called before the first frame update
	void Start()
	{
		GameController = GameObject.FindGameObjectWithTag("GameController");
		EventManager = GameController.GetComponent<EventManager>();

		// set the respawn position to where the player starts in the level.
		respawnPointX = gameObject.transform.position.x;
		respawnPointY = gameObject.transform.position.y;
	}

	public void TakeDamage(int damage)
	{
		health -= damage;
		healthBar.value -= damage;
		StartCoroutine(DamageAnimation());

		if (health <= 0)
		{
			EventManager.PlayerDies();
			gameObject.transform.position = new Vector2(respawnPointX, respawnPointY);
		}
	}

	private void OnEnable()
	{
		EventManager.OnPlayerDeath += Die;
	}

	private void OnDisable()
	{
		EventManager.OnPlayerDeath -= Die;
	}

	void Die()
	{
		// anything that must be reset
		healthBar.value = healthBar.maxValue;
		health = 100;
	}

	IEnumerator DamageAnimation()
	{
		SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();

		for (int i = 0; i < 3; i++)
		{
			foreach (SpriteRenderer sr in srs)
			{
				Color c = sr.color;
				c.a = 0;
				sr.color = c;
			}

			yield return new WaitForSeconds(.1f);

			foreach (SpriteRenderer sr in srs)
			{
				Color c = sr.color;
				c.a = 1;
				sr.color = c;
			}

			yield return new WaitForSeconds(.1f);
		}
	}

}