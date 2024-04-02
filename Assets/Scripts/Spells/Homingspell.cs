using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Homingspell : MonoBehaviour
{
    private Vector3 pos;
    private Rigidbody2D rb;
    public float lifeconter;
    public bool ishoming;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ishoming)
        {


            if (pos != new Vector3(0, 0, 0))
            {
                move();
            }
            else
            {
                lifeconter = lifeconter - Time.deltaTime;
            }

            if (lifeconter <= 0)
            {
                Destroy(this.gameObject);
                
            }
        }
        else
        {
            if(!ishoming) 
            {
                lifeconter = lifeconter - Time.deltaTime;
            }

            if (lifeconter <= 0)
            {
                Destroy(this.gameObject);
                
            }
        }

        
    }
    private void move()
    {

        rb.MovePosition(Vector2.MoveTowards(transform.position, new Vector2(pos.x, pos.y), .05f));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            pos = collision.transform.position;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            pos = collision.transform.position;
        }
    }
}
