using System;

namespace Enemies.BossLogic
{
    public abstract class Boss : Enemy
    {
        public abstract event Action Died;
    }
}