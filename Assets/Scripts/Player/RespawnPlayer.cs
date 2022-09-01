using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    // Where the player will respawn.
    public float respawnPointX;
    public float respawnPointY;

    private GameObject GameController;
    private EventManager EventManager;

    // Start is called before the first frame update
    void Start()
    {
        GameController = GameObject.FindGameObjectWithTag("GameController");
        EventManager = GameController.GetComponent<EventManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            EventManager.PlayerDies();
            collision.gameObject.transform.position = new Vector2(respawnPointX, respawnPointY);
        }
    }
}
