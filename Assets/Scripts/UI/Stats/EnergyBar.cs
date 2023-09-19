using Services.SaveLoad;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Stats
{
    public class EnergyBar : Bar
    {   
            private ISave _save;

            public override void Construct(ISave save)
            {
                _save = save;
              //  SetValue(_save.AccessProgress().DataStats.Energy);
              //_save.AccessProgress().DataStats.OnEnergyChanged+= UpdateBar;
            }

            protected override void OnDisabled()
            {
                //_save.AccessProgress().DataStats.OnEnergyChanged-= UpdateBar;
            }
    }
}