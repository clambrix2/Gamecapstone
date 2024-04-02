using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject cam;
    public static float x;
    public static float y;
    public Transform spawnpoint;
    public bool isPlayer;
    public static bool Playerispawn;
    public bool dontdeload;
    public static bool spawnerdestory;
    void Start()
    {
        Playerispawn = false;
        if(spawnerdestory && isPlayer)
        {
            Destroy(this.gameObject);
        }
            if (isPlayer && Playerispawn == false)
            {
            
            Playerspawn();
            }
            else if (isPlayer == false)
            {
                Spawnenemy();
            }
            else
            {
                Debug.Log("is should be the player");
            }
            if(dontdeload)
               {
            dontdeload = false;
            //DontDestroyOnLoad(this.gameObject);
               }
        
        
        
        
    }

   
    private void Spawnenemy()
    {
        Instantiate(Enemy, spawnpoint.position, spawnpoint.rotation);
    }
    private void Playerspawn()
    {
        campostion();
        Playerispawn = true;
        Instantiate(Enemy, spawnpoint.position, spawnpoint.rotation);
    }
    private void campostion()
    {
        cam.transform.position = new Vector3(x, y, -10);
        Enemy.transform.position = new Vector3(x, y, 0);
    }
    
}
