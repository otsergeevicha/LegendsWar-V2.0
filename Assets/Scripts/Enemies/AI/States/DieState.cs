using System;

namespace Enemies.AI.States
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

        public override void OnActive() {}

        public override void InActive() {}
    }
}