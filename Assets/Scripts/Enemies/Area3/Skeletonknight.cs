using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeletonknight : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject player;
    public GameObject sword;
    public GameObject sword2;
    public GameObject Shield;
    private Enemies em;
    private Spell sp;
    private float gethitdamage;
    private float attackdur;
    private float count;
    private float shieldcount;
    private bool inranged;
    private Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        em = GetComponent<Enemies>();
        animator = GetComponent<Animator>();
        attackdur = 1;
        count = 1;
    }

   
    void Update()
    {

        if (inranged)
        {
            move();
           shieldup();
            if (player.transform.position.x > transform.position.x - 5f && player.transform.position.x < transform.position.x + 5f)
            {
                animator.SetBool("attackone", true);
                attack();
            }
            else
            {
                animator.SetBool("attackone", false);
                animator.SetBool("attacktwo", false);
                sword.SetActive(false);
                sword2.SetActive(false);
            }
        }
        
    }
    private void shieldup()
    {
        if(shieldcount <= 0 && shieldcount >= -.5f)
        {
            this.gameObject.tag = "Wall";
            shieldcount -= Time.deltaTime;
        }
        else if(shieldcount == 2)
        {
            this.gameObject.tag = "Enemy";
            shieldcount -= Time.deltaTime;
        }
        else if(shieldcount <= -2)
        {
            shieldcount = 2;
        }
        else
        {
            shieldcount -= Time.deltaTime;
        }
    }
    private void move()
    {
        rb.MovePosition(Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x, player.transform.position.y), em.speed * Time.deltaTime));
    }
    private void attack()
    {

        if (attackdur <= 0 && attackdur >= -.5)
        {
            sword.SetActive(true);
            attackdur -= Time.deltaTime;
        }
        else if (attackdur == 3)
        {
            sword.SetActive(false);
            sword2.SetActive(false);
            attackdur -= Time.deltaTime;
        }
        else if (attackdur <= -1)
        {
            attackdur = 3;
        }
        else
        {
            attackdur = attackdur - Time.deltaTime;
           
            

        }
    }
    private void gethit(float d)
    {
        em.Health -= d;
        death();
    }
    private void death()
    { 
        if(em.Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealthandMana.sethealth(em.damage);
            sword.SetActive(false);
            animator.SetBool("attacktwo", true);
            sword2.SetActive(true);
        }
        if(collision.gameObject.CompareTag("Spell") && this.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Spell block");
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.CompareTag("Spell"))
        {
            sp = collision.gameObject.GetComponent<Spell>();
            gethitdamage = sp.Damage;
            gethit(gethitdamage);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inranged = true;
            player = collision.gameObject;
        }
    }
}
