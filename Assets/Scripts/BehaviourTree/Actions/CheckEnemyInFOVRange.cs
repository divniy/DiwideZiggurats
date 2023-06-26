using TheKiwiCoder;
using UnityEngine;

namespace Diwide.Ziggurat.BehaviourTree.Actions
{
    public class CheckEnemyInFOVRange : ActionNode
    {
        public float range = 2f;
        private LayerMask _enemyLayerMask = 1 << 6 | 1 << 7 | 1 << 8;
        // private Transform _target;
        protected override void OnStart()
        {
            // _target = blackboard.target;
            _enemyLayerMask &= ~(1 << context.gameObject.layer);
        }

        protected override void OnStop()
        {
        }

        protected override State OnUpdate()
        {
            if (blackboard.target != null)
            {
                // blackboard.moveToPosition = blackboard.target.position;
                return State.Success;
            }

            Collider[] colliders = Physics.OverlapSphere(context.transform.position, range, _enemyLayerMask);
            if (colliders.Length > 0 && colliders[0].gameObject.activeInHierarchy)
            {
                blackboard.target = colliders[0].transform;
                // blackboard.moveToPosition = blackboard.target.position;
                return State.Success;
            }

            return State.Failure;
        }
    }
}