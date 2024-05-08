using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tempdagger : MonoBehaviour
{
   
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            GameObject temp = collision.gameObject;
            Enemies em = temp.GetComponent<Enemies>();
            PlayerHealthandMana.setMana(-1);
            em.hits(1);
        }
    }
}
