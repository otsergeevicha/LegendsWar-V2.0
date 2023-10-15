using System;

namespace Enemies.BossLogic.SkeletonLogic
{
    public class Skeleton : Boss
    {
        public override event Action Died;

        public override int GetId() =>
            (int)BossId.Skeleton;
    }
}