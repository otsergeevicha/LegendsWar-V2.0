using System.Collections.Generic;
using Enemies.BossLogic;
using Services.Factory;

namespace Infrastructure.Factory.Pools
{
    public class BossPool
    {
        private readonly List<Boss> _bosses = new ();

        public BossPool(IGameFactory factory)
        {
            _bosses.Add(factory.CreateBoss(Constants.BatPath));
            _bosses.Add(factory.CreateBoss(Constants.DragonPath));
            _bosses.Add(factory.CreateBoss(Constants.EvilMagePath));
            _bosses.Add(factory.CreateBoss(Constants.GolemPath));
            _bosses.Add(factory.CreateBoss(Constants.MonsterPlantPath));
            _bosses.Add(factory.CreateBoss(Constants.OrcPath));
            _bosses.Add(factory.CreateBoss(Constants.SkeletonPath));
            _bosses.Add(factory.CreateBoss(Constants.SlimePath));
            _bosses.Add(factory.CreateBoss(Constants.SpiderPath));
            _bosses.Add(factory.CreateBoss(Constants.TurtleShellPath));
        }

        public List<Boss> GetBoss() => 
            _bosses;
    }
}