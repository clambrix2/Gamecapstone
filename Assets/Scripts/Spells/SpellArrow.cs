using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellArrow : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool isleft;
    public GameObject controller;
    private SpellController sc;
    public float speed;
    private float timer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sc = controller.GetComponent<SpellController>();
        timer = (float).2;
      
    }

    // Update is called once per frame
    void Update()
    {
       isleft = SpellController.getleftorright();
        
        if (timer > 0)
        {
            move();
        }
    }
    private void move()
    {
        if(isleft)
        {
           
            rb.velocity = new Vector2(speed * -1, rb.velocity.y);
        }
        else
        {
            
            rb.velocity = new Vector2(speed * 1, rb.velocity.y);
        }
        timer -= Time.deltaTime;
    }
 
  
}
