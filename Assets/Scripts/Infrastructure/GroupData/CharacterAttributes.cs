using System;

namespace Infrastructure.GroupData
{
    [Serializable]
    public class CharacterAttributes
    {
        public int Health = 0;
        public int Energy = 0;
        
        [NonSerialized]
        public Action OnHealthChanged;
        public Action OnEnergyChanged;
        
        public int ReadHealth() =>
            Health;

        public int ReadEnergy() =>
            Energy;

        public void RecordHealth(int amountHealth)
        {
            Health = amountHealth;
            OnHealthChanged?.Invoke();
        }
        
        public void RecordEnergy(int amountEnergy)
        {
            Energy = amountEnergy;
            OnEnergyChanged?.Invoke();
        }
    }
}