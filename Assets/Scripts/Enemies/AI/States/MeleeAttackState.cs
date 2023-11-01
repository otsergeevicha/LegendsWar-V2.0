using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Enemies.AI.States
{
    public class MeleeAttackState : State, IBossAttacker
    {
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

        public void Attacked() {}

        public void StartAoeAttacked() {}

        public void EndAoeAttacked() {}
        
        private bool HeroNotReached(float minimalDistance) =>
            Vector3.Distance(Agent.transform.position, HeroTransform.position) >= minimalDistance;

        private async UniTaskVoid WatchingHero()
        {
            while (enabled)
            {
                transform.LookAt(HeroTransform);
                await UniTask.Delay(100, false, PlayerLoopTiming.FixedUpdate);
            }
        }
    }
}