using System;

namespace Enemies.BossLogic.SpiderLogic
{
    public class Spider : Boss
    {
        public override event Action Died;

        public override int GetId() =>
            (int)BossId.Spider;
    }
}