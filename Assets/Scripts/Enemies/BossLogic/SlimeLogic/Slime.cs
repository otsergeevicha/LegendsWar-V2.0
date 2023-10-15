using System;

namespace Enemies.BossLogic.SlimeLogic
{
    public class Slime : Boss
    {
        public override event Action Died;

        public override int GetId() =>
            (int)BossId.Slime;
    }
}