using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Fireghost : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject player;
    private Enemies em;
    private bool inranged;
    public float cooldown;
    private Vector3 pos;
    private Spell sp;
    public  Vector3 offset;
    public Transform shootpoint;
    public GameObject fireball;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pos = gameObject.transform.position;
        em = GetComponent<Enemies>();
    }

    // Update is called once per frame
    void Update()
    {
        if(inranged)
        {
            move();
            if(cooldown <= 0)
            {
                fire();
            }
            else
            {
                cooldown -= Time.deltaTime;
            }
            
        }
        else
        {
            rb.MovePosition(pos);
        }
    }
    private void move()
    {
        rb.MovePosition(player.transform.position - offset);
    }
    private void fire()
    {
        Instantiate(fireball, shootpoint.position, shootpoint.rotation);
        cooldown = 2;
    }
    private void damage(float d)
    {
        em.Health -= d;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Spell"))
        {
            sp = collision.gameObject.GetComponent<Spell>();
            damage(sp.Damage);
            if(em.Health <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject;
            inranged = true;
        }
    }
}
