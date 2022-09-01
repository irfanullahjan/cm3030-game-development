using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void PlayerDeath();
    public static event PlayerDeath OnPlayerDeath;

    public delegate void PlayerLose();
    public static event PlayerDeath OnPlayerLose;

    public delegate void PlayerWin();
    public static event PlayerDeath OnPlayerWin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerDies()
    {
        Debug.Log("EventManager: The Player has died!");
        OnPlayerDeath?.Invoke();
    }

    public void PlayerLoses()
    {
        Debug.Log("EventManager: The Player has run out of lives. They lose!");
        OnPlayerLose?.Invoke();
    }

    public void PlayerWins()
    {
        Debug.Log("EventManager: The Player has killed the boss. They win!");
        OnPlayerWin?.Invoke();
    }
}
