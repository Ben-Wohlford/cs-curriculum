using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private UnityEngine.Vector3 target;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindWithTag("Player");
        target = player.transform.position;
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, 0.0025f);
        }
    }
}
