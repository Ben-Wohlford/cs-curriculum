using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightStart : MonoBehaviour
{
    [SerializeField] private GameObject bossWall;
    private bool startLoop;
    private int iterationCount;
    private bool canStartLoop;
    // Start is called before the first frame update
    void Start()
    {
        canStartLoop = true;
        iterationCount = 3;
        startLoop = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (startLoop)
        {
            for (int i = 0; i < iterationCount; i++)
            {
                if (i == iterationCount)
                {
                    startLoop = false;
                    break;
                }
                Debug.Log(i);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && canStartLoop)
        {
            canStartLoop = false;
            Debug.Log("boss");
            startLoop = true;
        }
    }
}
