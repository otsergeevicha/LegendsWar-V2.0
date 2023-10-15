using System;

namespace Enemies.BossLogic.TurtleShellLogic
{
    public class TurtleShell : Boss
    {
        public override event Action Died;

        public override int GetId() =>
            (int)BossId.TurtleShell;
    }
} 