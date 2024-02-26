using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFireball : MonoBehaviour
{
    public UnityEngine.Vector3 target;
    private float timer;
    private GameObject player;
    private HUD hud;
    // Start is called before the first frame update
    void Start()
    {
        hud = GameObject.FindObjectOfType<HUD>();
        player = GameObject.FindWithTag("Player");
        timer = 3;
    }
    // Update is called once per frame
    void Update()
    {
        target = player.transform.position;
        timer -= Time.deltaTime;
        if (timer < 0 || transform.position == target)
        {
            Destroy(this.gameObject);
        }
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, 0.005f);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            hud.health -= 2;
        }
    }
}
