using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Enemies.AI.States
{
    [RequireComponent(typeof(AttackOperator))]
    public class EnragedAttackState : State
    {
        public override void OnActive() => 
            WatchingHero().Forget();

        public override void InActive() => 
            AnimatorCached.SetBool(Constants.MeleeAttackStateHash, false);

        private bool DistanceAttack(float minimalDistance) =>
            Vector3.Distance(Boss.SpawnPointAttack, HeroTransform.position) <= minimalDistance;

        private bool RelevantConditions() => 
            !DistanceAttack(Boss.DistanceAttack) && AnimatorCached.GetCurrentAnimatorStateInfo(0).normalizedTime >= .7f;

        private async UniTaskVoid WatchingHero()
        {
            AnimatorCached.SetBool(Constants.MeleeAttackStateHash, true);
            
            while (enabled)
            {
                transform.LookAt(HeroTransform);

                if (RelevantConditions()) 
                    StateMachine.EnterBehavior<PursuitState>();

                await UniTask.Delay(100, false, PlayerLoopTiming.PreLateUpdate);
            }
        }
    }
}