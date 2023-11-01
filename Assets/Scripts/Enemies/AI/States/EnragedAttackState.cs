using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Enemies.AI.States
{
    public class EnragedAttackState : State, IBossAttacker
    {
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

        public void Attacked() {}

        public void StartAoeAttacked() {}

        public void EndAoeAttacked() {}

        private bool HeroNotReached(float maxDistance) =>
            Vector3.Distance(Agent.transform.position, HeroTransform.position) >= maxDistance;
        
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