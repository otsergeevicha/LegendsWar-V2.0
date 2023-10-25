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
        [HideInInspector] [SerializeField] private IdleState _idleState;
        [HideInInspector] [SerializeField] private MeleeAttackState _meleeAttack;
        [HideInInspector] [SerializeField] private RangeAttackState _rangeAttackState;
        [HideInInspector] [SerializeField] private PursuitState _pursuitState;
        [HideInInspector] [SerializeField] private DieState _dieState;

        private Dictionary<Type, ISwitcherState> _allBehaviors;
        private ISwitcherState _currentBehavior;

        private void OnValidate()
        {
            _boss = Get<Boss>();
            _idleState = Get<IdleState>();
            _meleeAttack = Get<MeleeAttackState>();
            _rangeAttackState = Get<RangeAttackState>();
            _pursuitState = Get<PursuitState>();
            _dieState = Get<DieState>();
        }

        private void Start()
        {
            _allBehaviors = new Dictionary<Type, ISwitcherState>
            {
                [typeof(IdleState)] = _idleState,
                [typeof(MeleeAttackState)] = _meleeAttack,
                [typeof(RangeAttackState)] = _rangeAttackState,
                [typeof(PursuitState)] = _pursuitState,
                [typeof(DieState)] = _dieState
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

    [RequireComponent(typeof(Animator))]
    public class IdleState : State
    {
        [HideInInspector] [SerializeField] private Animator _animator;
        [HideInInspector] [SerializeField] private NavMeshAgent _agent;
        
        private void OnValidate()
        {
            _animator = Get<Animator>();
            _agent = Get<NavMeshAgent>();
        }


        private void OnTriggerEnter(Collider collision)
        {
            if (collision.TryGetComponent(out Hero hero))
            {
                StateMachine.EnterBehavior<MeleeAttackState>();
            }
        }
    }

    public class MeleeAttackState : State
    {
    }

    public class RangeAttackState : State
    {
    }

    [RequireComponent(typeof(NavMeshAgent))]
    public class PursuitState : State
    {
        [HideInInspector] [SerializeField] private NavMeshAgent _agent;

        private Transform _transformHero;

        private void OnValidate() =>
            _agent = Get<NavMeshAgent>();

        protected override void UpdateCached()
        {
            // if (HeroNotReached())
            //     _agent.destination = _heroTransform.position;
        }

        private bool HeroNotReached() =>
            Vector3.Distance(_agent.transform.position, _transformHero.position) >= Constants.MinimalDistance;
    }

    public class DieState : State
    {
    }
}