using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellArrow : MonoBehaviour
{
    private Rigidbody2D rb;
    private float input;
    public GameObject player;
    private Playercontroller pc;
    public float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pc = player.GetComponent<Playercontroller>();
        input = 1;
    }

    // Update is called once per frame
    void Update()
    {

        input = pc.getleftorright();
        Debug.Log(input);
        rb.velocity = new Vector2(speed * input, rb.velocity.y);
    }
  
}
