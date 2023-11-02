using System;
using Enemies.BossLogic;
using Plugins.MonoCache;
using UnityEngine;
using UnityEngine.AI;

namespace Enemies.AI
{
    public abstract class State : MonoCache, ISwitcherState
    {
        protected BossStateMachine StateMachine;
        protected Animator AnimatorCached;
        protected NavMeshAgent Agent;
        protected Transform HeroTransform;
        protected Boss Boss;

        public abstract void OnActive();
        public abstract void InActive();

        public void EnterBehavior() => 
            enabled = true;

        public void ExitBehavior() => 
            enabled = false;

        public void Init(BossStateMachine stateMachine, Animator animator, NavMeshAgent navMeshAgent, Transform hero,
            Boss boss)
        {
            Boss = boss;
            HeroTransform = hero;
            Agent = navMeshAgent;
            AnimatorCached = animator;
            StateMachine = stateMachine;
        }
    }
}