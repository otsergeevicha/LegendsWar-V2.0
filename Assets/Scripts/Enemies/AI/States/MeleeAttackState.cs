using Cysharp.Threading.Tasks;
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
            WatchingHero().Forget();
            
            if (HeroNotReached(Constants.MinDistance)) 
                AnimatorCached.SetBool(Constants.MeleeAttackStateHash, true);
            
            if (!HeroNotReached(Constants.MinDistance)) 
                StateMachine.EnterBehavior<EnragedAttackState>();
        }

        public override void InActive() => 
            AnimatorCached.SetBool(Constants.MeleeAttackStateHash, false);

        private void Attacked()
        {
            
        }

        private void StartAoeAttacked()
        {
            
        }
        
        private void EndAoeAttacked()
        {
            
        }
        
        private bool HeroNotReached(float minimalDistance) =>
            Vector3.Distance(Agent.transform.position, _heroTransform.position) >= minimalDistance;

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