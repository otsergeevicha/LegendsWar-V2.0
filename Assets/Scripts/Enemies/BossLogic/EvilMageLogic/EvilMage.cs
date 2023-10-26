using System;

namespace Enemies.BossLogic.EvilMageLogic
{
    public class EvilMage : Boss
    {
        public override event Action Died;
        public override void Construct()
        {
            throw new NotImplementedException();
        }

        public override int GetId() =>
            (int)BossId.EvilMage;

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