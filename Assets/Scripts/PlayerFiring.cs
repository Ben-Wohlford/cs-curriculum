using UnityEngine;
public class PlayerFiring : MonoBehaviour
{
    [SerializeField] private GameObject fireball;
    private float originalFireDelay;
    private float fireDelay;
    // Start is called before the first frame update
    void Start()
    {
        originalFireDelay = 0.75f;
        fireDelay = 0;
    }

    // Update is called once per frame
    void Update()
    {
        fireDelay -= Time.deltaTime;
        if ((Input.GetKeyDown("space")) && fireDelay < 0)
        {
            fireDelay = originalFireDelay;
            Instantiate(fireball, transform.position, transform.rotation);
        }
    }
}
