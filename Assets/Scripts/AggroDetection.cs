using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using System;

public class AggroDetection : MonoBehaviour
{
    Animator anim;
    public event Action<Transform> OnAggro = delegate { };
    public bool aggroDetected = false;
   
    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        PlayerMovement player = GetComponent<PlayerMovement>();
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerMovement>();
        if (player != null)
        {
            //Debug.Log("Aggro detector");
            OnAggro(player.transform);
            aggroDetected = true;
            if(aggroDetected == true)
            {
                ScoreManager.instance.AggroIncrementScore();
                anim.SetTrigger("Run");
            }

        }
    }
}