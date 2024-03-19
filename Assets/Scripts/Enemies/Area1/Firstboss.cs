using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firstboss : MonoBehaviour
{
    private bool bossstart;
    public GameObject player;
    public GameObject sword;
    public Animation swordanim;
    public static bool killed;
    void Start()
    {
        bossstart = false;
        swordanim = sword.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if(bossstart)
        {
            turnaround();
            if (player.transform.position.x >= transform.position.x - 3f && player.transform.position.x <= transform.position.x + 3f)
            {

            }
        }
    }
    private void turnaround()
    {
        
        if(player.transform.position.x <= transform.position.x - .1f)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else if(player.transform.position.x >= transform.position.x + .1f)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
    private void attack()
    {
        sword.SetActive(true);
    }
    public static bool iskilled()
    {
        return killed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            bossstart = true;
            player = collision.gameObject; 
        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            player = collision.gameObject;
        }
    }

}
