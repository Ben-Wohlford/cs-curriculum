using UnityEngine;

public class PlayerFireball : MonoBehaviour
{
    private Vector3 target;
    private float timer;
    private GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindWithTag("Enemy");
        timer = 7;
        target = enemy.transform.position;
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
