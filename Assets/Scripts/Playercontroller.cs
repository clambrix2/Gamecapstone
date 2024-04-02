using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.SceneManagement;

public class Playercontroller : MonoBehaviour
{
    private int rituallength;
    public KeyCode[] input;
    public GameObject gm;
    public GameObject dagger;
    private static GameObject player;
    private SpellBook sb;
    public Transform shootpoint;
    private Rigidbody2D rb;
    private SpellController sc;
    private CapsuleCollider2D col;
    public float speed;
    private float moveinput;
    public float jumpforce;
    private bool isgrounded;
    int i;
    private bool isleft;
    public float iframe;
    public bool ischoas;
    public float jump;
    void Start()
    {
        rituallength = 3;
        sb = gm.GetComponent<SpellBook>();
        rb= GetComponent<Rigidbody2D>();
        sc = gm.gameObject.GetComponent<SpellController>();
        col = GetComponent<CapsuleCollider2D>();
        i = 0;
        isgrounded = true;
        iframe = 0;
        //DontDestroyOnLoad(this.gameObject);
        player = this.gameObject;
        jump = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!ischoas)
        {
            if (input[2] == KeyCode.None)
            {
                Spellcast();
            }
            else if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.JoystickButton11))
            {
                firespell();
            }
            moveinput = Input.GetAxisRaw("Horizontal");
            rotate();
            move();
            if (Input.GetKeyDown(KeyCode.Space) && jump  < 2)
            {
                Jump();
            }
            choasshift();
        }
        else
        {
            if(iframe <= 0)
            {
                ischoas = false;
            }
        }
        manastealdagger();
        iframes();
        
    }
   
    public void usetable()
    {
        if(Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.JoystickButton4))
        {
            
            SpellTable.inuse();

        }
    }
    public void useitem()
    {

    }
    public void iframes()
    {
        if(iframe <= 0)
        {
            col.gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
            rb.excludeLayers = 0;
            rb.includeLayers = 64;
        }
        else if(iframe != 0)
        {
            
            col.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            rb.excludeLayers = 64;
            rb.includeLayers = 0;
            iframe = iframe - Time.deltaTime;
        }
       
    }
    void rotate()
    {
        if (moveinput > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            
            sc.leftorright(moveinput);
        }
        else if (moveinput < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            
            sc.leftorright(moveinput);
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
        if (sb.manacheck(s))
        {
            Instantiate(sb.Spells[s], shootpoint.transform.position, shootpoint.transform.rotation);
            
        }
        
    }
    void move()
    {
        
        rb.velocity = new Vector2(moveinput * speed, rb.velocity.y);
    }
    void Jump()
    {
        isgrounded = false;
        jump++;
       
        rb.velocity = new Vector2(rb.velocity.x, jumpforce);

    }
    public void choasshift()
    {

        if(Input.GetKeyDown(KeyCode.I) && PlayerHealthandMana.Mana > 0||  Input.GetKeyDown(KeyCode.JoystickButton10) && PlayerHealthandMana.Mana > 0)
        {
            
            PlayerHealthandMana.setMana(10);
            iframe = 1;
            ischoas = true;
        }
    }
    public void manastealdagger()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            Instantiate(dagger, shootpoint.position, shootpoint.rotation);
            
        }
    }
    public static void destoryplayer()
    {
        Spawner.Playerispawn = false;
        SceneManager.MoveGameObjectToScene(player, SceneManager.GetActiveScene());
    }
    
    public bool getleftorright()
    {
        return isleft;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            jump = 0;
            
        }
        if(collision.gameObject.CompareTag("Enemy"))
        {
            iframe = 1;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Table"))
        {
            usetable();
        }
      //  else if(collision.gameObject.CompareTag("Item"))
       // {
            //useitem();
       // }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Table"))
        {
            usetable();
        }
        //else if (collision.gameObject.CompareTag("Item"))
       // {
            //useitem();
       // }

    }

}
