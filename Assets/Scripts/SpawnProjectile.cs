using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectile : MonoBehaviour
{
    public float spawnRate = 10.0f;
    private float timePassed = 0.0f;
    public GameObject projectile;

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
            Instantiate(projectile);
            timePassed = 0.0f;
        }
    }
}
