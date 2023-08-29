using Ammo.Ammunition;
using CameraLogic;
using EnemyLogic;
using HeroLogic;
using Infrastructure.Factory.Pools;

namespace Services.Factory
{
    public interface IGameFactory
    {
        Hero CreateHero();
        void CreateWindowRoot();
        CameraFollow CreateCamera();

        Pool CreatePool();
        Grenade CreateGrenade();
        Arrow CreateArrow();
        Enemy CreateEnemy(string typeEnemy);
    }
}