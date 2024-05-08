using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Mage : MonoBehaviour
{
    private bool inranged;
    private float count;
    private float spellcooldown;
    public GameObject Spell1;
    public GameObject Spell2;
    private Spell sp;
    private Enemies em;
    public Transform shootpoint;
    private Animator animator;
    void Start()
    {
        inranged = false;
        count = .02f;
        spellcooldown = 2;
        em = GetComponent<Enemies>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(inranged && spellcooldown <= 0)
        {
            animator.SetBool("attack", true);
            spellone();
            if(count <= 0)
            {
                Debug.Log("SPelltwo");
                spelltwo();
            }
            else
            {
                count -= Time.deltaTime;
            }
            Debug.Log(count);
        }
        else
        {
            spellcooldown -= Time.deltaTime;
        }
    }
    private void spellone()
    {
        Instantiate(Spell1, shootpoint.transform.position, shootpoint.transform.rotation);
        spellcooldown = 2;
    }
    private void spelltwo()
    {
        Instantiate(Spell2, shootpoint.transform.position, shootpoint.transform.rotation);
        count = .02f;
    }
    private void onhit(float d)
    {
        em.Health -= d;
        ondeath();
    }
    private void ondeath()
    {
        if(em.Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            inranged = true;

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Spell"))
        {
            sp = collision.gameObject.GetComponent<Spell>();
            onhit(sp.Damage);
        }
    }
}
