using System;
using System.Collections.Generic;
using NaughtyAttributes;
using TheKiwiCoder;

namespace Diwide.Ziggurat.BehaviourTree.Actions
{
    [Serializable]
    public class AttackTask : ActionNode
    {
        [Dropdown("AttackTriggers")]
        public string triggerName;

        private List<string> AttackTriggers => new() { "Fast", "Strong" };

        private bool _isAnimating;
        protected override void OnStart() {
            context.transform.LookAt(blackboard.target);
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
            if (blackboard.target == null || !blackboard.target.gameObject.activeInHierarchy)
                return State.Failure;
        
            if (_isAnimating) 
                return State.Running;
        
            return State.Success;
        }
    }
}
