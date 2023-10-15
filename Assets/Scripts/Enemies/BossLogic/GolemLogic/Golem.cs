using System;

namespace Enemies.BossLogic.GolemLogic
{
    public class Golem : Boss
    {
        public override event Action Died;

        public override int GetId() =>
            (int)BossId.Golem;
    }
}