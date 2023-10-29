using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Enemies.AI.States
{
    public class EnragedAttackState : State
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
            WatchingHero().Forget();
            
            if (HeroNotReached(Constants.MaxDistance)) 
                AnimatorCached.SetBool(Constants.EnragedAttackStateHash, true);
            
            if (!HeroNotReached(Constants.MaxDistance)) 
                StateMachine.EnterBehavior<PursuitState>();
        }

        public override void InActive() => 
            AnimatorCached.SetBool(Constants.EnragedAttackStateHash, false);

        private void Attacked()
        {
        }
        
        private bool HeroNotReached(float maxDistance) =>
            Vector3.Distance(Agent.transform.position, _heroTransform.position) >= maxDistance;
        
        private async UniTaskVoid WatchingHero()
        {
            while (enabled)
            {
                transform.LookAt(_heroTransform);
                await UniTask.Delay(100, false, PlayerLoopTiming.FixedUpdate);
            }
        }
    }
}