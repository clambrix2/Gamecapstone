using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthandMana : MonoBehaviour
{
   static float health;
   static float Mana;
    void Start()
    {
        Mana = 30;
        health = 10;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void sethealth(float d)
    {
        health = health - d;
        Debug.Log(health);
        if(health <= 0)
        {
            ondeath();
        }
        
    }
    public static void ondeath()
    {
        if(health <=0)
        {
            Debug.Log("does nothing for now");
        }
    }
    public static void setMana(float m)
    {
        Mana = Mana - m;
        Debug.Log(Mana);
    }
    public static float getmana()
    {
        return Mana;
    }
}
