using System;
using System.Collections.Generic;
using Enemies.BossLogic;
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
        private Dictionary<Type, ISwitcherState> _allBehaviors;
        private ISwitcherState _currentBehavior;
        private Boss _boss;
        private Animator _animator;
        private NavMeshAgent _navMeshAgent;

        private void OnValidate()
        {
            _boss = Get<Boss>();
            _animator = Get<Animator>();
            _navMeshAgent = Get<NavMeshAgent>();
        }

        private void Start()
        {
            _allBehaviors = new Dictionary<Type, ISwitcherState>
            {
                [typeof(IdleState)] = Get<IdleState>(),
                [typeof(MeleeAttackState)] = Get<MeleeAttackState>(),
                [typeof(RangeAttackState)] = Get<RangeAttackState>(),
                [typeof(PursuitState)] = Get<PursuitState>(),
                [typeof(DieState)] = Get<DieState>()
            };
            
            foreach (var behavior in _allBehaviors)
            {
                behavior.Value.Init(this, _animator, _navMeshAgent, _boss.GetHero().transform);
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
}