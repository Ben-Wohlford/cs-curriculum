using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random=UnityEngine.Random;
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private GameObject axe;
    [SerializeField] private GameObject coin;
    [SerializeField] private GameObject lesserHealth;
    [SerializeField] private GameObject greaterHealth;
    public bool axeEnemy;
    private float health;
    private float randomDrop;
    // Start is called before the first frame update
    void Start()
    {
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
            if (axeEnemy)
            {
                Instantiate(axe, transform.position, transform.rotation);
            }

            if (!axeEnemy)
            {
                //random drop between gold (2/7), normal health potion (2/7), nothing (2/7), and greater health potion (1/7)
                float randomDrop = Random.Range(1, 8);
                Debug.Log(randomDrop);
                if (randomDrop == 1 || randomDrop == 2)
                {
                    Instantiate(coin, transform.position, transform.rotation);
                }
                if (randomDrop == 3 || randomDrop == 4)
                {
                    Instantiate(lesserHealth, transform.position, transform.rotation);
                }
                if (randomDrop == 5)
                {
                    Instantiate(greaterHealth, transform.position, transform.rotation);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerProjectile"))
        {
            health -= 1;
        }
    }
}
