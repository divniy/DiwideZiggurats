using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class CheckEnemyInAttackRange : ActionNode
{
    public float attackRange;
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate()
    {
        if (blackboard.target == null) return State.Failure;
        // float sqrDistanceToTarget = (context.transform.position - blackboard.target.position).sqrMagnitude;
        // if (sqrDistanceToTarget <= Mathf.Pow(attackRange, 2))
        // {
        //     return State.Success;
        // }
        if (Vector3.Distance(context.transform.position, blackboard.target.position) <= attackRange)
        {
            return State.Success;
        }

        return State.Failure;
    }
}
