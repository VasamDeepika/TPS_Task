using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using System;

public class AggroDetection : MonoBehaviour
{
    public event Action<Transform> OnAggro = delegate { };
    public bool aggroDetected = false;
   
    private void Start()
    {
        PlayerMovement player = GetComponent<PlayerMovement>();
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
            }
        }
    }
}