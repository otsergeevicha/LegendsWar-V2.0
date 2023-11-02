using System;
using System.Collections.Generic;
using Enemies.AI.States;
using Enemies.BossLogic;
using Plugins.MonoCache;
using UnityEngine;
using UnityEngine.AI;

namespace Enemies.AI
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(Boss))]
    [RequireComponent(typeof(IdleState))]
    [RequireComponent(typeof(MeleeAttackState))]
    [RequireComponent(typeof(EnragedAttackState))]
    [RequireComponent(typeof(PursuitState))]
    [RequireComponent(typeof(DieState))]
    public class BossStateMachine : MonoCache
    {
        [HideInInspector] [SerializeField] private Boss _boss;
        [HideInInspector] [SerializeField] private Animator _animator;
        [HideInInspector] [SerializeField] private NavMeshAgent _navMeshAgent;
        
        [HideInInspector] [SerializeField] private IdleState _idleState;
        [HideInInspector] [SerializeField] private MeleeAttackState _meleeAttackState;
        [HideInInspector] [SerializeField] private EnragedAttackState _enragedAttackState;
        [HideInInspector] [SerializeField] private PursuitState _pursuitState;
        [HideInInspector] [SerializeField] private DieState _dieState;
        
        private Dictionary<Type, ISwitcherState> _allBehaviors;
        private ISwitcherState _currentBehavior;

        private void OnValidate()
        {
            _boss = Get<Boss>();
            _animator = Get<Animator>();
            _navMeshAgent = Get<NavMeshAgent>();

            _idleState = Get<IdleState>();
            _meleeAttackState = Get<MeleeAttackState>();
            _enragedAttackState = Get<EnragedAttackState>();
            _pursuitState = Get<PursuitState>();
            _dieState = Get<DieState>();
        }

        private void Start()
        {
            _allBehaviors = new Dictionary<Type, ISwitcherState>
            {
                [typeof(IdleState)] = _idleState,
                [typeof(MeleeAttackState)] = _meleeAttackState,
                [typeof(EnragedAttackState)] = _enragedAttackState,
                [typeof(PursuitState)] = _pursuitState,
                [typeof(DieState)] = _dieState
            };

            foreach (var behavior in _allBehaviors)
            {
                behavior.Value.Init(this, _animator, _navMeshAgent, _boss.GetHero.transform, _boss);
                behavior.Value.ExitBehavior();
            }

            _currentBehavior = _allBehaviors[typeof(IdleState)];
            EnterBehavior<IdleState>();
        }

        public void EnterBehavior<TState>() where TState : ISwitcherState
        {
            var behavior = _allBehaviors[typeof(TState)];
            _currentBehavior.InActive();
            _currentBehavior.ExitBehavior();
            behavior.EnterBehavior();
            behavior.OnActive();
            _currentBehavior = behavior;
        }
    }
}