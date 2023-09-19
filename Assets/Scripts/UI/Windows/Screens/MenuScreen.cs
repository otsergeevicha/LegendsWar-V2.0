using System;
using System.Runtime.CompilerServices;
using Plugins.MonoCache;
using Services.Inputs;
using Services.SaveLoad;
using Services.Windows;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Windows.Screens
{
    [RequireComponent(typeof(Canvas))]
    public class MenuScreen : MonoCache,IWindow
    {
        [SerializeField] private Button _buttonResume;
        [SerializeField] private Button _buttonReset;
        [SerializeField] private Button _buttonExit;
        [SerializeField] private Button _buttonSettings;
        [SerializeField] private Button _buttonBack;
        [SerializeField] private Button _buttonSound;
        [SerializeField] private GameObject _panel;
        
        private Canvas _canvasToMove;
        private int _currentIndex;
        private void OnValidate()
        {
            _canvasToMove= GetComponent<Canvas>();
        }

        public void Construct(ISave save, IInputService input)
        {
            _buttonResume.onClick.AddListener(() => OnClickResume());
            _buttonSettings.onClick.AddListener(() => OnClickSettings());
            _buttonSound.onClick.AddListener(() => OnClickSound());
            _buttonBack.onClick.AddListener(() => OnClickBack());
        }

        private void OnClickBack()
        {
            _panel.SetActive(false);
        }

        private void OnClickResume()
        {
            Deactivate();
        }

        public void Activate()
         {       
             Time.timeScale = 0;
             gameObject.SetActive(true); 
             _currentIndex = _canvasToMove.transform.GetSiblingIndex();
             _canvasToMove.transform.SetSiblingIndex(0);
         }

        public void Deactivate()
        {
            Time.timeScale = 1;
            gameObject.SetActive(true);
            _canvasToMove.transform.SetSiblingIndex(_currentIndex);
        }


        private void OnClickSettings()
        {
            _panel.SetActive(true);
        }
       
        private void OnClickSound()
        {
            throw new System.NotImplementedException();
        }

        // public void Select()
        // {
        //     InActive();
        //     _tank.ResetCountShots();
        //     _obstaclePattern.ResetCountCollision();
        //     _tank.OnActive();
        //     _towerBuilder.LaunchBuild();
        //     
        //     Time.timeScale = 1;
        // }
        //
        // public void SelectSound()
        // {
        //     if (_toggleSound.isOn) 
        //         _soundOperator.UnMute();
        //     
        //     if (!_toggleSound.isOn) 
        //         _soundOperator.Mute();
        //     
        //     ChangeIconSound(_toggleSound.isOn);
        // }
        //
        // public void SelectLeaderBoard()
        // {
        //     _leaderboardScreen.OnActive();
        //     InActive();
        // }
        //
        //
        //
        // public void InActive() =>
        //     gameObject.SetActive(false);
        //
        //
        // private void ChangeIconSound(bool flag)
        // {
        //     _activeSoundIcon.gameObject.SetActive(flag);
        //     _inActiveSoundIcon.gameObject.SetActive(!flag);
        // }
    }
}