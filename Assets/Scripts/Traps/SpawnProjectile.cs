using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum Direction { Left, Right, Up, Down };

public class SpawnProjectile : MonoBehaviour
{
    public float spawnRate = 10.0f;
    //public Direction direction = Direction.Left;
    public GameObject projectile;

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
            //proj.GetComponent<ProjectileMovement>().direction = direction;

            timePassed = 0.0f;
        }
    }
}
