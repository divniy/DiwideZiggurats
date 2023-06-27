using System;
using NaughtyAttributes;
using UnityEngine;
using Zenject;
using TheKiwiCoder;
using Context = TheKiwiCoder.Context;

namespace Diwide.Ziggurat
{
    public class UnitBehaviourTreeRunner : MonoBehaviour, IPoolable<UnitSettings>
    {
        private TheKiwiCoder.BehaviourTree _treePrototype;
        [ReadOnly]
        public TheKiwiCoder.BehaviourTree tree;

        private Context _context;

        [Inject]
        public void Construct(TheKiwiCoder.BehaviourTree treePrototype)
        {
            _treePrototype = treePrototype;
        }
        
        public void OnDespawned()
        {
            tree.rootNode.Abort();
            // tree = null;
        }

        public void OnSpawned(UnitSettings settings)
        {
            tree = _treePrototype.Clone();
            tree.blackboard.settings = settings;
            _context = CreateBehaviourTreeContext();
            tree.Bind(_context);
        }

        private void Start() {
        }

        // Update is called once per frame
        private void Update() {
            if (tree && gameObject.activeInHierarchy) {
                tree.Update();
            }
        }
        
        Context CreateBehaviourTreeContext() {
            return Context.CreateFromGameObject(gameObject);
        }

        private void OnDrawGizmosSelected() {
            if (!tree) {
                return;
            }

            TheKiwiCoder.BehaviourTree.Traverse(tree.rootNode, (n) => {
                if (n.drawGizmos) {
                    n.OnDrawGizmos();
                }
            });
        }
        
        [Serializable]
        public class Settings
        {
            public float speed;
            public float acceleration;
        }

        
    }
}