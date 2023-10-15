using System;

namespace Enemies.BossLogic.BatLogic
{
    public class Bat : Boss
    {
        public override event Action Died;
        
        public override int GetId() =>
            (int)BossId.Bat;
    }
}