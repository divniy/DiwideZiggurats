using System;
using System.Collections.Generic;
using NaughtyAttributes;
using TheKiwiCoder;
using Zenject;

namespace Diwide.Ziggurat.BehaviourTree.Actions
{
    [Serializable]
    public class AttackTask : ActionNode
    {
        // [Dropdown("AttackTriggers")]
        // public string triggerName;

        public AttackType attackType;

        private float _attackDamage;
        
        // private List<string> AttackTriggers => new() { "Fast", "Strong" };

        private bool _isAnimating;
        protected override void OnStart() {
            _isAnimating = true;
            _attackDamage = blackboard.settings.attackDamageDictionary[attackType];
            var triggerName = Enum.GetName(typeof(AttackType), attackType);
            context.animator.SetTrigger(triggerName);
            context.facade.EnemyHitAction += HitEnemy;
            context.environment.OnEndAnimation += OnEndAnimation;
        }

        private void OnEndAnimation(object sender, EventArgs e)
        {
            _isAnimating = false;
        }

        private void HitEnemy(UnitHealthHandler enemyHealthHandler)
        {
            enemyHealthHandler.TakeDamage(_attackDamage);
        }

        protected override void OnStop() {
            context.environment.OnEndAnimation -= OnEndAnimation;
            context.facade.EnemyHitAction -= HitEnemy;
        }

        protected override State OnUpdate()
        {
            if (!blackboard.HasTarget())
                return State.Failure;
        
            context.transform.LookAt(blackboard.Target.transform);
            
            if (_isAnimating) 
                return State.Running;
        
            return State.Success;
        }
    }
}
