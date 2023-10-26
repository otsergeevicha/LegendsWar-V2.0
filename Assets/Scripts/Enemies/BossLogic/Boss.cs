using System;
using Enemies.AI;
using UnityEngine;

namespace Enemies.BossLogic
{
    [RequireComponent(typeof(BossStateMachine))]
    public abstract class Boss : Enemy
    {
        public abstract event Action Died;

         public abstract void Construct();
    }
}