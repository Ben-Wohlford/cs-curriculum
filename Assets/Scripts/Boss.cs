using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private GameObject bossFireball;
    private Collider2D fireballTarget;
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
        if (target != null && currentDistance >= 7)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, 0.005f);
        }
        //Firing
        fireDelay -= Time.deltaTime;
        if ((fireballTarget != null) && (fireDelay < 0))
        {
            //create projectile
            spawnPos = transform.position;
            Instantiate(bossFireball, spawnPos, transform.rotation);
            //timer
            fireDelay = originalFireDelay;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            fireballTarget = other;
        }
    }
}
