using System;
using Enemies.AI;
using HeroLogic;
using UnityEngine;

namespace Enemies.BossLogic
{
    [RequireComponent(typeof(BossStateMachine))]
    public abstract class Boss : Enemy
    {
        public abstract event Action Died;
        public abstract Vector3 SpawnPointAttack { get; set; }
        public abstract float RadiusAttack { get; set; }
        public abstract int DamageAttack { get; set; }
        public abstract float DistanceAttack { get; set; }
        public abstract Hero GetHero { get; }
        public abstract bool CheckEnrage { get; set; }
        public abstract void Construct(Hero hero);
    }
}