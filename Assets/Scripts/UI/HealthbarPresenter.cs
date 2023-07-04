using UniRx;
using UnityEngine;
using Zenject;

namespace Diwide.Ziggurat.UI
{
    public class HealthbarPresenter : IInitializable
    {
        public ReactiveProperty<float> Health { get; private set; }
        private readonly Renderer _renderer;
        private readonly UnitSettings _unitSettings;
        private MaterialPropertyBlock _materialPropertyBlock;
        private static readonly int Health1 = Shader.PropertyToID("_Health");

        public HealthbarPresenter(Renderer renderer, UnitSettings unitSettings)
        {
            _renderer = renderer;
            _unitSettings = unitSettings;
        }
        
        public void Initialize()
        {
            Health = new(1f);
            Health.Subscribe(UpdateValue);
        }

        private void UpdateValue(float value)
        {
            _renderer.GetPropertyBlock(_materialPropertyBlock);
            _materialPropertyBlock.SetFloat(Health1, value / _unitSettings.health);
            _renderer.SetPropertyBlock(_materialPropertyBlock);
            // _renderer.GetPropertyBlock();
        }
        
        
    }
}