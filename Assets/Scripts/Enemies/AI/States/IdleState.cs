﻿using Enemies.BossLogic;
using UnityEngine;

namespace Enemies.AI.States
{
    public class IdleState : State
    {
        [HideInInspector] [SerializeField] private BossTriggerZone _bossTriggerZone;

        private void OnValidate() => 
            _bossTriggerZone = ChildrenGet<BossTriggerZone>();

        protected override void OnEnabled() => 
            _bossTriggerZone.EnterTriggered += OnTriggered;

        protected override void OnDisabled() => 
            _bossTriggerZone.EnterTriggered -= OnTriggered;

        public override void OnActive() {}

        public override void InActive() {}

        private void OnTriggered() => 
            StateMachine.EnterBehavior<PursuitState>();
    }
}