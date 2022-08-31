using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    public int lives = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnEnable()
    {
        EventManager.OnPlayerDeath += loseLife;
    }

    private void OnDisable()
    {
        EventManager.OnPlayerDeath -= loseLife;
    }

    public void loseLife()
    {
        Debug.Log("player lost 1 life!");
        lives -= 1;
    }

    // unused but is here if we need it!
    private void gainLife()
    {
        Debug.Log("player gained 1 life!");
        lives += 1;
    }
}
