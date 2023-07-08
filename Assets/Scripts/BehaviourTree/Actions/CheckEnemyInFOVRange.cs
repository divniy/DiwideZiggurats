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
                    var unit = colliders[0].GetComponent<UnitFacade>();
                    if (!unit.IsAlive) return State.Failure;
                    
                    Debug.Log($"{context.gameObject.name} at {context.transform.position} targeting {unit.gameObject.name} at {unit.transform.position}");
                    // var distance = Vector3.Distance(context.transform.position, unit.transform.position);
                    // if (distance > range * 2)
                    // {
                    //     Debug.Log($"{context.gameObject.name} target distance = {distance}");
                    // }
                    blackboard.Target = unit;
                    return State.Success;
                case > 1:
                {
                    var closestUnit = colliders
                        .Select(collider => new
                            {facade = collider.GetComponent<UnitFacade>(), distance = Vector3.Distance(context.transform.position, collider.transform.position)}
                        )
                        .Where(_=> _.facade.IsAlive)
                        .OrderBy(_ => _.distance)
                        .First().facade;
                    
                    Debug.Log($"{context.gameObject.name} at {context.transform.position} targeting {closestUnit.gameObject.name} at {closestUnit.transform.position} from {colliders.Length}");
                    blackboard.Target = closestUnit;
                    return State.Success;
                }
                default:
                    return State.Failure;
            }
        }
    }
}