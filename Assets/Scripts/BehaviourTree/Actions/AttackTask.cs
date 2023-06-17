using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class AttackTask : ActionNode
{
    [Dropdown("AttackTriggers")]
    public string triggerName;

    private List<string> AttackTriggers
    {
        get { return new List<string>() { "Fast", "Strong" }; }
    }

    private bool _isAnimating;
    protected override void OnStart() {
        _isAnimating = true;
        context.animator.SetTrigger(triggerName);
        context.environment.OnEndAnimation += UnitEnvironmentOnEndAnimation;
    }

    private void UnitEnvironmentOnEndAnimation(object sender, EventArgs e)
    {
        _isAnimating = false;
    }

    protected override void OnStop() {
        context.environment.OnEndAnimation -= UnitEnvironmentOnEndAnimation;
    }

    protected override State OnUpdate()
    {
        if (_isAnimating) 
            return State.Running;
        
        return State.Success;
    }
}
