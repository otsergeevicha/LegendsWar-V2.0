using Cysharp.Threading.Tasks;
using Enemies.BossLogic;
using UnityEngine;

namespace Enemies.AI.States
{
    public class PursuitState : State
    {
        [HideInInspector] [SerializeField] private BossTriggerZone _bossTriggerZone;

        private bool _isCooldown;

        private void OnValidate() =>
            _bossTriggerZone = ChildrenGet<BossTriggerZone>();

        protected override void OnEnabled()
        {
            _bossTriggerZone.EnterTriggered += OnEntered;
            _bossTriggerZone.ExitTriggered += OnExited;
        }

        protected override void OnDisabled()
        {
            _bossTriggerZone.EnterTriggered -= OnEntered;
            _bossTriggerZone.ExitTriggered -= OnExited;
        }

        public override void OnActive() =>
            MoveToHero().Forget();

        public override void InActive()
        {
            _isCooldown = false;
            AnimatorCached.SetBool(Constants.BossWalkHash, false);
        }

        private void OnEntered() =>
            _isCooldown = false;

        private void OnExited()
        {
            _isCooldown = true;
            LaunchCooldownExit().Forget();
        }

        private void WatchingHero() =>
            transform.LookAt(HeroTransform);

        private void Move() =>
            Agent.destination = HeroTransform.position;

        private void CheckTransition()
        {
            if (HeroNotReached(Constants.MinDistance))
            {
                if (Boss.CheckEnrage)
                    StateMachine.EnterBehavior<EnragedAttackState>();
                else
                    StateMachine.EnterBehavior<MeleeAttackState>();
            }

            if (HeroNotReached(Constants.MaxRangePursuit)) 
                StateMachine.EnterBehavior<IdleState>();
        }

        private bool HeroNotReached(float distance) =>
            Vector3.Distance(Agent.transform.position, HeroTransform.position) >= distance;

        private async UniTaskVoid MoveToHero()
        {
            AnimatorCached.SetBool(Constants.BossWalkHash, true);

            while (enabled)
            {
                WatchingHero();
                Move();
                CheckTransition();

                await UniTask.Delay(100, false, PlayerLoopTiming.FixedUpdate);
            }
        }

        private async UniTaskVoid LaunchCooldownExit()
        {
            await UniTask.Delay(Constants.CooldownAgroBoss);

            if (_isCooldown) 
                StateMachine.EnterBehavior<IdleState>();
        }
    }
}