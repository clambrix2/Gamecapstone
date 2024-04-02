using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    // Start is called before the first frame update
    public float Health;
    public float damage;
    public float speed;

    public void hits(float h)
    {
        Health = Health - h;
        death();
    }
    public void refund(float r)
    {
        PlayerHealthandMana.setMana(r);
    }
    public void attack()
    {
        PlayerHealthandMana.sethealth(damage);
    }
    public void death()
    {
        if(Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Spell"))
        {
            hits(collision.gameObject.GetComponent<Spell>().Damage);
            refund(collision.gameObject.GetComponent<Spell>().Manarefund);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            attack();
        }
    }

}
