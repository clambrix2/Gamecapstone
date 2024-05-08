using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorials : MonoBehaviour
{
    public bool one;
    public bool two;
    public bool three;
    public GameObject tone;
   
   
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(one)
            {
                tone.SetActive(true);
            }
            else if(two)
            {
                tone.SetActive(true);
            }
            else if(three)
            {
                tone.SetActive(true);
            }
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        tone.SetActive(false);
        
    }
}
