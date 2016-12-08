using UnityEngine;
using System.Collections;

public class MechanicalCart : MonoBehaviour {

	AudioSource audioSource;
	UnityEngine.AI.NavMeshAgent navMeshAgent;
	public float minSpeedForAudio;
	public float velocity;

	// Use this for initialization
	void Start () 
	{
		navMeshAgent = GetComponentInParent<UnityEngine.AI.NavMeshAgent> ();
		audioSource = GetComponent<AudioSource> ();
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
}
