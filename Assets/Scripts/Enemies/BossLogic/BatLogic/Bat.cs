using System;
using HeroLogic;

namespace Enemies.BossLogic.BatLogic
{
    public class Bat : Boss
    {
        private Hero _hero;
        public override event Action Died;
        
        public override void Construct(Hero hero) => 
            _hero = hero;

        public override Hero GetHero() =>
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