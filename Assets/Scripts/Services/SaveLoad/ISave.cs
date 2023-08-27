using Infrastructure.SaveLoadLogic.Base;

namespace Services.SaveLoad
{
    public interface ISave
    {
        Progress AccessProgress();
        void Save();
    }
}