using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MovingPlatform : MonoBehaviour
{
    public float originalTimer;
    private float timer;
    public float xSpeed;
    private float xVector;
    public float ySpeed;
    private float yVector;
    // Start is called before the first frame update
    void Start()
    {
        timer = originalTimer;
    }
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = originalTimer;
            xSpeed = -xSpeed;
            ySpeed = -ySpeed;
        }
        xVector = xSpeed * Time.deltaTime;
        yVector = ySpeed * Time.deltaTime;
    }
}
