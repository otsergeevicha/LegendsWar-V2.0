using Enemies.BossLogic;
using UnityEngine;

namespace Enemies.AI.States
{
    public class IdleState : State
    {
        [HideInInspector] [SerializeField] private BossTriggerZone _bossTriggerZone;

        private void OnValidate() => 
            _bossTriggerZone = ChildrenGet<BossTriggerZone>();

        protected override void OnEnabled()
        {
            EnteredState += OnActive;
            ExitedState += InActive;
            
            _bossTriggerZone.Triggered += OnTriggered;
        }

        protected override void OnDisabled()
        {
            EnteredState -= OnActive;
            ExitedState -= InActive;
            _bossTriggerZone.Triggered -= OnTriggered;
        }

        public override void OnActive() => 
            AnimatorCached.SetTrigger(Constants.IdleStateHash);

        public override void InActive() => 
            AnimatorCached.ResetTrigger(Constants.IdleStateHash);

        private void OnTriggered() => 
            StateMachine.EnterBehavior<MeleeAttackState>();
    }
}