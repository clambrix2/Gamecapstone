using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Knight : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject player;
    public GameObject sword;
    private Enemies em;
    private float attackdur;
    private bool inranged;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        em = GetComponent<Enemies>();
        attackdur = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (inranged)
        {
            move();
            if (player.transform.position.x > transform.position.x - 5f && player.transform.position.x < transform.position.x + 5f)
            {
                
                attack();
            }
            else
            {
                sword.SetActive(false);
            }
        }
    }
    private void move()
    {
        rb.MovePosition(Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x, player.transform.position.y), em.speed * Time.deltaTime));
    }
    private void attack()
    {
        
        if(attackdur <= 0 && attackdur >= -.5)
        {
            sword.SetActive(true);
            attackdur -= Time.deltaTime;
        }
        else if(attackdur == 3)
        {
            sword.SetActive(false);
            attackdur -= Time.deltaTime;
        }
        else if(attackdur <= -1)
        {
            attackdur = 3;
        }
        else
        {
            attackdur = attackdur - Time.deltaTime;
            Debug.Log(" ");
            Debug.Log(attackdur);
            Debug.Log("End");
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerHealthandMana.sethealth(em.damage);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            inranged = true;
            player = collision.gameObject;
        }
    }
}
