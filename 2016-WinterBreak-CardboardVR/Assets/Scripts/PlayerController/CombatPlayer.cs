using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatPlayer : MonoBehaviour {

    public Vector3 target;
    public Transform targetTrans;

    public Transform muzzle;

    public GameObject basicAttackPrefab;
    public GameObject specialPrefab;
    public GameObject grenadePrefab;

    public static CombatPlayer Instance;

	void Start () 
    {
        Instance = this;
	}
	
	void Update () 
    {
		
	}

    public void basicAttack(Transform targetTrans)
    {
        Vector3 startPosition = muzzle.position + (Random.insideUnitSphere * .1f);
        GameObject bullet = GameObject.Instantiate(basicAttackPrefab, startPosition, muzzle.rotation) as GameObject;

        SimpleProjectile projectileScript = bullet.GetComponent<SimpleProjectile>();
        projectileScript.SetTarget(targetTrans);
    }


    // will not be used for this game
    public void specialAttack(Transform targetTrans)
    {

    }

    // will not be used for this game
    public void grenadeAttack(Transform targetTrans)
    {

    }
}
