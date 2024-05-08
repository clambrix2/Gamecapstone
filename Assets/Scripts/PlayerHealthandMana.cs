using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealthandMana : MonoBehaviour
{
   public static float health;
  public static float Mana;
    public GameObject Healthui;
    public GameObject Manaui;
    public RawImage sp;
    public Texture Health1;
    public Texture Health2;
    public Texture Health3;
    public Texture Health4;
    public Texture Health5;
    public Texture Mana1;
    public Texture Mana2;
    public Texture Mana3;
    public Texture Mana4;
    public Texture Mana5;
    public Texture emptyorb;
    
    void Start()
    {
        Mana = 50;
        health = 50;
        

    }

    // Update is called once per frame
    void Update()
    {
        updatehealthandmanaui();
        if(Mana < 0)
        {
            Mana = 0;
        }
    }
    public static void sethealth(float d)
    {
        
        health = health - d;
       
        
    }
    public void updatehealthandmanaui()
    {
        
        if (health < 50 && health >= 40)
        {
           
            sp = Healthui.GetComponent<RawImage>();
            sp.texture = Health1;
        }
        else if (health < 40 && health >= 30)
        {
            
            sp = Healthui.GetComponent<RawImage>();
            sp.texture = Health2;
            
        }
        else if (health < 30 && health >= 20)
        {
            
            sp = Healthui.GetComponent<RawImage>();
            sp.texture = Health3;
        }
        else if (health < 20 && health >= 10)
        {
            
            sp = Healthui.GetComponent<RawImage>();
            sp.texture = Health4;
        }
        else if (health < 10 && health > 0)
        {
            
            sp = Healthui.GetComponent<RawImage>();
            sp.texture = Health5;
        }
        else if (health <= 0)
        {
            
            sp = Healthui.GetComponent<RawImage>();
            sp.texture = emptyorb;
            ondeath();
        }
        //Mana
        if (Mana < 50 && Mana >= 40)
        {
            
            sp = Manaui.GetComponent<RawImage>();
            sp.texture = Mana1;
        }
        else if (Mana < 40 && Mana >= 30)
        {
            
            sp = Manaui.GetComponent<RawImage>();
            sp.texture = Mana2;

        }
        else if (Mana < 30 && Mana >= 20)
        {
            
            sp = Manaui.GetComponent<RawImage>();
            sp.texture = Mana3;
        }
        else if (Mana < 20 && Mana >= 10)
        {
            
            sp = Manaui.GetComponent<RawImage>();
            sp.texture = Mana4;
        }
        else if (Mana < 10 && Mana > 0)
        {
            
            sp = Manaui.GetComponent<RawImage>();
            sp.texture = Mana5;
        }
        else if (Mana <= 0)
        {
            
            sp = Manaui.GetComponent<RawImage>();
            sp.texture = emptyorb;
            ondeath();
        }

    }
    public static void ondeath()
    {
        if(health <=0)
        {

            Playercontroller.destoryplayer();
            SceneManager.LoadScene("Game");
        }
    }
    public static void setMana(float m)
    {
        Mana = Mana - m;
        if(Mana > 50)
        {
            Mana = 50;
        }
        Debug.Log(Mana);
    }
    public static float getmana()
    {
        return Mana;
    }
}
