using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthandMana : MonoBehaviour
{
   static float health;
  public static float Mana;
    public GameObject Healthui;
    public GameObject Manaui;
    public static TMP_Text Healthorb;
    public static TMP_Text Manaorb;
    void Start()
    {
        Mana = 50;
        health = 50;
        Healthorb = Healthui.GetComponent<TMP_Text>();
        Manaorb = Manaui.GetComponent<TMP_Text>();
        Healthorb.text = "Health " + health;
        Manaorb.text = "Mana " + Mana;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void sethealth(float d)
    {
        health = health - d;
        Healthorb.text = "Health " + health;
        if(health <= 0)
        {
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
        Manaorb.text = "Mana " + Mana;
        Debug.Log(Mana);
    }
    public static float getmana()
    {
        return Mana;
    }
}
