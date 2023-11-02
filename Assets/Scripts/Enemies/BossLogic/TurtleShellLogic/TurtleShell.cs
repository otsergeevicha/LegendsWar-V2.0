using System;
using HeroLogic;
using UnityEngine;

namespace Enemies.BossLogic.TurtleShellLogic
{
    public class TurtleShell : Boss
    {
        private Hero _hero;
        public override event Action Died;
        public override Vector3 SpawnPointAttack { get; set; }
        public override float RadiusAttack { get; set; }
        public override int DamageAttack { get; set; }
        public override float DistanceAttack { get; set; }

        public override bool CheckEnrage { get; set; }

        public override void Construct(Hero hero) => 
            _hero = hero;

        public override Hero GetHero => 
            _hero;

        public override int GetId() =>
            (int)BossId.TurtleShell;

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