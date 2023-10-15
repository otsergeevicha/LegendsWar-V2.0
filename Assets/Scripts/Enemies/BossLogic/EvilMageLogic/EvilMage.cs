using System;

namespace Enemies.BossLogic.EvilMageLogic
{
    public class EvilMage : Boss
    {
        public override event Action Died;

        public override int GetId() =>
            (int)BossId.EvilMage;
    }
}