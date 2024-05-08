using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject Menu;
    public GameObject Spellinfo;
    public GameObject Healthandmana;
    public GameObject runeone;
    public GameObject player;
    public GameObject boss1;
    public GameObject boss2;
    public GameObject boss3;
    public static GameObject runeonetemp;
    public GameObject runetwo;
    public static GameObject runetwotemp;
    public GameObject runethree;
    public static GameObject runethreetemp;
    public RawImage temp;
    public Texture runej;
    public Texture runek;
    public Texture runel;
    public Texture runeblank;
    public static bool boss1dead;
    public static bool boss2dead;
    public static bool boss3dead;
    public GameObject youwin;
    public bool closethescreen;

    public void Start()
    {
        Time.timeScale = 1.0f;
        runeonetemp = runeone;
        runetwotemp = runetwo;
        runethreetemp = runethree;
        if(boss1dead)
        {
            Destroy(boss1);

        }
        if(boss2dead)
        {
            Destroy(boss2);

        }
        if(boss3dead)
        {
            Destroy(boss3);
        }
    }
    public void Update()
    {
        menu();
    }
    public void close()
    {
        youwin.SetActive(false);
        closethescreen = true;
    }
    public void youwinscreen()
    {
        if(boss1dead && boss2dead && boss3dead && closethescreen == false)
        {
            youwin.SetActive(true);
            
        }
    }
    public void rune(KeyCode s, int i)
    {
        if (s == KeyCode.J)
        {
            if(i == 0)
            {
                temp = runeonetemp.GetComponent<RawImage>();
                temp.texture = runej;
            }
            else if(i == 1)
            {
                temp = runetwotemp.GetComponent<RawImage>();
                temp.texture = runej;
            }
            else if(i == 2)
            {
                
                temp = runethreetemp.GetComponent<RawImage>();
                temp.texture = runej;
            }
            
        }
        else if (s == KeyCode.K)
        {
            if (i == 0)
            {
                temp = runeonetemp.GetComponent<RawImage>();
                temp.texture = runek;
            }
            else if (i == 1)
            {
                temp = runetwotemp.GetComponent<RawImage>();
                temp.texture = runek;
            }
            else if (i == 2)
            {
               
                temp = runethreetemp.GetComponent<RawImage>();
                temp.texture = runek;
            }
            
        }
        else if (s == KeyCode.L)
        {
            if (i == 0)
            {
                temp = runeonetemp.GetComponent<RawImage>();
                temp.texture = runel;
            }
            else if (i == 1)
            {
                temp = runetwotemp.GetComponent<RawImage>();
                temp.texture = runel;
            }
            else if (i == 2)
            {
                
                temp = runethreetemp.GetComponent<RawImage>();
                temp.texture = runel;
            }
            
        }

    }
    public void runereset()
    {
        runeonetemp.GetComponent<RawImage>().texture = runeblank;
        runetwotemp.GetComponent<RawImage>().texture = runeblank;
        runethreetemp.GetComponent<RawImage>().texture = runeblank;
    }
    public void menu()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Menu.activeInHierarchy == true || Input.GetKeyDown(KeyCode.Tab) && Spellinfo.activeInHierarchy == true) 
        {
            Menu.SetActive(false);
            Spellinfo.SetActive(false);
            player.GetComponent<Playercontroller>().enabled = true;
            Healthandmana.SetActive(true);
            Time.timeScale = 1f;
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Menu.SetActive(true);
            Spellinfo.SetActive(false);
            player.GetComponent<Playercontroller>().enabled = false;
            Healthandmana.SetActive(false);
            Time.timeScale = 0f;
        }
        else if(Input.GetKeyDown(KeyCode.Tab))
        {
            Spellinfo.SetActive(true);
            Menu.SetActive(false);
            player.GetComponent<Playercontroller>().enabled = false;
            Healthandmana.SetActive(false);
            Time.timeScale = 0f;
        }
        
    }
}
