using CameraLogic;
using HeroLogic.Movements;
using HeroLogic.Shooting;
using Infrastructure.Factory.Pools;
using Plugins.MonoCache;
using Services.Health;
using Services.Inputs;
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

        private HeroHealth _health;

        public void Construct(IInputService input, Pool pool, CameraFollow cameraFollow)
        {
            _health = new HeroHealth(Constants.HeroMaxHealth);
            _health.Died += GameOver;

            _heroMovement.Construct(input);
            _heroShooting.Construct(input, pool, cameraFollow);
        }

        private void OnValidate()
        {
            _heroMovement = Get<HeroMovement>();
            _heroShooting = Get<HeroShooting>();
        }

        protected override void OnDisabled() => 
            _health.Died -= GameOver;

        public Transform GetCameraRoot() => 
            _rootCamera.transform;

        public void TakeDamage(int damage) => 
            _health.ApplyDamage(damage);

        private void GameOver()
        {
            Time.timeScale = 0;
        }
    }
}