using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Loadzones : MonoBehaviour
{
    public GameObject cam;
    public GameObject Player;
    private GameObject temp;
    public float moveingcamx;
    public float moveingcamy;
    public float playermovex;
    public float playermovey;
    public bool playeryeleport;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void movecam()
    {
        cam.transform.position = new Vector3(moveingcamx, moveingcamy, -10);
    }
    private void teleport()
    {
        Player.transform.position = new Vector3(playermovex, playermovey, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.CompareTag("Loadzone") || collision.gameObject.CompareTag("Player"))
        {
                
                movecam();
            if(playeryeleport)
            {
                if (collision.gameObject.CompareTag("Player"))
                {
                    Player = collision.gameObject;
                    teleport();
                }
            }
                
                
        }
       
    }
  
}

