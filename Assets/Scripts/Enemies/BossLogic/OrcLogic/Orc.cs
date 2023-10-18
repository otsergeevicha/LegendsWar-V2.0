using System;

namespace Enemies.BossLogic.OrcLogic
{
    public class Orc : Boss
    {
        public override event Action Died;

        public override int GetId() =>
            (int)BossId.Orc;

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