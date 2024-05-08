using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject menu;
    public GameObject info;
    public GameObject player;
    private Playercontroller pc;
    private void Start()
    {
        pc = GetComponent<Playercontroller>();
    }
    public void startgame()
    {
        SceneManager.LoadScene("Game");
        if(menu.activeInHierarchy == true || info.activeInHierarchy == true)
        {
            if(Input.GetButtonDown("menu"))
            {
                if(menu.activeInHierarchy == true)
                {
                    menu.SetActive(false);
                    info.SetActive(true);
                }
                else if(info.activeInHierarchy == true)
                {
                    menu.SetActive(true);
                    info.SetActive(false);
                }
            }
            if(menu.activeInHierarchy== true)
            {
                if(Input.GetAxis("exit") > 0)
                {
                    Application.Quit();
                }
            }
        }
        else if(menu.activeInHierarchy == false && info.activeInHierarchy == false)
        {
            if (Input.GetButtonDown("menu"))
            {
                menu.SetActive(true);
            }
        }
        if(Input.GetButtonDown("back"))
        {
            menu.SetActive(false);
            info.SetActive(false);
        }
        
    }
    public void quit()
    {
        Application.Quit();
    }
    public void Spellinfomantion()
    {
        menu.SetActive(false);
        info.SetActive(true);
        
    }
    public void backtomenu()
    {
        menu.SetActive(true);
        info.SetActive(false);
    }
}
