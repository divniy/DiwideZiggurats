using UniRx;
using UnityEngine;
using Zenject;

namespace Diwide.Ziggurat.UI
{
    public class HealthbarPresenter : IInitializable
    {
        public ReactiveProperty<float> Health { get; private set; }
        private UnitHealthHandler _healthHandler;
        private readonly Renderer _renderer;
        private readonly UnitSettings _unitSettings;
        private MaterialPropertyBlock _materialPropertyBlock = new ();
        private static readonly int Health1 = Shader.PropertyToID("_Health");

        [Inject]
        public HealthbarPresenter(MeshRenderer renderer, UnitSettings unitSettings, UnitHealthHandler healthHandler)
        {
            _renderer = renderer;
            _unitSettings = unitSettings;
            _healthHandler = healthHandler;
        }
        
        public void Initialize()
        {
            _healthHandler.Health.Subscribe(UpdateValue);
        }

        private void UpdateValue(float value)
        {
            _renderer.GetPropertyBlock(_materialPropertyBlock);
            _materialPropertyBlock.SetFloat(Health1, value / _unitSettings.health);
            _renderer.SetPropertyBlock(_materialPropertyBlock);
            // _renderer.GetPropertyBlock();
        }


        // public void OnDespawned()
        // {
        //     throw new System.NotImplementedException();
        // }
        //
        // public void OnSpawned()
        // {
        //     _healthHandler.Health.Subscribe(UpdateValue);
        // }
    }
}