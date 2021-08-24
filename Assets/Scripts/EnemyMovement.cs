using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
   
    AggroDetection aggro;
    NavMeshAgent nav;
    Transform enemyTarget;
    //public Transform player;
    public static EnemyMovement instance;
    public float enemySpeed;
    Animator anim;
    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        aggro = GetComponent<AggroDetection>();
        aggro.OnAggro += Aggro_OnAggro;
        instance = this;
    }
    private void Aggro_OnAggro(Transform target)
    {
        this.enemyTarget = target;
    }
    void Start()
    {
        
    }
    private void Update()
    {
        if (enemyTarget != null)
        {
            nav.SetDestination(enemyTarget.position);
            //transform.LookAt(player);
            enemySpeed = nav.velocity.magnitude;
            anim.SetFloat("Speed", enemySpeed);
        }
    }
}