using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject Menu;
    public GameObject Healthandmana;
    public void Start()
    {
        Time.timeScale = 1.0f;
    }
    public void Update()
    {
        menu();
    }


    public void menu()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Menu.SetActive(true);
            Healthandmana.SetActive(false);
            Time.timeScale = 0f;
        }
    }
}
