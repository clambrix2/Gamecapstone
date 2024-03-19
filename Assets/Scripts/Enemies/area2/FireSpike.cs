using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FireSpike : MonoBehaviour
{
    private float firedubuff;
    private float count;
    private Spell sp;
    private Enemies em;

    void Start()
    {
        em = GetComponent<Enemies>();
        count = 2;

    }
    void Update()
    {
        if(firedubuff > 0)
        {
            fireduff();
        }
            
        
    }
    private void fireduff()
    {
        if(count <= 0)
        {
            firedubuff -= 1;
            PlayerHealthandMana.sethealth(1);
            count = 2;
        }
        else
        {
            count -= Time.deltaTime;
        }
    }
    private void damage(float d)
    {
        em.Health -= d;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerHealthandMana.sethealth(em.damage);
            firedubuff = 3;

        }
        if(collision.gameObject.CompareTag("Spell"))
        {
            sp = collision.gameObject.GetComponent<Spell>();
            damage(sp.Damage);
            if(em.Health <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
