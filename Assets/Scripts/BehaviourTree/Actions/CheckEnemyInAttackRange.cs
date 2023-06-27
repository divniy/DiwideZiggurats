using System;
using TheKiwiCoder;

namespace Diwide.Ziggurat.BehaviourTree.Actions
{
    [Serializable]
    public class CheckEnemyInAttackRange : ActionNode
    {
        public float attackRange;
        protected override void OnStart()
        {
            attackRange = blackboard.settings.attackRange;
        }

        protected override void OnStop() {
        }

        protected override State OnUpdate()
        {
            if (!blackboard.HasTarget())
                return State.Failure;
            
            var ownerPosition = context.transform.position;
            var targetPosition = blackboard.Target.transform.position;

            var sqrDistanceToTarget = (ownerPosition - targetPosition).sqrMagnitude;
            return sqrDistanceToTarget <= attackRange * attackRange 
                ? State.Success : State.Failure;
        }
    }
}
