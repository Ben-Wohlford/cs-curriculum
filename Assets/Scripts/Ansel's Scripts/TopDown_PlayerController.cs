using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDown_PlayerController : MonoBehaviour
{
    private TopDown_AnimatorController animatorScript;

    private void Start()
    {
        animatorScript = GetComponentInChildren<TopDown_AnimatorController>();
    }

    private void Update()
    {
        
    }
}