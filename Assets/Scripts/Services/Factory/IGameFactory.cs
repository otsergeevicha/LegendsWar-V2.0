using Ammo.Ammunition;
using CameraLogic;
using Enemies;
using Enemies.BossLogic;
using HeroLogic;
using Infrastructure.Factory.Pools;
using Reflex;
using SpawnerModule;
using UI.Windows;

namespace Services.Factory
{
    public interface IGameFactory
    {
        Hero CreateHero();
        WindowRoot CreateWindowRoot();
        CameraFollow CreateCamera();

        Pool CreatePool();
        Grenade CreateGrenade();
        Enemy CreateEnemy(string typeEnemy);
        Boss CreateBoss(string typeBoss);
        EnemySpawner CreateEnemySpawner();
    }
}