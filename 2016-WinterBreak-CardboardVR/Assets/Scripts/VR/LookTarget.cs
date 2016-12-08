﻿
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class LookTarget : MonoBehaviour, IGvrGazeResponder {

	public Color hitColor = Color.green;
	public Color nonhitColor = Color.red;

	private float stareTriggerCooldown = 0;
	private bool lookedAt = false;

	public float stareTriggerInitialTime = .3f;
	public float stareTriggerContinueTime = .3f;

	void Start() {
		SetGazedAt(false);
	}

	void LateUpdate() {
		GvrViewer.Instance.UpdateState();
		if (GvrViewer.Instance.BackButtonPressed) {
			Application.Quit();
		}

		if (lookedAt && Time.time > stareTriggerCooldown)
		{
			FireEvent ();
			stareTriggerCooldown = Time.time + MenuSettings.Instance.stareTriggerExtraTime + stareTriggerContinueTime;
		}
	}

	void OnEnable()
	{
		OnGazeExit ();
	}

	public void SetGazedAt(bool gazedAt) {
		GetComponent<Renderer>().material.color = gazedAt ? hitColor : nonhitColor;
		lookedAt = gazedAt;

		if (gazedAt)
			stareTriggerCooldown = Time.time + MenuSettings.Instance.stareTriggerExtraTime + stareTriggerInitialTime;
	}



	public virtual void FireEvent() 
	{

	}

	#region IGvrGazeResponder implementation

	/// Called when the user is looking on a GameObject with this script,
	/// as long as it is set to an appropriate layer (see GvrGaze).
	public void OnGazeEnter() {
		SetGazedAt(true);
	}

	/// Called when the user stops looking on the GameObject, after OnGazeEnter
	/// was already called.
	public void OnGazeExit() {
		SetGazedAt(false);
	}

	/// Called when the viewer's trigger is used, between OnGazeEnter and OnGazeExit.
	public void OnGazeTrigger() {
		FireEvent();
	}

	#endregion
}
