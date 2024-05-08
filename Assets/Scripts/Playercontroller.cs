using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Playercontroller : MonoBehaviour
{
    private int rituallength;
    public KeyCode[] input;
    public GameObject gm;
    public GameObject dagger;
    public Animator animator;
    private static GameObject player;
    public GameObject daggercolliosin;
    private SpellBook sb;
    public Transform shootpoint;
    private Rigidbody2D rb;
    private SpellController sc;
    private CapsuleCollider2D col;
    private GameManager gamem;
    public float speed;
    private float moveinput;
    public float jumpforce;
    private bool isgrounded;
    private int leftorright;
    int i;
    private bool isleft;
    public float iframe;
    public float rframes;
    public bool ischoas;
    public float jump;
    public static bool hasrelect;
    public static bool hasdash;
    public float spellcastingend;
    public static bool haste;
    private float timescale;
    private float timescaletimer;
    void Start()
    {
        rituallength = 3;
        sb = gm.GetComponent<SpellBook>();
        rb= GetComponent<Rigidbody2D>();
        sc = gm.gameObject.GetComponent<SpellController>();
        col = GetComponent<CapsuleCollider2D>();
        gamem = gm.GetComponent<GameManager>();
        i = 0;
        isgrounded = true;
        iframe = 0;
        DontDestroyOnLoad(this.gameObject);
        player = this.gameObject;
        jump = 0;
        rframes = 0;
        spellcastingend = 1;
        leftorright = 0;
        hasdash = true;
        timescale = 1;
        timescaletimer = 10;
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
            else if (Input.GetKeyDown(KeyCode.Return) || Input.GetAxis("FireSpell") > 0)
            {
                firespell();
            }
            moveinput = Input.GetAxisRaw("Horizontal");
            rotate();
            move();
            if (rframes > 0)
            {
                rframes = rframes -= Time.deltaTime;
            }
            else if (rframes <= 0)
            {
                gameObject.tag = "Player";
                animator.SetBool("reflect", false);
            }
            if (Input.GetKeyDown(KeyCode.Space) && jump  < 2 || Input.GetButtonDown("Jump") && jump < 2)
            {
                Jump();
            }
            if(Input.GetKeyDown(KeyCode.O) && scrolls.collect1 && rframes <= 0 && PlayerHealthandMana.Mana > 0 || Input.GetButtonDown("reflect") && scrolls.collect1 && rframes <= 0 && PlayerHealthandMana.Mana > 0)
            {
                reflect();
            }
            if (Input.GetKeyDown(KeyCode.H)|| Input.GetButtonDown("Daggerattack"))
            {
                StartCoroutine(manastealdagger());
            }
                choasshift();
            endspellcasting();

        }
        else
        {
            if(iframe <= 0)
            {
                ischoas = false;
            }
        }
        manastealdagger();
        hashaste();
        iframes();
        
        
        
    }
    public void endspellcasting()
    {
        if (spellcastingend <= 0)
        {


            animator.SetBool("spellcasting", false);
            spellcastingend = 1;
        }
        else
        {
            spellcastingend = spellcastingend - Time.deltaTime;
        }
    }
   
    public void usetable()
    {
        if(Input.GetKeyDown(KeyCode.F) || Input.GetButtonDown("Fire2"))
        {
            
            SpellTable.inuse();

        }
    }
    public void useitem(GameObject temp)
    {
        
        if(Input.GetKeyDown(KeyCode.F))
        {
            temp.gameObject.GetComponent<scrolls>().collect();
        }
    }
    public void iframes()
    {
        if(iframe <= 0 && rframes <= 0)
        {
            gameObject.tag = "Player";
            animator.SetBool("chaos", false);
            animator.SetBool("wings", false);
        }
        else if(iframe != 0)
        {
            
            
            iframe = iframe - Time.deltaTime;
        }
       
    }
    public void hashaste()
    {
        
            if (haste)
            {
                timescale = .5f;
                timescaletimer = timescaletimer - Time.deltaTime;
            }
            if (timescaletimer < 10)
            {
                timescaletimer = timescaletimer - Time.deltaTime;
            }
            if (timescaletimer <= 0)
            {
                timescaletimer = 10;
                haste = false;
                timescale = 1;
            }
        
        
    }
    void rotate()
    {
        if (moveinput > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            leftorright = 0;
            sc.leftorright(moveinput);
        }
        else if (moveinput < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            leftorright = 1;
            sc.leftorright(moveinput);
        }

    }
    void Spellcast()
    {
        
            if(Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.JoystickButton2))
            {
                input[i] = KeyCode.J;
           
                gamem.rune(KeyCode.J, i);
            i++;
            }
            else if(Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.JoystickButton3))
            {
                input[i] = KeyCode.K;
           
                gamem.rune(KeyCode.K, i);

            i++;
            }
            else if(Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.JoystickButton1))
            {
                input[i] = KeyCode.L;
           
                gamem.rune(KeyCode.L, i);
            i++;
            }
                
        
        if(i >= 3)
        {
            i = 0;
        }
            
    }
    public void reflect()
    {
       this.gameObject.tag = "Reflect";
        animator.SetBool("reflect", true);
        rframes = .5f;
        PlayerHealthandMana.setMana(10);
    }
  
    void firespell()
    {
        int s;
        s = 0;
        
            s = sb.spellcastcheck(input);
        gamem.runereset();
        for (int x = 0; x < rituallength; x++)
        {
            input[x] = KeyCode.None;
        }
            
        if (sb.manacheck(s))
        {
            animator.SetBool("spellcasting", true);
            Instantiate(sb.Spells[s], shootpoint.transform.position, shootpoint.transform.rotation);
            
        }
        
    }
    void move()
    {
        if (moveinput != 0)
        {
            if(animator.GetBool("walk") == false)
            {
                animator.SetBool("walk", true);
            }
           
            rb.velocity = new Vector2((moveinput * speed)/timescale, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetBool("walk", false);
        }
    }
    void Jump()
    {
        isgrounded = false;
        animator.SetBool("jump", true);
        jump++;
       
        rb.velocity = new Vector2(rb.velocity.x, jumpforce);

    }
    public void choasshift()
    {
        if (!scrolls.collect2)
        {
            if (Input.GetKeyDown(KeyCode.I) && PlayerHealthandMana.Mana > 0 || Input.GetAxis("Chaosshift") > 0 && PlayerHealthandMana.Mana > 0)
            {
                animator.SetBool("chaos", true);
                PlayerHealthandMana.setMana(10);
                iframe = 1;
                gameObject.tag = "Chaos";
                ischoas = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.I) && PlayerHealthandMana.Mana > 0 || Input.GetAxis("Chaosshift") > 0 && PlayerHealthandMana.Mana > 0)
            {
                PlayerHealthandMana.setMana(10);
                gameObject.tag = "Chaos";
                animator.SetBool("wings", true);
                iframe = 1;
                if(leftorright == 0)
                {
                    rb.velocity = new Vector2((speed * 2) * 1, rb.velocity.y);
                }
                else if(leftorright == 1)
                {
                    rb.velocity = new Vector2((speed * 2) * -1, rb.velocity.y);
                }
               
                ischoas = true;
            }
        }
    }
    IEnumerator manastealdagger()
    {
        
        
            daggercolliosin.SetActive(true);
            daggercolliosin.GetComponent<Animation>().Play("attackagain");
        animator.SetBool("attacking", true);
            yield return new WaitForSeconds(.5f);
        daggercolliosin.GetComponent<Animation>().Stop();
        animator.SetBool("attacking", false);
        daggercolliosin.SetActive(false);
        StopCoroutine(manastealdagger());
            
        
        
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
            animator.SetBool("jump", false);
            
        }
        if(collision.gameObject.CompareTag("Enemy"))
        {
            iframe = 1;
        }
        if (collision.gameObject.CompareTag("Enemyspell"))
        {
            Debug.Log("is it working");
            if (gameObject.CompareTag("Reflect"))
            {
                Debug.Log("reflect");
                collision.gameObject.GetComponent<Enemyspell>().relfect = true;

            }
        }



    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Table"))
        {
            usetable();
        }
        else if(collision.gameObject.CompareTag("Item"))
        {
            GameObject temp = collision.gameObject;
            useitem(temp);
        }
        if (this.gameObject.CompareTag("Reflect"))
        {

            collision.gameObject.GetComponent<GhostKing>().relect = true;

        }
        


    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Table"))
        {
            usetable();
        }
        else if (collision.gameObject.CompareTag("Item"))
        {
            GameObject temp = collision.gameObject;
            useitem(temp);
        }

    }

}
