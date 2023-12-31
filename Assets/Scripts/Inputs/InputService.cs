﻿using System;
using Services.Inputs;
using UnityEngine;

namespace Inputs
{
    public class InputService : IInputService
    {
        private readonly MapInputs _input = new ();
        
        public Vector2 MoveAxis => 
            _input.Player.Move.ReadValue<Vector2>();

        public void OnMove(Action onMove) =>
            _input.Player.Move.performed += _ =>
                onMove?.Invoke();
        
        public void OffMove(Action onMove) =>
            _input.Player.Move.canceled += _ =>
                onMove?.Invoke();

        public Vector2 LookAxis => 
            _input.Player.Look.ReadValue<Vector2>();
        
        public void PushZoom(Action onZoom) => 
            _input.Player.Zoom.performed += _ =>
                onZoom?.Invoke();

        public void PushShoot(Action onShoot) => 
            _input.Player.Shoot.performed += _ =>
                onShoot?.Invoke();

        public void OffShoot(Action offShoot) => 
            _input.Player.Shoot.canceled += _ =>
                offShoot?.Invoke();

        public void PushSword(Action onFlamethrower) => 
            _input.Player.SwordAbility.performed += _ =>
                onFlamethrower?.Invoke();

        public void PushGrenade(Action onGrenade) => 
            _input.Player.GrenadeAbility.performed += _ =>
                onGrenade?.Invoke();

        public void PushUltimate(Action onShield) => 
            _input.Player.UltimateAbility.performed += _ =>
                onShield?.Invoke();

        public bool IsCurrentDevice() => 
            _input.KeyboardMouseScheme.name == Constants.KeyboardMouse;

        public void OnControls() => 
            _input.Player.Enable();

        public void OffControls() =>
            _input.Player.Disable();
    }
}