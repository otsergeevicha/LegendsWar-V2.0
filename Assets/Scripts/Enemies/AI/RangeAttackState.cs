using UnityEngine;

namespace Enemies.AI
{
    public class RangeAttackState : State
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
            if (HeroNotReached(Constants.MaxDistance)) 
                AnimatorCached.SetBool(Constants.RangeAttackStateHash, true);
            
            if (!HeroNotReached(Constants.MaxDistance)) 
                StateMachine.EnterBehavior<PursuitState>();
        }

        public override void InActive() => 
            AnimatorCached.SetBool(Constants.RangeAttackStateHash, false);

        private bool HeroNotReached(float maxDistance) =>
            Vector3.Distance(Agent.transform.position, _heroTransform.position) >= maxDistance;
    }
}