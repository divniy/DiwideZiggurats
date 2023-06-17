using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class SetTargetPositionDecorator : DecoratorNode
{
    protected override void OnStart()
    {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate()
    {
        if (blackboard.target == null) return State.Failure;
        Vector3 prevPosition = blackboard.moveToPosition;
        blackboard.moveToPosition = blackboard.target.position;
        var state = child.Update();
        blackboard.moveToPosition = prevPosition;
        return state;
    }
}
