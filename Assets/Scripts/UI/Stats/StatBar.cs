using Plugins.MonoCache;
using Services.SaveLoad;
using UnityEngine;


namespace UI.Stats
{
    public class StatBar : MonoCache
    {
       [SerializeField] private HealthBar _healthBar;
        [SerializeField] private EnergyBar _energyBar;
        
        private ISave _save;

        public void Construct(ISave save)
        {
            _save = save;
            _healthBar.Construct(save);
            _energyBar.Construct(save);
        }
    }
}