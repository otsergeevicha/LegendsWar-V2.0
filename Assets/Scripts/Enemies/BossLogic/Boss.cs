using System;
using HeroLogic;
using UnityEngine;

namespace Enemies.BossLogic
{
    public abstract class Boss : Enemy
    {
        protected Transform TransformHero;

        public abstract event Action Died;

        public void Inject(Transform transformHero) => 
            TransformHero = transformHero;
    }
}