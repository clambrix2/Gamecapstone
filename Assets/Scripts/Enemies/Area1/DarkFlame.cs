using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class DarkFlame : MonoBehaviour
{
    public GameObject Player;
    public BoxCollider2D Collider;
    private Enemies em;
    public Transform location;
    private Rigidbody2D rb;
    public bool targetlived;
    public float life;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
         em = GetComponent<Enemies>();
        life = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if(targetlived)
        {
            if (life <= 0)
            {
                explode();
            }
            life = life - Time.deltaTime;
            target();
        }
    }
    private void target()
    {
        rb.MovePosition(Vector2.MoveTowards(gameObject.transform.position, location.transform.position, (float).08));
        
    }
    private void explode()
    {
        
      Destroy(this.gameObject);
         
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerHealthandMana.sethealth(em.damage);
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            location = collision.transform;
            targetlived = true;
            
            
        }
    }
}
