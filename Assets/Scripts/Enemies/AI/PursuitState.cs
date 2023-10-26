using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Enemies.AI
{
    public class PursuitState : State
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
            if (HeroNotReached(Constants.PursuitDistance))
            {
                Agent.destination = _heroTransform.position;
                AnimatorCached.SetBool(Constants.BossWalkHash, true);
            }

            LaunchObserve(Constants.PursuitDistance, Constants.MaxRangePursuit).Forget();
        }

        private async UniTaskVoid LaunchObserve(float pursuitDistance, float maxRangePursuit)
        {
            while (ConditionsPersecution(pursuitDistance, maxRangePursuit))
                await UniTask.Delay(Constants.TimeConditionsPersecution);

            if (HeroNotReached(Constants.MaxDistance)) 
                StateMachine.EnterBehavior<RangeAttackState>();
            
            if (HeroNotReached(Constants.MinDistance)) 
                StateMachine.EnterBehavior<MeleeAttackState>();
            
            if (HeroNotReached(Constants.MaxRangePursuit)) 
                StateMachine.EnterBehavior<IdleState>();
        }

        public override void InActive() => 
            AnimatorCached.SetBool(Constants.BossWalkHash, false);

        private bool ConditionsPersecution(float pursuitDistance, float maxRangePursuit) => 
            Vector3.Distance(Agent.transform.position, _heroTransform.position) >= pursuitDistance 
            && Vector3.Distance(Agent.transform.position, _heroTransform.position) < maxRangePursuit;

        private bool HeroNotReached(float pursuitDistance) =>
            Vector3.Distance(Agent.transform.position, _heroTransform.position) >= pursuitDistance;
    }
}