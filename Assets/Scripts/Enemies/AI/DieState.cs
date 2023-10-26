using System;

namespace Enemies.AI
{
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

        public override void OnActive()
        {
            throw new NotImplementedException();
        }

        public override void InActive()
        {
            throw new NotImplementedException();
        }
    }
}