using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyspell : MonoBehaviour
{
    public bool relfect;
    private static Rigidbody2D rb;
    public static float speed;
    public float speedtemp;

    public void Start()
    {
        speed = speedtemp;
        rb = GetComponent<Rigidbody2D>();
    }
    public static void move(int i)
    {
        rb.velocity = new Vector2(speed * i, rb.velocity.y);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(relfect)
        {
            if(collision.gameObject.CompareTag("Enemy"))
            {
                collision.gameObject.GetComponent<Enemies>().hits(1);
                Destroy(this.gameObject);
            }
        }
        

    }


}
