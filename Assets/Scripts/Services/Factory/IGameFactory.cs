using Infrastructure.Factory.Pools;

namespace Services.Factory
{
    public interface IGameFactory
    {
        Pool CreatePool();
    }
}