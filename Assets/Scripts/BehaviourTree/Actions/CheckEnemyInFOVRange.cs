using System.Linq;
using TheKiwiCoder;
using UnityEngine;

namespace Diwide.Ziggurat.BehaviourTree.Actions
{
    public class CheckEnemyInFOVRange : ActionNode
    {
        public float range = 2f;
        private LayerMask _enemyLayerMask = 1 << 6 | 1 << 7 | 1 << 8;
        protected override void OnStart()
        {
            _enemyLayerMask &= ~(1 << context.gameObject.layer);
        }

        protected override void OnStop()
        {
        }

        protected override State OnUpdate()
        {
            if (blackboard.HasTarget())
            {
                return State.Success;
            }

            Collider[] colliders = Physics.OverlapSphere(context.transform.position, range, _enemyLayerMask, QueryTriggerInteraction.Ignore);
            switch (colliders.Length)
            {
                case 1:
                    blackboard.Target = colliders[0].gameObject;
                    return State.Success;
                case > 1:
                {
                    var closestCollider = colliders
                        .Select(collider => new
                            {collider, distance = Vector3.Distance(context.transform.position, collider.transform.position)}
                        )
                        .OrderBy(_ => _.distance)
                        .First().collider;
                    
                    blackboard.Target = closestCollider.gameObject;
                    return State.Success;
                }
                default:
                    return State.Failure;
            }
        }
    }
}