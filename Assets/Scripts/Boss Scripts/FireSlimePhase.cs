using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSlimePhase : MonoBehaviour
{
    public GameObject Slime;
    public GameObject Boss;
    Renderer rend;
    BoxCollider2D col;
    Rigidbody2D rb; 


    
    void Start()
    {
        rend = Slime.GetComponent<SpriteRenderer>();
        rb = Slime.GetComponent<Rigidbody2D>();
        col = Slime.GetComponent<BoxCollider2D>();
        
    }
    void Update()
    {

    }
    public void Transform()
    {
        //Slime.SetActive(false);
        Boss.SetActive(true);
        rend.enabled = false;
        col.enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
        GameObject.Find("FireSlime").GetComponent<Enemy>().enabled = false;
        GameObject.Find("FireSlime").GetComponent<FireSlimePhase>().enabled = false;
    }
}
