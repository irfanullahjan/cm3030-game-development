using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum Direction { Left, Right, Up, Down };

public class SpawnProjectile : MonoBehaviour
{
    [SerializeField]
    private float spawnRate = 10.0f;
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private float respawnPointX = -50f;
    [SerializeField]
    private float respawnPointY = 0f;

    private float timePassed = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed > spawnRate)
        {
            GameObject proj = Instantiate(projectile, gameObject.transform.position, gameObject.transform.rotation);
            proj.GetComponent<ProjectileMovement>().respawnPointX = respawnPointX;
            proj.GetComponent<ProjectileMovement>().respawnPointY = respawnPointY;

            timePassed = 0.0f;
        }
    }
}
