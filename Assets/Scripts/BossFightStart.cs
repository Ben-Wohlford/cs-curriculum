using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightStart : MonoBehaviour
{
    [SerializeField] private GameObject bossWall;
    [SerializeField] private GameObject boss;
    private int iterationCount;
    private Vector3 spawnPos;
    private Vector3 spawnPosBoss;
    // Start is called before the first frame update
    void Start()
    {
        iterationCount = 3;
        spawnPos.x = 15.5f;
        spawnPos.z = -1;
        spawnPosBoss.x = 3;
        spawnPosBoss.y = 23;
        spawnPosBoss.z = -1;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(boss, spawnPosBoss, transform.rotation);
            Debug.Log("boss");
            for (int i = 0; i < iterationCount; i++)
            {
                if (i != iterationCount)
                {
                    spawnPos.y = 13.5f - i;
                    Instantiate(bossWall, spawnPos, transform.rotation);
                }
                else
                {
                    break;
                }
                Debug.Log(i);
            }
            GameObject[] gOs = GameObject.FindGameObjectsWithTag("BossWall");
            foreach (GameObject gO in gOs)
            {
                Destroy(gO);
            }
        }
    }
}