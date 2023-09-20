using Plugins.MonoCache;
using Services.Inputs;
using Services.Windows;
using UnityEngine;

namespace UI.Windows.Screens
{
    [RequireComponent(typeof(Canvas))]
    
    public class VictoryScreen : MonoCache, IWindow
    {
        [SerializeField] private GameObject _panel;
        
        public void Activate()
        {       
            Time.timeScale = 0;
            gameObject.SetActive(true);
            ShowAchievements(true);
        }

        public void Deactivate()
        {
            Time.timeScale = 1;
            ShowAchievements(false);
            gameObject.SetActive(false);
        }

        public void Construct(IInputService input)
        {
            input.PushShoot(OnClick);
        }

        private void OnClick()
        {
            
            Deactivate();
        }


        private void ShowAchievements(bool isActive)
        {
            _panel.SetActive(isActive);
        }
    }
}