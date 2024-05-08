using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public bool lava;
    public bool ghostpit;
    public int i;

    public void Start()
    {
        i = 50;
    }
    IEnumerator touchlava()
    {
        yield return new WaitForSeconds(0);
        PlayerHealthandMana.sethealth(10);
        StopCoroutine(touchlava());
        
    }
    public void lavawaitingroom()
    {
        
        if(i < 0)
        {
            StartCoroutine(touchlava());
            i = 50;
        }
        else
        {
            i = i - 1;
            Debug.Log(i);
        }
    }
    public void touchghostpit()
    {
        PlayerHealthandMana.sethealth(50);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if (lava)
            {
                touchlava();
            }
            else if(ghostpit)
            {
                touchghostpit();
            }
        }
        
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (lava)
            {
                lavawaitingroom();
            }
            else if (ghostpit)
            {
                touchghostpit();
            }
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(lava)
            {
                StopCoroutine(touchlava());
            }
        }
    }
}
