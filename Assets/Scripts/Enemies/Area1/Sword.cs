using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public GameObject boss;
    private Firstboss fb;
    public float hitcooldown;
    void Start()
    {
        fb = boss.GetComponent<Firstboss>();
        
    }
    private void Update()
    {
        if (hitcooldown > 0)
        {
            hitcooldown = hitcooldown - Time.deltaTime;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && hitcooldown <= 0)
        {
            
            fb.hits = fb.hits + 1;
            hitcooldown = (float).5;
        }
        
       
    }
}
