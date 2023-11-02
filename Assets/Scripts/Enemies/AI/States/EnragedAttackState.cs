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

        private async UniTaskVoid WatchingHero()
        {
            AnimatorCached.SetBool(Constants.MeleeAttackStateHash, true);
            
            while (enabled)
            {
                transform.LookAt(HeroTransform);
                await UniTask.Delay(100, false, PlayerLoopTiming.FixedUpdate);
            }
        }
    }
}