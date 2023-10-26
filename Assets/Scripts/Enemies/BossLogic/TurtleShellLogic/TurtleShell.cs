using System;

namespace Enemies.BossLogic.TurtleShellLogic
{
    public class TurtleShell : Boss
    {
        public override event Action Died;
        public override void Construct()
        {
            throw new NotImplementedException();
        }

        public override int GetId() =>
            (int)BossId.TurtleShell;

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