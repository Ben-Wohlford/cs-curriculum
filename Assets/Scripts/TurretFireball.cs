using System;
using UnityEngine;
public class TurretFireball : MonoBehaviour
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
        timer = 5;
        target = player.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0 || transform.position == target)
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
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            hud.health -= 3;
        }
    }
}