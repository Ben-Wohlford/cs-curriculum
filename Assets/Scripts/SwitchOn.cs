using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchOn : MonoBehaviour
{
    public bool on;
    private bool canSwitch;
    // Start is called before the first frame update
    void Start()
    {
        canSwitch = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canSwitch)
        {
            if (Input.GetKeyDown("e"))
            {
                if (on)
                {
                    on = false;
                    Debug.Log("switch off");
                }
                if (!on)
                {
                    on = true;
                    Debug.Log("switch on");
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Switch"))
        {
            canSwitch = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Switch"))
        {
            canSwitch = false;
        }
    }
}