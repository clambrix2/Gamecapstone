using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public bool relfect;
    public Enemyspell spell;
    public bool isleft;
    public GameObject enemy;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       spell = gameObject.GetComponent<Enemyspell>();
    }
    void Update()
    {
        if (relfect == false)
        {


            if (enemy.transform.position.x > this.gameObject.transform.position.x)
            {
                Enemyspell.move(-1);
            }
            else if (enemy.transform.position.x < this.gameObject.transform.position.x)
            {
                Enemyspell.move(1);
            }
        }
        else
        {
            
            Debug.Log("made it here so far");
            if (enemy.transform.position.x <= this.gameObject.transform.position.x)
            {
                Debug.Log("here");
                Enemyspell.move(-1);
            }
            else if (enemy.transform.position.x >= this.gameObject.transform.position.x)
            {
                Enemyspell.move(1);
            }
        }
        
    }
  
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealthandMana.sethealth(2);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemy = collision.gameObject;
        }
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Reflect"))
        {
            relfect = true;
            rb.velocity = new Vector2(0, 0);
        }
    }
    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealthandMana.sethealth(2);
            Destroy(this.gameObject);

        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemy = collision.gameObject;
        }
        
    }
}
