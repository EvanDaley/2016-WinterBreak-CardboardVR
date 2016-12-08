using UnityEngine;
using System.Collections;

public class NavMeshTarget : LookTarget {

    public override  void FireEvent()
    {
        NavMeshPlayer.Instance.SetTarget(transform.position);
    }
}
