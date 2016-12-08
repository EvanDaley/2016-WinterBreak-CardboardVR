using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavMeshPlayer : MonoBehaviour {

    AudioSource audioSource;
    UnityEngine.AI.NavMeshAgent navMeshAgent;
    public float minSpeedForAudio;
    public float velocity;

    public bool canMove = true;
    public static NavMeshPlayer Instance;


    void Start () 
    {
        navMeshAgent = GetComponentInParent<UnityEngine.AI.NavMeshAgent> ();
        audioSource = GetComponent<AudioSource> (); 
        Instance = this;
    }

    void Update () 
    {
        if (navMeshAgent != null && audioSource != null)
        {
            velocity = navMeshAgent.velocity.magnitude;

            if (navMeshAgent.velocity.magnitude > minSpeedForAudio)
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.Play ();
                }
            } else
            {
                if (audioSource.isPlaying)
                {
                    audioSource.Stop ();
                }
            }
        }   
    }

    public void SetTarget(Vector3 target)
    {
        if (canMove == true)
        {
            navMeshAgent.SetDestination(target);
        }
    }

    void TeleportToTarget(Vector3 target)
    {
        if (canMove == true)
        {
            navMeshAgent.SetDestination(target);
            transform.position = target;
        }
    }
}
