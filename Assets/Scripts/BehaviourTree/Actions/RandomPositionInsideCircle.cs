using TheKiwiCoder;
using UnityEngine;

namespace Diwide.Ziggurat.BehaviourTree.Actions
{
    public class RandomPositionInsideCircle : ActionNode
    {
        public float circleRadius = 10f;
        public float heightOffset = 0;
        
        protected override void OnStart()
        {
        }

        protected override void OnStop()
        {
        }

        protected override State OnUpdate()
        {
            Vector2 randomPosition = Random.insideUnitCircle * circleRadius;
            blackboard.moveToPosition = new Vector3(randomPosition.x, heightOffset, randomPosition.y);
            return State.Success;
        }
    }
}