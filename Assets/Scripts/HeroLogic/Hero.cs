using CameraLogic;
using HeroLogic.Movements;
using HeroLogic.Shooting;
using Infrastructure.Factory.Pools;
using Plugins.MonoCache;
using Services.Health;
using Services.Inputs;
using Services.SaveLoad;
using UnityEngine;

namespace HeroLogic
{
    [RequireComponent(typeof(HeroMovement))]
    [RequireComponent(typeof(HeroShooting))]
    public class Hero : MonoCache, IHealth
    {
        [SerializeField] private HeroMovement _heroMovement;
        [SerializeField] private HeroShooting _heroShooting;
        [SerializeField] private RootCamera _rootCamera;

        [SerializeField] private Animator _animator;
        
        public int Health => _health.ReturnHealth();
        public int GetCurrentAbility => _heroShooting.GetIndexAbility();
        
        private HeroHealth _health;
        private ISave _save;

        public void Construct(IInputService input, Pool pool, CameraFollow cameraFollow,ISave save)
        {
            _save = save;
            _health = new HeroHealth(Constants.HeroMaxHealth);
            _health.Died += GameOver;

            _heroMovement.Construct(input);
            _heroShooting.Construct(input, pool, cameraFollow, _animator,this);
            _save.AccessProgress()._characterAttributes.RecordHealth(Health);
           // _save.AccessProgress().DataStats.RecordEnergy(Energy);
        }

        private void OnValidate()
        {
            _animator = Get<Animator>();
            _heroMovement = Get<HeroMovement>();
            _heroShooting = Get<HeroShooting>();
        }

        protected override void OnDisabled() => 
            _health.Died -= GameOver;

        public Transform GetCameraRoot() => 
            _rootCamera.transform;

        public void TakeDamage(int damage)
        {
            _health.ApplyDamage(damage);
            
            _save.AccessProgress()._characterAttributes.RecordHealth(Health);
        }

        private void GameOver()
        {
            Time.timeScale = 0;
        }
    }
}