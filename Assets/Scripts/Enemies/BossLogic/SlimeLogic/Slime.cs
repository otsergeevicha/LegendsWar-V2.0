using System;

namespace Enemies.BossLogic.SlimeLogic
{
    public class Slime : Boss
    {
        public override event Action Died;
        public override void Construct()
        {
            throw new NotImplementedException();
        }

        public override int GetId() =>
            (int)BossId.Slime;

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