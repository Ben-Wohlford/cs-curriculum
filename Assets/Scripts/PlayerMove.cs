using System;
using Unity.VisualScripting;
using UnityEngine;
public class PlayerMove : MonoBehaviour
{
    public float xDirection;
    public float yDirection;
    public float xVector;
    public float yVector;
    public float xSpeed;
    public float ySpeed;
    private bool jumping;
    private bool grounded;
    private float gravity;
    private float jumpTimer;
    private float originalJumpTimer;
    public bool inCave;
    // Start is called before the first frame update
    void Start()
    {
        if (!inCave)
        {
            ySpeed = 4;
        }

        if (inCave)
        {
            ySpeed = 10;
        }
        xSpeed = 4;
    }
    // Update is called once per frame
    void Update()
    {
        xDirection = Input.GetAxis("Horizontal");
        xVector = xDirection * xSpeed * Time.deltaTime;
        if (!inCave)
        {
            yDirection = Input.GetAxis("Vertical");
            yVector = yDirection * ySpeed * Time.deltaTime;
        }
        if (inCave)
        {
            
        }
        transform.position = transform.position + new Vector3(xVector, yVector, 0);
    }
}