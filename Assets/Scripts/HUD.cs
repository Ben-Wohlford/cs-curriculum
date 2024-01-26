using System;
using TMPro;
using UnityEngine;
public class HUD : MonoBehaviour
{
    public static HUD hud;
    public bool axe;
    public int coins;
    public int health;
    public int maxHealth;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI healthText;
    private void Awake()
    {
        if (hud != null && hud != this)
        {
            Destroy(gameObject);
        }
        else
        {
            hud = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        axe = false;
        maxHealth = 10;
        coins = 0;
        health = maxHealth;
    }
    // Update is called once per frame
    void Update()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        healthText.text = "Health: " + health;
        coinText.text = "Coins: " + coins;
    }
}