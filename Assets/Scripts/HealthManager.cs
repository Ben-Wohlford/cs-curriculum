using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    private Scene scene;
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
        if (hud.health <= 0)
        {
            hud.health = 0;
            scene = SceneManager.GetActiveScene();
            if (scene.name == "Platformer")
            {
                SceneManager.LoadScene(sceneName: "Platformer");
            }
            else
            {
                SceneManager.LoadScene(sceneName: "Start");
            }
            Debug.Log("You died");
            hud.health = 10;
        }
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
            ChangeHealth(1);
        }
        if (other.gameObject.CompareTag("Enemy"))
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