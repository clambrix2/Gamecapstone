using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikething : MonoBehaviour
{
    private Enemies em;
    void Start()
    {
        em = GetComponent<Enemies>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerHealthandMana.sethealth(em.damage);
            
        }
    }
}
