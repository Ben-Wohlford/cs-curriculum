using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random=UnityEngine.Random;
public class Boss : MonoBehaviour
{
    private float bossHealth;
    [SerializeField] private GameObject lesserHealth;
    [SerializeField] private GameObject greaterHealth;
    
    [SerializeField] private GameObject bossFireball;
    private GameObject fireballTarget;
    private float originalFireDelay;
    private float fireDelay;
    private Vector3 spawnPos;
    
    private UnityEngine.Vector3 target;
    private GameObject player;
    private Vector3 position;
    private Vector3 difference;
    private float currentDistance;
    // Start is called before the first frame update
    void Start()
    {
        bossHealth = 15;
        
        originalFireDelay = 2;
        fireDelay = originalFireDelay;
    }
    // Update is called once per frame
    void Update()
    {
        //Movement
        position = transform.position;
        player = GameObject.FindWithTag("Player");
        target = player.transform.position;
        difference = player.transform.position - position;
        currentDistance = difference.sqrMagnitude;
        if (target != null && currentDistance >= 10)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, 0.0025f);
        }
        //Firing
        fireballTarget = player.gameObject;
        fireDelay -= Time.deltaTime;
        if ((fireballTarget != null) && (fireDelay < 0))
        {
            //create projectile
            spawnPos = transform.position;
            Instantiate(bossFireball, spawnPos, transform.rotation);
            //timer
            fireDelay = originalFireDelay;
        }
        //Health
        if (bossHealth == 0)
        {
            Destroy(this.gameObject);
            Debug.Log("You win!");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerProjectile"))
        {
            bossHealth -= 1;
            //Random health drop
            float randomDrop = Random.Range(1, 8);
            if (randomDrop == 1 || randomDrop == 2)
            {
                Instantiate(lesserHealth, transform.position, transform.rotation);
            }
            if (randomDrop == 3)
            {
                Instantiate(greaterHealth, transform.position, transform.rotation);
            }
        }
    }
}
