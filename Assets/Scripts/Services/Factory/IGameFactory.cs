using Ammo.Ammunition;
using CameraLogic;
using EnemyLogic;
using HeroLogic;
using Infrastructure.Factory.Pools;
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
        Arrow CreateArrow();
        Enemy CreateEnemy(string typeEnemy);
    }
}