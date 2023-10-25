using System;
using AbilityLogic;
using CameraLogic;
using Plugins.MonoCache;
using Services.Inputs;
using UnityEngine;

namespace HeroLogic.Movements
{
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(Hero))]
    [RequireComponent(typeof(Animator))]
    public class HeroMovement : MonoCache
    {
        [SerializeField] private CharacterController _controller;
        
        private Hero _hero;
        private Animator _animator;
        
        private IInputService _input;
        private float _rotationVelocity;
        private Transform _cameraFollow;

        public void Construct(IInputService input, CameraFollow cameraFollow, Animator animator, Hero hero)
        {
            _input = input;
            _hero = hero;
            _cameraFollow = cameraFollow.transform;
            _animator = animator;
            
            _input.OnControls();
        }

        private void OnValidate() => 
            _controller = Get<CharacterController>();

        protected override void UpdateCached() => 
            BaseLogic();

        protected override void OnDisabled() => 
            _input.OffControls();

        private void BaseLogic()
        {
            Vector3 movementDirection = Vector3.zero;

            if (_input.MoveAxis.sqrMagnitude > Single.Epsilon)
            {
                _animator.SetBool(
                    _hero.GetCurrentAbility == (int)IndexAbility.Sword
                        ? Constants.HeroSwordRunHash
                        : Constants.HeroWithoutSwordRunHash, true);

                Vector3 cameraForward = _cameraFollow.forward;
                cameraForward.y = 0;
                cameraForward.Normalize();

                movementDirection = cameraForward * _input.MoveAxis.y + _cameraFollow.right * _input.MoveAxis.x;

                if (movementDirection != Vector3.zero) 
                    transform.forward = movementDirection.normalized;
            }
            else
            {
                _animator.SetBool(Constants.HeroSwordRunHash, false);
                _animator.SetBool(Constants.HeroWithoutSwordRunHash, false);
            }
            
            movementDirection += Physics.gravity;

            _controller.Move(movementDirection * (Constants.HeroSpeed * Time.deltaTime));
        }
    }
}