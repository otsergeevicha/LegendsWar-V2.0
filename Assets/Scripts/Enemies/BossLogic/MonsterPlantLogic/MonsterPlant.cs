using System;

namespace Enemies.BossLogic.MonsterPlantLogic
{
    public class MonsterPlant : Boss
    {
        public override event Action Died;

        public override int GetId() =>
            (int)BossId.MonsterPlant;

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