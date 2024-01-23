using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D playerRB;
    public float xDirection;
    public float yDirection;
    public float xVector;
    public float yVector;
    public float xSpeed;
    public float ySpeed;
    private float jumpForce;
    private bool grounded;
    public bool inCave;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        if (!inCave)
        {
            ySpeed = 4;
        }

        if (inCave)
        {
            jumpForce = 9;
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
                playerRB.AddForce(transform.up * jumpForce);
            }
        }
        transform.position = transform.position + new Vector3(xVector, yVector, 0);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }
}