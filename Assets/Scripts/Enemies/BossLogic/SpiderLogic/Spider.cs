using System;

namespace Enemies.BossLogic.SpiderLogic
{
    public class Spider : Boss
    {
        public override event Action Died;
        public override void Construct()
        {
            throw new NotImplementedException();
        }

        public override int GetId() =>
            (int)BossId.Spider;

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