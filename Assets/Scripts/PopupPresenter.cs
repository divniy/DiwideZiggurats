using System.Collections.Generic;
using DG.Tweening;
using RotaryHeart.Lib.SerializableDictionary;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Diwide.Ziggurat
{
    public class PopupPresenter : IInitializable
    {
        private Settings _settings;
        private Transform _transform;
        private readonly List<Selectable> _controls = new();
        private UnitSettings _unitSettings;
        private CompositeDisposable _disposables = new();
        private Vector3 _uiScale;

        private PopupPresenter(Settings settings)
        {
            _settings = settings;
            _transform = settings.view.transform;
        }
        
        public void Initialize()
        {
            _controls.Add(_settings.maxHealth);
            _controls.Add(_settings.respawnTime);
            _controls.Add(_settings.lightAttack);
            _controls.Add(_settings.strongAttack);
            _controls.Add(_settings.strongAttackRatio);
            
            _uiScale = _transform.localScale;
            _transform.localScale = Vector3.zero;
            SwitchInteractions(false);
        }

        public void Show(UnitSettings unitSettings)
        {
            _unitSettings = unitSettings;
            _settings.light.color = _settings.popupColors[unitSettings.unitTeam];
            BindValues();
            _transform.DOScale(_uiScale, _settings.animationDuration)
                .OnComplete(()=> SwitchInteractions(true));
        }

        private void BindValues()
        {
            _settings.maxHealth.value = _unitSettings.health;
            _settings.maxHealth.OnValueChangedAsObservable()
                .Subscribe(v => _unitSettings.health = v).AddTo(_disposables);
            
            _settings.respawnTime.value = _unitSettings.respawnTime;
            _settings.respawnTime.OnValueChangedAsObservable()
                .Subscribe(v => _unitSettings.respawnTime = v).AddTo(_disposables);
            
            _settings.lightAttack.value = _unitSettings.attackDamageDictionary[AttackType.Fast];
            _settings.lightAttack.OnValueChangedAsObservable()
                .Subscribe(v => _unitSettings.attackDamageDictionary[AttackType.Fast] = v).AddTo(_disposables);
            
            _settings.strongAttack.value = _unitSettings.attackDamageDictionary[AttackType.Strong];
            _settings.strongAttack.OnValueChangedAsObservable()
                .Subscribe(v => _unitSettings.attackDamageDictionary[AttackType.Strong] = v).AddTo(_disposables);
            
            _settings.strongAttackRatio.value = _unitSettings.strongAttackProbability;
            _settings.strongAttackRatio.OnValueChangedAsObservable()
                .Subscribe(v => _unitSettings.strongAttackProbability = (int) v).AddTo(_disposables);
        }

        public void Hide()
        {
            SwitchInteractions(false);
            _transform.DOScale(Vector3.zero, _settings.animationDuration);
            _disposables.Clear();
        }

        private void SwitchInteractions(bool isEnabled)
        {
            _controls.ForEach(_=> _.interactable = isEnabled);
        }
        
        [System.Serializable]
        public class Settings
        {
            public GameObject view;
            public float animationDuration = 2;
            public Slider maxHealth;
            public Slider respawnTime;
            public Slider lightAttack;
            public Slider strongAttack;
            public Slider strongAttackRatio;
            public Light light;
            public SerializableDictionaryBase<UnitTeam, Color> popupColors;
        }
    }
}