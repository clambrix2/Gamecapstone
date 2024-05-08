using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    // Start is called before the first frame update
    public float Health;
    public float damage;
    public float speed;
    public bool bossone;
    public bool bosstwo;
    public bool bossthree;
    public static bool firstbosskilled;
    public static bool thirdbosskilled;
    public static bool secondbosskilled;
    public GameObject scroll1;
    public GameObject scroll2;
    public GameObject scroll3;

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
            if(bossone)
            {
                Instantiate(scroll1, gameObject.transform.position, gameObject.transform.rotation);
                firstbosskilled = true;
                GameManager.boss1dead = true;
            }
            else if(bosstwo)
            {
                Instantiate(scroll2, gameObject.transform.position, gameObject.transform.rotation);
                secondbosskilled = true;
                GameManager.boss2dead = true;
            }
            else if(bossthree)
            {
                Instantiate(scroll3, gameObject.transform.position, gameObject.transform.rotation);
                thirdbosskilled = true;
                GameManager.boss3dead = true;
            }
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
            Debug.Log("whyareyouattacksomuch");
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.gameObject.CompareTag("Enemy"))
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                attack();
            }
        }
    }

}
