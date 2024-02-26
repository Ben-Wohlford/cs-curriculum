using System;
using UnityEngine;

public class PlayerFireball : MonoBehaviour
{
    private Boss boss;
    private Vector3 target;
    private float timer;
    private GameObject[] enemies;
    private GameObject closest;
    private float distance;
    private Vector3 position;
    private Vector3 difference;
    private float currentDistance;
    // Start is called before the first frame update
    void Start()
    {
        timer = 7;
        FindClosestEnemy();
        target = closest.transform.position;
    }
    GameObject FindClosestEnemy()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        closest = null;
        distance = 1000000;
        position = transform.position;
        foreach (GameObject enemy in enemies)
        {
            difference = enemy.transform.position - position;
            currentDistance = difference.sqrMagnitude;
            if (currentDistance < distance)
            {
                closest = enemy;
                distance = currentDistance;
            }
        }
        return closest;
    }
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Destroy(this.gameObject);
        }
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, 0.01f);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }
}
