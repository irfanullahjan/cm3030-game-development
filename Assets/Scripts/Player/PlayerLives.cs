using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    public int lives = 5;

    private GameObject GameController;
    private EventManager EventManager;

    // Start is called before the first frame update
    void Start()
    {
        GameController = GameObject.FindGameObjectWithTag("GameController");
        EventManager = GameController.GetComponent<EventManager>();
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
        lives -= 1;
        if(lives <= 0)
        {
            EventManager.PlayerLoses();
        }
    }

    // unused but is here if we need it!
    private void GainLife()
    {
        Debug.Log("player gained 1 life!");
        lives += 1;
    }
}
