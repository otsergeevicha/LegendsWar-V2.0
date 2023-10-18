using System;

namespace Enemies.BossLogic.GolemLogic
{
    public class Golem : Boss
    {
        public override event Action Died;

        public override int GetId() =>
            (int)BossId.Golem;

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