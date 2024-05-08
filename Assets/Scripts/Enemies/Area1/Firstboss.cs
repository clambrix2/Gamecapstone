using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Firstboss : MonoBehaviour
{
    private bool bossstart;
    public GameObject player;
    public GameObject darkorbs;
    public Transform shootpoint;
    public GameObject sword;
    public Animation swordanim;
    public Animator animator;
    private Animator animator2;
    private Rigidbody2D rb;
    public static bool killed;
    public int hits;
    public int Animationinfo;
    public float timer;
    public float majorattackcooldown;
    public bool gapcloserdone;
    public GameObject scroll;
    void Start()
    {
        bossstart = false;
        swordanim = sword.GetComponent<Animation>();
        rb = GetComponent<Rigidbody2D>();
        hits = 0;
        majorattackcooldown = 15;
        gapcloserdone = true;
        animator2 = GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if(bossstart)
        {
            animator2.SetBool("inranged", true);
            turnaround();
            if(majorattackcooldown <= 0)
            {
                Majorattack();
            }
            else if(player.transform.position.x >= transform.position.x - 2f && player.transform.position.x <= transform.position.x + 2f && gapcloserdone == false)
            {
                Debug.Log("Done");
                gapcloserdone = true;
            }
            else if (player.transform.position.x >= transform.position.x - 5f && player.transform.position.x <= transform.position.x + 5f && gapcloserdone)
            {
                animator.SetInteger("Hits", hits);
                animator.Play("attackone");
               
                attack();

            }
            else if (gapcloserdone && player.transform.position.x >= transform.position.x - 9f && player.transform.position.x <= transform.position.x + 9f)
            {
                move();
            }
            else if (player.transform.position.x >= transform.position.x + 10f || player.transform.position.x <= transform.position.x - 10f)
            {
                gapcloserdone = false;
                if (player.transform.position.x >= transform.position.x + 10f)
                {
                    rb.velocity = new Vector2(2 * 10, rb.velocity.y);
                    
                }
                else if(player.transform.position.x <= transform.position.x - 10f)
                {
                    rb.velocity = new Vector2(2 * - 10, rb.velocity.y);
                    
                }
            }
            else
            {
                
               timer = 0;
               sword.SetActive(false);
                animator2.SetBool("attackone", false);
                animator2.SetBool("spintowinglory", false);
                
                
            }
            majorattackcooldown = majorattackcooldown - Time.deltaTime;
        }
    }
    private void move()
    {
        
        if(player.transform.position.x >= transform.position.x + 1f)
        {
            rb.velocity = new Vector2(2 * 1, rb.velocity.y);
        }
        else if(player.transform.position.x <= transform.position.x - 1f)
        {
            rb.velocity = new Vector2(2 * - 1, rb.velocity.y);
        }
    }
    private void turnaround()
    {
        
        if(player.transform.position.x <= transform.position.x - .1f)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else if(player.transform.position.x >= transform.position.x + .1f)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
    private void Majorattack()
    {
        animator2.SetBool("attackone", false);
        animator2.SetBool("spintowinglory", false);
        Instantiate(darkorbs, shootpoint.transform.position, shootpoint.rotation);
        majorattackcooldown = 15;
    }
    private void attack()
    {
        
        sword.SetActive(true);
        if (timer <= 0.5)
        {
            
            animator2.SetBool("attackone", true);
            animator2.SetBool("spintowinglory", false);
            timer = timer + Time.deltaTime;

        }
        if (timer <= 1.5)
        {
            animator.Play("Attackone");
            
            timer = timer + Time.deltaTime;
            hits = 1;
        }
        else if (timer <= 2.5)
        {
            animator.Play("Attackone");
            
            timer = timer + Time.deltaTime;
            hits = 2;
        }
        else if (timer <= 3.5)
        {
            animator.Play("Spintowin");
            animator2.SetBool("spintowinglory", true);
            timer = timer + Time.deltaTime;
            hits = 3;
            if(timer >= (float)3.5)
            {
                animator2.SetBool("spintowinglory", false);
                timer = 0;
                hits = 0;
            }

        }
        
        

    }
    public static bool iskilled()
    {
        return killed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            PlayerHealthandMana.sethealth(gameObject.GetComponent<Enemies>().damage);
            hits = hits + 1;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            bossstart = true;
            player = collision.gameObject; 
        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            player = collision.gameObject;
        }
    }

}
