using System;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.AI;

namespace Diwide.Ziggurat
{
    public class UnitDebug : MonoBehaviour
    {
        public Vector3 destination = Vector3.zero;
        private NavMeshAgent _navMeshAgent;
        private UnitEnvironment _unitEnvironment;

        private void Start()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _unitEnvironment = GetComponent<UnitEnvironment>();
        }

        [Button]
        private void GoToDestination()
        {
            _navMeshAgent.destination = destination;
            _unitEnvironment.Moving(_navMeshAgent.speed);
        }

        private void Update()
        {
            if (!_navMeshAgent.pathPending && _navMeshAgent.remainingDistance <= 0.5f)
            {
                _unitEnvironment.Moving(0f);
            }
        }
    }
}