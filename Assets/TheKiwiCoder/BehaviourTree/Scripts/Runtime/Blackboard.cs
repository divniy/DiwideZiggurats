using System;
using Diwide.Ziggurat;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;
using UniRx;

namespace TheKiwiCoder {

    // This is the blackboard container shared between all nodes.
    // Use this to store temporary data that multiple nodes need read and write access to.
    // Add other properties here that make sense for your specific use case.
    [System.Serializable]
    public class Blackboard {

        private UnitFacade _target;
        private IDisposable _disposable;
        public Vector3 moveToPosition;

        public UnitFacade Target
        {
            get => _target;
            set
            {
                _target = value;
                _disposable = _target.HealthHandler.IsDead.Subscribe(_ => NullifyTarget(_));
            }
        }

        public UnitSettings settings;

        private void NullifyTarget(bool res)
        {
            if (!res) return;
            _target = null;
            _disposable.Dispose();
        }

        public bool HasTarget()
        {
            return Target && Target.IsAlive;
        }
    }
}