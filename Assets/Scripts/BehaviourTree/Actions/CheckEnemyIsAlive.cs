using TheKiwiCoder;

namespace Diwide.Ziggurat.BehaviourTree.Actions
{
    public class CheckEnemyIsAlive : ActionNode
    {
        protected override void OnStart()
        {
        }

        protected override void OnStop()
        {
        }

        protected override State OnUpdate()
        {
            var target = blackboard.Target;
            if (target != null && target.gameObject.activeInHierarchy)
                return State.Success;
            return State.Failure;
        }
    }
}