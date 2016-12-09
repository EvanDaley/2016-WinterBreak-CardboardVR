using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleProjectile : MonoBehaviour {

    [HideInInspector]
    public Transform target;
    public float moveSpeed = 1f;
    public float checkProximityInterval = .5f;
    public float minDistanceForHit = .3f;
    public float lifeSpanAfterCollision = .3f;

    private float checkProximityCooldown;
    private float birthTime = 0;
    private float minLifeTime = .4f;

    private float deathTimer;

    private bool dead = false;

	void Start () 
    {
        birthTime = Time.time;
	}
	
	void Update () 
    {
        if (Time.time > checkProximityCooldown)
        {
            if (target != null)
            {
                checkProximityCooldown = Time.time + checkProximityInterval;

                if (Time.time - birthTime > minLifeTime)
                {
                    float distance = Vector3.Distance(transform.position, target.position);
                    if (distance < minDistanceForHit)
                    {
                        // hit
                        print("We hit the target");

                        if (dead == false)
                        {
                            dead = true;
                            deathTimer = Time.time + lifeSpanAfterCollision;
                        }
                    }
                }
            }
        }

        if(target != null)
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

        if (Time.time > deathTimer && dead)
            Die();
	}

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    void Die()
    {
        GameObject.Destroy(this.gameObject);
    }
}
