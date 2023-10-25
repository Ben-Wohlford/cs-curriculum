using UnityEngine;
public class Turret : MonoBehaviour
{
    [SerializeField] private GameObject fireball;
    private Collider2D target;
    private float originalFireDelay;
    private float fireDelay;
    // Start is called before the first frame update
    void Start()
    {
        originalFireDelay = 2f;
        fireDelay = originalFireDelay;
    }
    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Debug.Log("t");
            fireDelay -= Time.deltaTime;
            if (fireDelay < 0)
            {
                //create projectile
                Instantiate(fireball, transform.position, transform.rotation);
                //timer
                fireDelay = originalFireDelay;
            }
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
            Debug.Log("not targeting");
        }
    }
}
