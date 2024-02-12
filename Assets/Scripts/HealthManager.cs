using System;
using UnityEngine;
public class HealthManager : MonoBehaviour
{
    private bool iFrames;
    private float timer;
    private float originaltimer;
    private HUD hud;
    // Start is called before the first frame update
    void Start()
    {
        hud = GameObject.FindObjectOfType<HUD>();
        originaltimer = 1.5f;
        timer = originaltimer;
        iFrames = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (iFrames) 
        {
            timer -= Time.deltaTime;
            if (timer < 0) 
            {
                iFrames = false;
                timer = originaltimer;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Spikes"))
        {
            ChangeHealth(2);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("HealthPotion"))
        {
            if (hud.health < hud.maxHealth)
            {
                hud.health += 1;
                other.gameObject.SetActive(false);
            }
        }
        if (other.gameObject.CompareTag("GreaterHealth"))
        {
            if (hud.health < hud.maxHealth)
            {
                hud.health += 2;
                other.gameObject.SetActive(false);
            }
        }
    }
    void ChangeHealth(int amount)
    {
        if (!iFrames)
        {
            iFrames = true;
            hud.health -= amount;
        }
    }
}