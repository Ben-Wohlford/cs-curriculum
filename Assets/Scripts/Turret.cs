using UnityEngine;
public class Turret : MonoBehaviour
{
    [SerializeField] private GameObject fireball;
    private Collider2D target;
    private float originalFireDelay;
    private float fireDelay;
    Vector3 spawnPos;
    // Start is called before the first frame update
    void Start()
    {
        originalFireDelay = 2f;
        fireDelay = 0;
    }
    // Update is called once per frame
    void Update()
    {
        fireDelay -= Time.deltaTime;
        if ((target != null) && (fireDelay < 0))
        {
            //create projectile
            spawnPos = transform.position;
            spawnPos.y += 1;
            Instantiate(fireball, spawnPos, transform.rotation);
            //timer
            fireDelay = originalFireDelay;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            target = other;
            Debug.Log("targeting player");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            target = null;
            fireDelay = originalFireDelay;
            Debug.Log("not targeting");
        }
    }
}
