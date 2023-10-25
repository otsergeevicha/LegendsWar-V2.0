using Enemies.BossLogic;

namespace Enemies.AI
{
    public interface ISwitcherState
    {
        public void EnterBehavior();
        public void ExitBehavior();
        public void Init(BossStateMachine stateMachine);
    }
}