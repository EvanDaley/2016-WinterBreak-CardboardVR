using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTarget : LookTarget {

    public AttackTargetBehavior myTargetBehavior;


    // Use this for initialization
    void Start () 
    {

    }

    // Update is called once per frame
    void Update () 
    {


    }

    public override  void FireEvent()
    {
        if (myTargetBehavior == AttackTargetBehavior.basicAttack)
        {
            print("Attack");

            CombatPlayer.Instance.basicAttack(this.transform);
        }

        if (myTargetBehavior == AttackTargetBehavior.ability)
        {
            print("Ability");
        }

        if (myTargetBehavior == AttackTargetBehavior.grenade)
        {
            print("Grenade");
        }
    }
}


public enum AttackTargetBehavior
{
    basicAttack,
    ability,
    grenade,
    special,
    beam
}
