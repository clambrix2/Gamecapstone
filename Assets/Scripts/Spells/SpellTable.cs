using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpellTable : MonoBehaviour
{
    
    
    public Transform spawner;
    public float x;
    public float y;
  
    public static void inuse()
    {
        
        
        SceneManager.LoadScene("Game");
       
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            spawner.position = collision.transform.position;
            Spawner.x = x;
            Spawner.y = y;
            Spawner.spawnerdestory = true;
        }
    }




}
