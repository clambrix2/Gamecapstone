using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bat : MonoBehaviour
{
    //public Transform player;
    private Enemies em;
    private Spell sp;
    private Rigidbody2D rb;
    private float gethitdamage;
    private float moveinput;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        em = GetComponent<Enemies>();
        moveinput = 5f;
    }

    // Update is called once per frame
    void Update()
    {
       
        //lookat();
        Move();
    }
    /*private void lookat()
    {
       var pos = player.position - transform.position;
        var rotation = Quaternion.LookRotation(pos).eulerAngles;
        transform.rotation = Quaternion.Euler(0, 0, rotation.x);
    }*/
    private void Move()
    {
        rb.velocity = new Vector2(em.speed, rb.velocity.y);
    }
    private void damage()
    {
        PlayerHealthandMana.sethealth(em.damage);
    }
    private void onhit()
    {
        em.Health -= gethitdamage;
    }
    private void ondeath()
    {
        if(em.Health <=0)
        {
            Destroy(this.gameObject);  
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            damage();
        }
        if (collision.gameObject.CompareTag("Spell"))
        {
            sp = collision.gameObject.GetComponent<Spell>();
            gethitdamage = sp.Damage;
            onhit();
            ondeath();
        
        }
        if(collision.gameObject.CompareTag("Wall"))
        {
            if (em.speed > -5)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);

                em.speed = -5;
            }
            else if (em.speed < 5f)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
                em.speed = 5;
                
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //player = collision.transform;
        }
        
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           // player = collision.transform;
        }
        
    }
}
