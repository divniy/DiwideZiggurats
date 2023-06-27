using Diwide.Ziggurat;
using UnityEngine;

namespace TheKiwiCoder {

    // This is the blackboard container shared between all nodes.
    // Use this to store temporary data that multiple nodes need read and write access to.
    // Add other properties here that make sense for your specific use case.
    [System.Serializable]
    public class Blackboard {

        public Vector3 moveToPosition;

        public Transform Target
        {
            get => (_target && _target.gameObject.activeInHierarchy) ? _target : null;
            set => _target = value;
        }

        public UnitSettings settings;
        private Transform _target;
    }
}