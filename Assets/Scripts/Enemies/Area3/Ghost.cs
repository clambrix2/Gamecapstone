using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    private Spell sp;
    private Enemies em;
    private Rigidbody2D rb;
    public GameObject player;
    private bool inranged;

    void Start()
    {
        inranged = false;
        rb = GetComponent<Rigidbody2D>();
        em = GetComponent<Enemies>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inranged)
        {
            move();
            turnaround();
        }
    }
    private void move()
    {
        rb.MovePosition(Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x, player.transform.position.y), em.speed));
    }
    private void turnaround()
    {
        if (player.transform.position.x <= transform.position.x - .1f)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            else if (player.transform.position.x >= transform.position.x + .1f)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
    }
    private void onhit(float d)
    {
        em.Health -= d;
        ondeath();
    }
    private void ondeath()
    {
        if(em.Health <= 0)
        {
            Destroy(this.gameObject);
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerHealthandMana.sethealth(em.damage);

        }
        if(collision.gameObject.CompareTag("Spell"))
        {
            sp = collision.gameObject.GetComponent<Spell>();
            onhit(sp.Damage);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealthandMana.sethealth(em.damage);

        }
    }
}
