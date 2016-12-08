using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTargetOption : LookTarget {

	void Start () 
	{
		SetGazedAt(false);
	}
		
	void Update ()
	{

	}

	public override void FireEvent()
	{
		Debug.Log ("Fired");
	}
}
