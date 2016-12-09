using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTargetOption : LookTarget {

    public TargetBehavior myTargetBehavior;

    public override  void FireEvent()
    {
        if (myTargetBehavior == TargetBehavior.attack)
        {
            print("Attack");

            CombatPlayer.Instance.basicAttack(this.transform);
        }

        if (myTargetBehavior == TargetBehavior.ability)
        {
            print("Ability");
        }

        if (myTargetBehavior == TargetBehavior.grenade)
        {
            print("Grenade");
        }

        if (myTargetBehavior == TargetBehavior.move)
        {
            NavMeshPlayer.Instance.SetTarget(transform.position);
        }
    }
}


public enum TargetBehavior
{
    attack,
    move,
    ability,
    grenade,
    special,
    beam
}