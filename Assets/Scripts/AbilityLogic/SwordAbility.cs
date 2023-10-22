using CameraLogic;
using Enemies;
using HeroLogic;
using Infrastructure.Factory.Pools;
using Services.Inputs;
using UnityEngine;

namespace AbilityLogic
{
    public class SwordAbility : Ability
    {
        [SerializeField] private Transform _firstPoint;
        [SerializeField] private Transform _secondPoint;
        
        private Animator _animator;
        
        private int _onClicks;
        private float _lastClickedTime;
        private readonly float _maxComboDelay = .7f;
        private float _nextFireTime;
        
        private Collider[] _overlappedColliders = new Collider[30];
        private Hero _hero;


        public override void Construct(IInputService inputService, Pool pool, CameraFollow cameraFollow,
            Animator animator, Hero hero)
        {
            _hero = hero;
            _animator = animator;
            
            _hero.SwordAnimationHited += CheckEnemies;
        }

        protected override void OnDisabled() => 
            _hero.SwordAnimationHited -= CheckEnemies;

        protected override void UpdateCached()
        {
            if (Time.time - _lastClickedTime > _maxComboDelay) 
                _onClicks = 0;
        }

        public override int GetIndexAbility() =>
            (int)IndexAbility.Sword;

        public override void Cast()
        {
            if (Time.time > _nextFireTime)
            {
                _lastClickedTime = Time.time;
                _onClicks++;

                if (_onClicks == 1) 
                    _animator.SetTrigger(Constants.OutwardSlashHash);

                if (_onClicks >= 2 && CheckStatusAnimation())
                    _animator.SetTrigger(Constants.InwardSlashHash);

                if (_onClicks >= 3 && CheckStatusAnimation())
                {
                    _animator.SetTrigger(Constants.SwordComboHash);
                    _onClicks = 0;
                }
            }
        }

        private void CheckEnemies()
        {
            Vector3 firstPointsCapsule = _firstPoint.position;
            Vector3 secondPointCapsule = _secondPoint.position;
            
            _overlappedColliders = Physics.OverlapCapsule(firstPointsCapsule, secondPointCapsule, Constants.RadiusSword);

            for (int i = 0; i < _overlappedColliders.Length; i++)
            {
                if (_overlappedColliders[i].gameObject.TryGetComponent(out Enemy enemy))
                    enemy.TakeDamage(Constants.SwordDamage);
            }
        }

        private bool CheckStatusAnimation() => 
            _animator.GetCurrentAnimatorStateInfo(0).normalizedTime > .4f;
    }
}