using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Slime : MonoBehaviour
{
    private Enemies em;
    private Rigidbody2D rb;
    private Transform playerlocation;
    private bool playerinranged;
    private Transform old;
    private Animator animator;
    void Start()
    {
        em = GetComponent<Enemies>();
        rb = GetComponent<Rigidbody2D>();
        playerinranged = false;
        old = gameObject.transform;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerinranged)
        {
            animator.SetBool("inranged", true);
            flip();
            Move();
           
            
        }
        
    }
    private void Move()
    {
        
        
        rb.MovePosition(Vector2.MoveTowards(transform.position, new Vector2(playerlocation.position.x, playerlocation.position.y), em.speed));
    }
    private void flip()
    {
        if (playerlocation.transform.position.x <= transform.position.x - .1f)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (playerlocation.transform.position.x >= transform.position.x + .1f)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
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
