using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostKing : MonoBehaviour
{
    public float attackonetimer;
    public float attacktwotimer;
    public float summonattacktimer;
    private GhostKingmovement gk;
    public GameObject ghost;
    public Transform spawnpoint;
    private Enemies em;
    public bool relect;
    public bool ranged;
    private Animator animator;
    
    void Start()
    {
        attackonetimer = 4;
        attacktwotimer = 6;
        summonattacktimer = 7;
        gk = GetComponent<GhostKingmovement>();
        em = GetComponent<Enemies>();
        animator = GetComponent<Animator>();
        
    }

    
    void Update()
    {
        if (ranged)
        {
            StartCoroutine(endoffight());
            if (summonattacktimer <= 0)
            {
                animator.SetBool("moreghost", true);
                summonattack();
            }
            else if (attacktwotimer <= 0)
            {
                attacktwo();
            }
            else if (attackonetimer <= 0)
            {
                StartCoroutine(attackone());
                gameObject.GetComponent<CircleCollider2D>().enabled = false;
            }
            else
            {
                attackonetimer = attackonetimer - Time.deltaTime;
                attacktwotimer = attacktwotimer - Time.deltaTime;
                summonattacktimer = summonattacktimer - Time.deltaTime;
            }
        }
    }
    IEnumerator endoffight()
    {
        yield return new WaitForSeconds(100);
        Destroy(this.gameObject);
        GameManager.boss3dead = true;
        StopCoroutine(endoffight());
    }
    IEnumerator attackone()
    {
        animator.SetBool("attacking", true);
        yield return new WaitForSeconds(1);      
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
        animator.SetBool("attacking", false);
        StopCoroutine(attackone());
        relect = false;
        attackonetimer = 4;
    }
    public void summonattack()
    {
        Instantiate(ghost,spawnpoint.position,spawnpoint.rotation);
        animator.SetBool("moreghost", false);
        summonattacktimer = 7;
    }
    public void attacktwo()
    {
        attacktwotimer = 6;
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (relect == false)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
                this.gameObject.tag = "Enemy";
                ranged = true;

            }
        }
    }
}
