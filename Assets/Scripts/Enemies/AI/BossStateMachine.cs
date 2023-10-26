using System;
using System.Collections.Generic;
using Enemies.BossLogic;
using HeroLogic;
using Plugins.MonoCache;
using UnityEngine;
using UnityEngine.AI;

namespace Enemies.AI
{
    [RequireComponent(typeof(Boss))]
    [RequireComponent(typeof(IdleState))]
    [RequireComponent(typeof(MeleeAttackState))]
    [RequireComponent(typeof(RangeAttackState))]
    [RequireComponent(typeof(PursuitState))]
    [RequireComponent(typeof(DieState))]
    public class BossStateMachine : MonoCache
    {
        [HideInInspector] [SerializeField] private Boss _boss;

        [HideInInspector] public IdleState IdleState;
        [HideInInspector] public MeleeAttackState MeleeAttack;
        [HideInInspector] public RangeAttackState RangeAttackState;
        [HideInInspector] public PursuitState PursuitState;
        [HideInInspector] public DieState DieState;

        private Dictionary<Type, ISwitcherState> _allBehaviors;
        private ISwitcherState _currentBehavior;

        private void OnValidate()
        {
            _boss = Get<Boss>();

            IdleState = Get<IdleState>();
            MeleeAttack = Get<MeleeAttackState>();
            RangeAttackState = Get<RangeAttackState>();
            PursuitState = Get<PursuitState>();
            DieState = Get<DieState>();
        }

        private void Start()
        {
            _allBehaviors = new Dictionary<Type, ISwitcherState>
            {
                [typeof(IdleState)] = IdleState,
                [typeof(MeleeAttackState)] = MeleeAttack,
                [typeof(RangeAttackState)] = RangeAttackState,
                [typeof(PursuitState)] = PursuitState,
                [typeof(DieState)] = DieState
            };

            foreach (var behavior in _allBehaviors)
            {
                behavior.Value.Init(this);
                behavior.Value.ExitBehavior();
            }

            _currentBehavior = _allBehaviors[typeof(IdleState)];
            EnterBehavior<IdleState>();
        }

        public void EnterBehavior<TState>() where TState : ISwitcherState
        {
            var behavior = _allBehaviors[typeof(TState)];
            _currentBehavior.ExitBehavior();
            behavior.EnterBehavior();
            _currentBehavior = behavior;
        }
    }

    public interface ISwitcherState
    {
        public void EnterBehavior();
        public void ExitBehavior();
        public void Init(BossStateMachine stateMachine);
    }

    public abstract class State : MonoCache, ISwitcherState
    {
        protected BossStateMachine StateMachine;
        protected event Action EnteredState;
        protected event Action ExitedState;

        public void EnterBehavior()
        {
            enabled = true;
            EnteredState?.Invoke();
        }

        public void ExitBehavior()
        {
            ExitedState?.Invoke();
            enabled = false;
        }

        public void Init(BossStateMachine stateMachine)
        {
            StateMachine = stateMachine;
        }
    }

    [RequireComponent(typeof(Animator))]
    public class IdleState : State
    {
        [HideInInspector] [SerializeField] private Animator _animator;
        [HideInInspector] [SerializeField] private NavMeshAgent _agent;

        protected override void OnEnabled()
        {
            EnteredState += OnActive;
            ExitedState += InActive;
        }

        protected override void OnDisabled()
        {
            EnteredState -= OnActive;
            ExitedState -= InActive;
        }

        private void OnActive()
        {
            throw new NotImplementedException();
        }

        private void InActive()
        {
            throw new NotImplementedException();
        }

        private void OnValidate()
        {
            _animator = Get<Animator>();
            _agent = Get<NavMeshAgent>();
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.TryGetComponent(out Hero hero))
            {
                StateMachine.MeleeAttack.SetHero(hero);
                StateMachine.RangeAttackState.SetHero(hero);
                StateMachine.PursuitState.SetHero(hero);

                StateMachine.EnterBehavior<MeleeAttackState>();
            }
        }
    }

    public class MeleeAttackState : State
    {
        private Hero _hero;

        protected override void OnEnabled()
        {
            EnteredState += OnActive;
            ExitedState += InActive;
        }

        protected override void OnDisabled()
        {
            EnteredState -= OnActive;
            ExitedState -= InActive;
        }

        private void OnActive()
        {
            throw new NotImplementedException();
        }

        private void InActive()
        {
            throw new NotImplementedException();
        }
        
        public void SetHero(Hero hero) =>
            _hero = hero;
    }

    public class RangeAttackState : State
    {
        protected override void OnEnabled()
        {
            EnteredState += OnActive;
            ExitedState += InActive;
        }

        protected override void OnDisabled()
        {
            EnteredState -= OnActive;
            ExitedState -= InActive;
        }

        private void OnActive()
        {
            throw new NotImplementedException();
        }

        private void InActive()
        {
            throw new NotImplementedException();
        }
        
        public void SetHero(Hero hero)
        {
            throw new NotImplementedException();
        }
    }

    [RequireComponent(typeof(NavMeshAgent))]
    public class PursuitState : State
    {
        [HideInInspector] [SerializeField] private NavMeshAgent _agent;

        private Transform _heroTransform;

        protected override void OnEnabled()
        {
            EnteredState += OnActive;
            ExitedState += InActive;
        }

        protected override void OnDisabled()
        {
            EnteredState -= OnActive;
            ExitedState -= InActive;
        }

        private void OnActive()
        {
            if (HeroNotReached())
                _agent.destination = _heroTransform.position;
        }

        private void InActive()
        {
            throw new NotImplementedException();
        }

        private void OnValidate() =>
            _agent = Get<NavMeshAgent>();
        
        public void SetHero(Hero hero) => 
            _heroTransform = hero.transform;

        private bool HeroNotReached() =>
            Vector3.Distance(_agent.transform.position, _heroTransform.position) >= Constants.MinimalDistance;
    }

    public class DieState : State
    {
        protected override void OnEnabled()
        {
            EnteredState += OnActive;
            ExitedState += InActive;
        }

        protected override void OnDisabled()
        {
            EnteredState -= OnActive;
            ExitedState -= InActive;
        }

        private void OnActive()
        {
            throw new NotImplementedException();
        }

        private void InActive()
        {
            throw new NotImplementedException();
        }
        
        public void SetHero(Hero hero)
        {
            throw new NotImplementedException();
        }
    }
}