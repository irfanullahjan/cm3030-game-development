using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // if player crosses the finish line, load next level
        if (player.transform.position.x > transform.position.x)
        {
            // load next level
            Application.LoadLevel(Application.loadedLevel + 1);

            // add player to next level
            GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(0, 0, 0);
        }
    }
}
