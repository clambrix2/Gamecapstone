using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        move();
    }
    private void move()
    {
        rb.velocity = new Vector2(speed * 1, rb.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerHealthandMana.sethealth(2);
            Destroy(this.gameObject);
        }
        if(collision.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
    }
}
