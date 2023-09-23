﻿using System;
using AbilityLogic;
using Plugins.MonoCache;
using Services.Inputs;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.OnScreen;

namespace HeroLogic.Movements
{
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(Hero))]
    [RequireComponent(typeof(Animator))]
    public class HeroMovement : MonoCache
    {
        [SerializeField] private CharacterController _controller;
        [SerializeField] private Hero _hero;
    
        private Animator _animator;
        private IInputService _input;
        private float _rotationVelocity;

        public void Construct(IInputService input)
        {
            _input = input;
            _input.OnControls();
        }

        private void OnValidate()
        {
            _controller = Get<CharacterController>();
            _hero = Get<Hero>();
        }

        protected override void UpdateCached() =>
            BaseLogic();

        protected override void OnDisabled() =>
            _input.OffControls();

        private void BaseLogic()
        {
            Vector3 movementVector = Vector3.zero;

            if (_input.MoveAxis.sqrMagnitude > Single.Epsilon)
            {
                _animator.SetBool(
                    _hero.GetCurrentAbility == (int)IndexAbility.Sword
                        ? Constants.HeroSwordRunHash
                        : Constants.HeroWithoutSwordRunHash, true);

                movementVector = new Vector3(_input.MoveAxis.x, 0.0f, _input.MoveAxis.y).normalized;
                transform.forward = movementVector;
            }
            else
            {
                _animator.SetBool(Constants.HeroSwordRunHash, false);
                _animator.SetBool(Constants.HeroWithoutSwordRunHash, false);
            }

            movementVector += Physics.gravity;

            _controller.Move(movementVector * (Constants.HeroSpeed * Time.deltaTime));
        }
    }
}