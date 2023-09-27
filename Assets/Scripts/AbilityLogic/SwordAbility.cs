using CameraLogic;
using Infrastructure.Factory.Pools;
using Services.Inputs;
using UnityEngine;

namespace AbilityLogic
{
    public class SwordAbility : Ability
    {
        private Animator _animator;
        
        private int _onClicks;
        private float _lastClickedTime;
        private readonly float _maxComboDelay = .7f;
        private float _nextFireTime;

        public override void Construct(IInputService inputService, Pool pool, CameraFollow cameraFollow,
            Animator animator)
        {
            _animator = animator;
        }

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

        private bool CheckStatusAnimation() => 
            _animator.GetCurrentAnimatorStateInfo(0).normalizedTime > .4f;
    }
}