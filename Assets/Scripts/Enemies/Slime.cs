using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Slime : MonoBehaviour
{
    private Enemies em;
    private Rigidbody2D rb;
    private Spell sp;
    private Transform playerlocation;
    private float gethitdamage;
    private bool playerinranged;
    void Start()
    {
        em = GetComponent<Enemies>();
        rb = GetComponent<Rigidbody2D>();
        playerinranged = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerinranged)
        {
            Move();
        }
        
    }
    private void onhit()
    {
        em.Health -= gethitdamage;
    }
    private void ondeath()
    {
        if(em.Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void Move()
    {
        
        rb.MovePosition(Vector2.MoveTowards(transform.position, new Vector2(playerlocation.position.x, playerlocation.position.y), em.speed));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerHealthandMana.sethealth(em.damage);
        }
        if (collision.gameObject.CompareTag("Spell"))
        {
            sp = collision.gameObject.GetComponent<Spell>();
            gethitdamage = sp.Damage;
            onhit();
            ondeath();

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.CompareTag("Player"))
        {
            playerlocation = collision.gameObject.GetComponent<Transform>();
            playerinranged=true;
        }
    }

}
