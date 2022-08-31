using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrathPhase : MonoBehaviour
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
        GameObject.Find("Wrath").GetComponent<BossTurn>().enabled = false;
        GameObject.Find("Wrath").GetComponent<BossP1Attack>().enabled = false;
        GameObject.Find("Wrath").GetComponent<Enemy>().enabled = false;
        GameObject.Find("Wrath").GetComponent<WrathPhase>().enabled = false;
    }
}
