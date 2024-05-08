using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class Pheonix : MonoBehaviour
{
    public GameObject Player;
    public GameObject fireball;
    public Transform shootpoint;
    private Rigidbody2D rb;
    public bool player;
    public float attackonecooldown;
    public float attacktwocooldown;
    public float attackthreecooldown;
    private Animator animator;

    void Start()
    {
        attackonecooldown = 15;
        attacktwocooldown = 7;
        attackthreecooldown = 3;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((player))
        {
            animator.SetBool("inranged", true);
            turnaround();

            if (attackonecooldown <= 0)
            {
                attackone();
            }
            else if (attackthreecooldown <= 0)
            {
                attackthree();
            }
            else if (attacktwocooldown <= 0)
            {
                attacktwo();
            }
            else
            {
                attackonecooldown = attackonecooldown -= Time.deltaTime;
                
                attackthreecooldown = attackthreecooldown -= Time.deltaTime;
                rb.position = new Vector2 (rb.position.x, Player.transform.position.y + 3);
            }
            
        }
    }
    private void turnaround()
    {

        if (Player.transform.position.x <= transform.position.x - .1f)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Player.transform.position.x >= transform.position.x + .1f)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
    private void attackone()
    {
        rb.position = new Vector2(rb.position.x, Player.transform.position.y);
        if (Player.transform.position.x < gameObject.transform.position.x - .1f)
        {
            rb.position = new Vector2(rb.position.x, Player.transform.position.y); 
           rb.velocity = new Vector2(15 * -1, rb.velocity.y);
        }
        else if(Player.transform.position.x > gameObject.transform.position.x + .1f)
        {
            rb.velocity = new Vector2(15 * +1, rb.velocity.y);
        }
        attackonecooldown = 15;
    }
    private void attacktwo()
    {
       
    }
    private void attackthree()
    {
        rb.position = new Vector2(rb.position.x, Player.transform.position.y);
        Instantiate(fireball, shootpoint.transform.position, shootpoint.transform.rotation);
        attackthreecooldown = 3;
    }
    private void moveinbounds()
    {
        if(gameObject.transform.position.x < -258.53 - 20)
        {
            gameObject.transform.position = new Vector3 (-258.53f - 19, gameObject.transform.position.y, 0);
        }
        if(gameObject.transform.position.x > -258.53 + 20)
        {
            gameObject.transform.position = new Vector3(-258.53f + 19, gameObject.transform.position.y, 0);
        }
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Player = collision.gameObject;
            player = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player = collision.gameObject;
        }
    }
}
