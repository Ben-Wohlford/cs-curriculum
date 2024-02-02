using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private HUD hud;
    private Rigidbody2D playerRb;
    public float xDirection;
    public float yDirection;
    public float xVector;
    public float yVector;
    public float xSpeed;
    public float ySpeed;
    private float jumpForce;
    private bool grounded;
    public bool inCave;
    private bool hasAxe;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        hasAxe = false;
        if (!inCave)
        {
            ySpeed = 4;
        }

        if (inCave)
        {
            jumpForce = 6;
        }
        xSpeed = 4;
    }
    // Update is called once per frame
    void Update()
    {
        xDirection = Input.GetAxis("Horizontal");
        yDirection = Input.GetAxis("Vertical");
        xVector = xDirection * xSpeed * Time.deltaTime;
        if (!inCave)
        {
            yVector = yDirection * ySpeed * Time.deltaTime;
        }
        if (inCave)
        {
            if (grounded && yDirection > 0)
            {
                playerRb.AddForce(transform.up * jumpForce);
            }
            grounded = Physics2D.Raycast(transform.position, Vector2.down, .75f);
            if (!grounded)
            {
                Debug.Log("ng");
            }
        }
        transform.position+= new Vector3(xVector, yVector, 0);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Axe"))
        {
            Destroy(other.gameObject);
            hasAxe = true;
        }

        if (other.gameObject.CompareTag("Door"))
        {
            Destroy(other.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        //if (other.gameObject.CompareTag("Ground"))
        {
            //grounded = true;
        }
        if (other.gameObject.CompareTag("Door") && hasAxe)
        {
            Debug.Log("door");
            Destroy(other.gameObject);
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        //if (other.gameObject.CompareTag("Ground"))
        {
            //grounded = false;
        }
    }
}