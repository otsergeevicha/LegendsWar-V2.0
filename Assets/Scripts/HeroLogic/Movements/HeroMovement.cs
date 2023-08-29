﻿using System;
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
        [SerializeField] private Animator _animator;
        [SerializeField] private Hero _hero;
    
        private IInputService _input;
        private float _rotationVelocity;

        public void Construct(IInputService input) => 
            _input = input;

        private void OnValidate()
        {
            _controller = Get<CharacterController>();
            _animator = Get<Animator>();
            _hero = Get<Hero>();
        }

        protected override void UpdateCached() =>
            BaseLogic();

        protected override void OnDisabled() =>
            _input.OffControls();

        private void OnAnimEnded() =>
            _input.OnControls();

        private void BaseLogic()
        {
            Vector3 movementVector = Vector3.zero;

            if (_input.MoveAxis.sqrMagnitude > Single.Epsilon)
            {
                // _animator.SetBool(Constants.HeroWalkHash, true);
        
                movementVector = new Vector3(_input.MoveAxis.x, 0.0f, _input.MoveAxis.y).normalized;
                transform.forward = movementVector;
            }
            else
            {
                //_animator.SetBool(Constants.HeroWalkHash, false);
            }

            movementVector += Physics.gravity;

            _controller.Move(movementVector * (Constants.HeroSpeed * Time.deltaTime));
        }
    }
}