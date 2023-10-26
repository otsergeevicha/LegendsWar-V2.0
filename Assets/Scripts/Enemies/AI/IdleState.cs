using HeroLogic;
using UnityEngine;

namespace Enemies.AI
{
    public class IdleState : State
    {
        protected override void OnEnabled()
        {
            EnteredState += OnActive;
            ExitedState += InActive;
        }

        protected override void OnDisabled()
        {
            EnteredState -= OnActive;
            ExitedState -= InActive;
        }

        public override void OnActive()
        {
            Agent.isStopped = true;
            AnimatorCached.SetTrigger(Constants.IdleStateHash);
        }

        public override void InActive() => 
            AnimatorCached.ResetTrigger(Constants.IdleStateHash);

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.TryGetComponent(out Hero _)) 
                StateMachine.EnterBehavior<MeleeAttackState>();
        }
    }
}