using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    private int rituallength;
    public KeyCode[] input;
    public GameObject gm;
    private SpellBook sb;
    public Transform shootpoint;
    private Rigidbody2D rb;
    public float speed;
    private float moveinput;
    public float jumpforce;
    private bool isgrounded;
    int i;
    private float isleftorright;
    void Start()
    {
        rituallength = 3;
        sb = gm.GetComponent<SpellBook>();
        rb= GetComponent<Rigidbody2D>();
        i = 0;
        isgrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (input[2] == KeyCode.None)
        {
            Spellcast();
        }
        else if(Input.GetKeyDown(KeyCode.Return)) 
        {
            firespell();
        }
        moveinput = Input.GetAxisRaw("Horizontal");
        isleftorright = moveinput;
        Debug.Log(isleftorright); Debug.Log("MoveInput ");
        move();
        if(Input.GetKeyDown(KeyCode.Space) && isgrounded)
        {
            Jump();
        }
        
        
    }
    void Spellcast()
    {
        
            if(Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.JoystickButton2))
            {
                input[i] = KeyCode.J;
            i++;
            }
            else if(Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.JoystickButton3))
            {
                input[i] = KeyCode.K;
            i++;
            }
            else if(Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.JoystickButton1))
            {
                input[i] = KeyCode.L;
            i++;
            }
        
        if(i >= 3)
        {
            i = 0;
        }
            
    }
  
    void firespell()
    {
        int s;
        s = 0;
        
            s = sb.spellcastcheck(input);
        for (int x = 0; x < rituallength; x++)
        {
            input[x] = KeyCode.None;
        }
        
        Instantiate(sb.Spells[s], shootpoint.transform.position, shootpoint.transform.rotation);
        
    }
    void move()
    {
        
        rb.velocity = new Vector2(moveinput * speed, rb.velocity.y);
    }
    void Jump()
    {
        isgrounded = false;
       
        rb.velocity = new Vector2(rb.velocity.x, jumpforce);

    }
    public float getleftorright()
    {
        return isleftorright;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isgrounded = true;
    }

}
