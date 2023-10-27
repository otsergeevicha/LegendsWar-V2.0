using UnityEngine;

namespace Enemies.AI.States
{
    public class MeleeAttackState : State
    {
        private Transform _heroTransform;

        protected override void OnEnabled()
        {
            EnteredState += OnActive;
            ExitedState += InActive;
            
            _heroTransform = HeroTransform;
        }

        protected override void OnDisabled()
        {
            EnteredState -= OnActive;
            ExitedState -= InActive;
        }

        public override void OnActive()
        {
            if (HeroNotReached(Constants.MinDistance)) 
                AnimatorCached.SetBool(Constants.MeleeAttackStateHash, true);
            
            if (!HeroNotReached(Constants.MinDistance)) 
                StateMachine.EnterBehavior<RangeAttackState>();
        }

        public override void InActive() => 
            AnimatorCached.SetBool(Constants.MeleeAttackStateHash, false);

        private bool HeroNotReached(float minimalDistance) =>
            Vector3.Distance(Agent.transform.position, _heroTransform.position) >= minimalDistance;
    }
}