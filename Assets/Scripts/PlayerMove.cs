using System;
using Unity.VisualScripting;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

public class PlayerMove : MonoBehaviour
{
    private HUD hud;
    private Rigidbody2D playerRb;
    private Transform onPlatform;
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
    private bool hasKey;
    private float platformXVector;
    private float platformYVector;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        hasAxe = false;
        if (!inCave)
        {
            ySpeed = 6;
        }

        if (inCave)
        {
            jumpForce = 8;
        }
        xSpeed = 6;
    }
    
    // Update is called once per frame
    void Update()
    {
        xDirection = Input.GetAxis("Horizontal");
        yDirection = Input.GetAxis("Vertical");
        //Moving
        xVector = xDirection * xSpeed * Time.deltaTime;
        if (!inCave)
        {
            yVector = yDirection * ySpeed * Time.deltaTime;
        }
        if (inCave)
        {
            //Jumping
            if (grounded && yDirection > 0)
            {
                playerRb.AddForce(transform.up * jumpForce);
            }
            grounded = Physics2D.Raycast(transform.position, Vector2.down, .75f);
            //Moving platforms
            RaycastHit2D onPlatform = Physics2D.Raycast(transform.position, Vector2.down, .75f);
            if (onPlatform.collider != null)
            {
                if (onPlatform.transform.CompareTag("MovingPlatform"))
                {
                    transform.SetParent(onPlatform.transform);
                }
                else
                {
                    transform.SetParent(null);
                }
            }
            else
            {
                transform.SetParent(null);
            }
        }
        //Movement
        transform.position += new Vector3(xVector, yVector, 0);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Axe"))
        {
            Destroy(other.gameObject);
            hasAxe = true;
        }
        if (other.gameObject.CompareTag("Key"))
        {
            Destroy(other.gameObject);
            hasKey = true;
        }
        if (other.gameObject.CompareTag("Door"))
        {
            Destroy(other.gameObject);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Door") && hasAxe)
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Door1") && hasKey)
        {
            Destroy(other.gameObject);
        }
    }
}