using System;
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

        public abstract void OnActive();
        public abstract void InActive();

        public void EnterBehavior() => 
            enabled = true;

        public void ExitBehavior() => 
            enabled = false;

        public void Init(BossStateMachine stateMachine, Animator animator, NavMeshAgent navMeshAgent, Transform hero)
        {
            HeroTransform = hero;
            Agent = navMeshAgent;
            AnimatorCached = animator;
            StateMachine = stateMachine;
        }
    }
}