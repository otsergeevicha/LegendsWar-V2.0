namespace Enemies.AI.States
{
    public interface IBossAttacker
    {
        void Attacked();
        void StartAoeAttacked();
        void EndAoeAttacked();
    }
}