using Enemies.BossLogic;
using UnityEngine;
using UnityEngine.AI;

namespace Enemies.AI
{
    public interface ISwitcherState
    {
        public void EnterBehavior();
        public void ExitBehavior();
        public void Init(BossStateMachine stateMachine, Animator animator, NavMeshAgent navMeshAgent, Transform getHero);
    }
}