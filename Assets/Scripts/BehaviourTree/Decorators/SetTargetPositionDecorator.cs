using TheKiwiCoder;
using UnityEngine;

namespace Diwide.Ziggurat.BehaviourTree.Decorators
{
    [System.Serializable]
    public class SetTargetPositionDecorator : DecoratorNode
    {
        private static readonly int Movement = Animator.StringToHash("Movement");

        protected override void OnStart()
        {
        }

        protected override void OnStop() {
            context.animator.SetFloat(Movement, 0f);
        }

        protected override State OnUpdate()
        {
            if (!blackboard.HasTarget()) return State.Failure;
            
            var prevPosition = blackboard.moveToPosition;
            blackboard.moveToPosition = blackboard.Target.transform.position;
            var childState = child.Update();
            blackboard.moveToPosition = prevPosition;
            return childState;
        }
    }
}
