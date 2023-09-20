using System;
using Plugins.MonoCache;
using Services.SaveLoad;
using Services.Windows;
using UI.Stats;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Windows.Screens
{
    public class HudScreen : MonoCache, IWindow
    {
        [SerializeField] private Button _selectedMenuButton;
        [SerializeField] private Button _selectedSoundButton;
        [SerializeField] private StatBar _statBar;
        
        public Action OnSelectedMenuButton;
        public Action OnSelectedSoundButton;


        public void Construct(ISave save)
        {
            _statBar.Construct(save);
            
            _selectedMenuButton.onClick.AddListener(() => OnSelectedMenu());
            _selectedSoundButton.onClick.AddListener(() => OnSelectedSound());
        }
        
        private void OnSelectedMenu()
        {
            OnSelectedMenuButton?.Invoke();
        }
        
        private void OnSelectedSound()
        {
            
            OnSelectedSoundButton?.Invoke();
        }
        
        public void Activate() => 
            gameObject.SetActive(true);

        public void Deactivate() => 
            gameObject.SetActive(false);

        
    }
}