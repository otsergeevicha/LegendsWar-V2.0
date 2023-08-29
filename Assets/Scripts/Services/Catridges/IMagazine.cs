using System;

namespace Services.Catridges
{
    public interface IMagazine
    {
        void Spend();
        bool Check();

        void Replenishment(Action fulled);

        void Shortage();
    }
}