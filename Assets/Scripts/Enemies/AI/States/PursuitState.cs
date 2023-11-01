using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Enemies.AI.States
{
    public class PursuitState : State
    {
        public override void OnActive()
        {
            // WatchingHero().Forget();
            //
            // if (HeroNotReached(Constants.PursuitDistance))
            // {
            //     Agent.destination = HeroTransform.position;
            //     AnimatorCached.SetBool(Constants.BossWalkHash, true);
            // }
            //
            // LaunchObserve(Constants.PursuitDistance, Constants.MaxRangePursuit).Forget();
        }

        public override void InActive() => 
            AnimatorCached.SetBool(Constants.BossWalkHash, false);

        private bool ConditionsPersecution(float pursuitDistance, float maxRangePursuit) =>
            Vector3.Distance(Agent.transform.position, HeroTransform.position) >= pursuitDistance
            && Vector3.Distance(Agent.transform.position, HeroTransform.position) < maxRangePursuit;

        private bool HeroNotReached(float pursuitDistance) =>
            Vector3.Distance(Agent.transform.position, HeroTransform.position) >= pursuitDistance;

        private async UniTaskVoid WatchingHero()
        {
            while (enabled)
            {
                transform.LookAt(HeroTransform);
                await UniTask.Delay(100, false, PlayerLoopTiming.FixedUpdate);
            }
        }

        private async UniTaskVoid LaunchObserve(float pursuitDistance, float maxRangePursuit)
        {
            while (ConditionsPersecution(pursuitDistance, maxRangePursuit))
                await UniTask.Delay(Constants.TimeConditionsPersecution);

            if (HeroNotReached(Constants.MinDistance))
                StateMachine.EnterBehavior<MeleeAttackState>();

            if (HeroNotReached(Constants.MaxRangePursuit))
                StateMachine.EnterBehavior<IdleState>();
        }
    }
}