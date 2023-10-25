using Plugins.MonoCache;

namespace Enemies.AI
{
    public abstract class State : MonoCache, ISwitcherState
    {
        protected BossStateMachine StateMachine;

        public void EnterBehavior() =>
            enabled = true;

        public void ExitBehavior() =>
            enabled = false;

        public void Init(BossStateMachine stateMachine)
        {
            StateMachine = stateMachine;
        }
    }
}