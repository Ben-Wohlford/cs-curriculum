using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class MovingPlatform : MonoBehaviour
{
    public bool needsSwitch;
    private SwitchOn switchOn;
    public float originalTimer;
    private float timer;
    public float xSpeed;
    public float xVector;
    public float ySpeed;
    public float yVector;
    // Start is called before the first frame update
    void Start()
    {
        timer = originalTimer;
        switchOn = GameObject.FindGameObjectWithTag("Player").GetComponent<SwitchOn>();
    }
    // Update is called once per frame
    void Update()
    {
        if (needsSwitch)
        {
            if (switchOn.on)
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
                transform.position += new Vector3(xVector, yVector, 0);
            }
        }
        else
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
            transform.position += new Vector3(xVector, yVector, 0);
        }
    }
}