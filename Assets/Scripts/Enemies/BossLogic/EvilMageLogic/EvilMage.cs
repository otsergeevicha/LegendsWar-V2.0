using System;
using HeroLogic;

namespace Enemies.BossLogic.EvilMageLogic
{
    public class EvilMage : Boss
    {
        private Hero _hero;
        public override event Action Died;
        
        public override void Construct(Hero hero) => 
            _hero = hero;

        public override Hero GetHero() =>
            _hero;

        public override int GetId() =>
            (int)BossId.EvilMage;

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