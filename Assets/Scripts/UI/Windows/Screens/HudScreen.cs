using System;
using Plugins.MonoCache;
using Services.SaveLoad;
using Services.Windows;
using UI.Stats;
using UnityEngine;
using UnityEngine.UI;

namespace Windows.Screens
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
            
            _selectedMenuButton.onClick.AddListener(() => OnSelectedMenuButton());
            _selectedSoundButton.onClick.AddListener(() => OnSelectedSoundButton());
            //_healthBar.Construct(save);
        }
        
        public void OnActive() => 
            gameObject.SetActive(true);

        public void InActive() => 
            gameObject.SetActive(false);

        
    }
}