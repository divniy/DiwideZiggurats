using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class AttackTask : ActionNode
{
    public string triggerName;
    private bool isAnimating;
    protected override void OnStart() {
        isAnimating = true;
        context.animator.SetTrigger(triggerName);
        context.environment.OnEndAnimation += EnvironmentOnOnEndAnimation;
    }

    private void EnvironmentOnOnEndAnimation(object sender, EventArgs e)
    {
        isAnimating = false;
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate()
    {
        if (isAnimating) 
            return State.Running;
        
        return State.Success;
    }
}
