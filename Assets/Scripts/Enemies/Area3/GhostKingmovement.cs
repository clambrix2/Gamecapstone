using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostKingmovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform player;
    public float movementtimer;
    public bool inranged;
    private int randomone;
    private int randomtwo;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movementtimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (inranged)
        {

            
                
                movement();
                if(movementtimer <= 0)
                {
                randomone = Random.Range(-5,5);
                randomtwo = Random.Range(-1, 4);
                movementtimer = 2;
                }
                else
                {
                movementtimer = movementtimer - Time.deltaTime;
                }
          
        }
    }
    public void movement()
    {
        rb.MovePosition(Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x + randomone, player.transform.position.y + randomtwo), 1));
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            inranged = true;
            player = collision.gameObject.transform;
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject.transform;
            
        }
    }
}
