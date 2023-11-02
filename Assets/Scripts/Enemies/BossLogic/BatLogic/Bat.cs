using System;
using HeroLogic;
using UnityEngine;

namespace Enemies.BossLogic.BatLogic
{
    public class Bat : Boss
    {
        private Hero _hero;
        public override event Action Died;
        public override Vector3 SpawnPointAttack { get; set; }
        public override float RadiusAttack { get; set; }
        public override int DamageAttack { get; set; }
        public override float DistanceAttack { get; set; }

        public override bool CheckEnrage
        {
            get
            {
                return false;
            }
            set
            {
                
            }
        }

        public override void Construct(Hero hero) => 
            _hero = hero;

        public override Hero GetHero => 
            _hero;

        public override int GetId() =>
            (int)BossId.Bat;

        public override void OnActive()
        {
            gameObject.SetActive(true);
        }

        public override void InActive()
        {
            throw new NotImplementedException();
        }
    }
}