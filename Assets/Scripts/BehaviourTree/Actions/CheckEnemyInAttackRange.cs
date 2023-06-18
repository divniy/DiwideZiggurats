using System;
using TheKiwiCoder;

namespace Diwide.Ziggurat.BehaviourTree.Actions
{
    [Serializable]
    public class CheckEnemyInAttackRange : ActionNode
    {
        public float attackRange = 1f;
        protected override void OnStart() {
        }

        protected override void OnStop() {
        }

        protected override State OnUpdate()
        {
            if (blackboard.target == null) return State.Failure;
            var sqrDistanceToTarget = (context.transform.position - blackboard.target.position).sqrMagnitude;
            return sqrDistanceToTarget <= attackRange * attackRange 
                ? State.Success : State.Failure;
        }
    }
}
