﻿using System;
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
        private Dictionary<Type, ISwitcherState> _allBehaviors;
        private ISwitcherState _currentBehavior;
        
        private Boss _boss;
        private Animator _animator;
        private NavMeshAgent _navMeshAgent;

        private void Start()
        {
            _boss = Get<Boss>();
            _animator = Get<Animator>();
            _navMeshAgent = Get<NavMeshAgent>();
            
            _allBehaviors = new Dictionary<Type, ISwitcherState>
            {
                [typeof(IdleState)] = Get<IdleState>(),
                [typeof(MeleeAttackState)] = Get<MeleeAttackState>(),
                [typeof(EnragedAttackState)] = Get<EnragedAttackState>(),
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