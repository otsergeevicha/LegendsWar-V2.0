using Services.SaveLoad;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Stats
{
    [RequireComponent(typeof(Slider))]
    public class HealthBar : Bar
    {
        private ISave _save;

        public override void Construct(ISave save)
        {
            _save = save;
            SetValue(_save.AccessProgress()._characterAttributes.Health);
            _save.AccessProgress()._characterAttributes.OnHealthChanged += UpdateBar;
        }

        protected override void OnDisabled()
        {
            _save.AccessProgress()._characterAttributes.OnHealthChanged -= UpdateBar;
        }
    }
}