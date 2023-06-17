using TheKiwiCoder;
using UnityEngine;

namespace Diwide.Ziggurat.BehaviourTree.Actions
{
    [System.Serializable]
    public class AnimateMoveToPosition : ActionNode
    {
        public float speed = 5;
        public float stoppingDistance = 0.1f;
        public bool updateRotation = true;
        public float acceleration = 40.0f;
        public float tolerance = 1.0f;
        private Vector3 _moveToPosition;
        
        protected override void OnStart()
        {
            _moveToPosition = blackboard.moveToPosition;
            
            context.agent.speed = speed;
            context.agent.stoppingDistance = stoppingDistance;
            context.agent.updateRotation = updateRotation;
            context.agent.acceleration = acceleration;
            context.agent.destination = _moveToPosition;
            context.environment.Moving(speed);
        }

        protected override void OnStop()
        {
        }

        protected override State OnUpdate()
        {
            if (_moveToPosition != blackboard.moveToPosition)
            {
                _moveToPosition = blackboard.moveToPosition;
                context.agent.SetDestination(_moveToPosition);
            }
            
            if (context.agent.pathPending) {
                return State.Running;
            }

            if (context.agent.remainingDistance < tolerance) {
                context.environment.Moving(0f);
                return State.Success;
            }

            if (context.agent.pathStatus == UnityEngine.AI.NavMeshPathStatus.PathInvalid) {
                return State.Failure;
            }

            return State.Running;
        }
    }
}