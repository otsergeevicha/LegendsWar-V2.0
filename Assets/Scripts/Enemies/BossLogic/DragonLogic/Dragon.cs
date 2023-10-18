using System;

namespace Enemies.BossLogic.DragonLogic
{
    public class Dragon : Boss
    {
        public override event Action Died;

        public override int GetId() =>
            (int)BossId.Dragon;

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