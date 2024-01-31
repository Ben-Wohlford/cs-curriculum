using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private HUD hud;
    private Rigidbody2D playerRb;
    private Collider2D playerCollider;
    private float rayCastOrigin;
    private float rayCastDistance;
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
        playerRb = GetComponent<Rigidbody2D>();
        playerCollider = gameObject.GetComponent<Collider2D>();
        Debug.Log(transform.position);
        Debug.Log(playerCollider.bounds.center);
        Debug.Log(transform.position.y-playerCollider.bounds.extents.y);
        Debug.Log(playerCollider.bounds.min.y);
        rayCastDistance = 1;
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
                playerRb.AddForce(transform.up * jumpForce);
            }
            RaycastHit2D hit = Physics2D.Raycast(transform.position - playerCollider.bounds.extents, -Vector2.up, rayCastDistance);
            if (hit.collider)
            {
                //Debug.Log("grounded "+hit.collider.tag);
            }
            else
            {
                //Debug.Log("not grounded");
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
        if (other.gameObject.CompareTag("Door") && hud.axe)
        {
            Debug.Log("door");
            Destroy(other.gameObject);
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