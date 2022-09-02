using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    public int maxLives = 10;
    public int currentLives;

    public HealthBar healthBar;

    private GameObject GameController;
    private EventManager EventManager;

    // Start is called before the first frame update
    void Start()
    {
        GameController = GameObject.FindGameObjectWithTag("GameController");
        EventManager = GameController.GetComponent<EventManager>();

        currentLives = maxLives;
        healthBar.SetMaxHealth(maxLives);
    }

    private void OnEnable()
    {
        EventManager.OnPlayerDeath += LoseLife;
    }

    private void OnDisable()
    {
        EventManager.OnPlayerDeath -= LoseLife;
    }

    public void LoseLife()
    {
        Debug.Log("player lost 1 life!");
        currentLives -= 1;

        if(currentLives <= 0)
        {
            EventManager.PlayerLoses();
        }

        healthBar.SetHealth(currentLives);
    }

    // unused but is here if we need it!
    private void GainLife()
    {
        Debug.Log("player gained 1 life!");
        currentLives += 1;
        healthBar.SetHealth(currentLives);
    }
}
