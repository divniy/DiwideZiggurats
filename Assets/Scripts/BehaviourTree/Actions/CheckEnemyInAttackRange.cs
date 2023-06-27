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
            if (blackboard.Target == null) return State.Failure;
            var sqrDistanceToTarget = (context.transform.position - blackboard.Target.position).sqrMagnitude;
            return sqrDistanceToTarget <= attackRange * attackRange 
                ? State.Success : State.Failure;
        }
    }
}
