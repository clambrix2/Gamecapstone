using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tempdagger : MonoBehaviour
{
    public float timer;
    private void Start()
    {
        timer = 1;
    }
    private void Update()
    {
        timer = timer - Time.deltaTime;
        if(timer <= 0)
        {
            timetodestory();
        }
    }
    private void timetodestory()
    {
        Destroy(this.gameObject);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            GameObject temp = collision.gameObject;
            Enemies em = temp.GetComponent<Enemies>();
            PlayerHealthandMana.setMana(-1);
            em.hits(1);
            Destroy(this.gameObject);
        }
    }
}
