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
        [SerializeField] private Button _buttonAuthorization;
        [SerializeField] private Button _buttonLeaderboard;
        [SerializeField] private Button _buttonBack;
        [SerializeField] private GameObject _panel;
        [SerializeField] private GameObject _panelSettings;
        
        private AuthorizationScreen _authorizationScreen;
        private  LeaderboardScreen _leaderboardScreen;
        private IInputService _input;
        public void Construct(IInputService input, AuthorizationScreen authorizationScreen,
            LeaderboardScreen leaderboardScreen)
        {
            _input = input;
            _authorizationScreen=authorizationScreen;
            _leaderboardScreen=leaderboardScreen;
            _buttonResume.onClick.AddListener(() => OnClickResume());
            _buttonSettings.onClick.AddListener(() => OnClickSettings());
            _buttonBack.onClick.AddListener(() => OnClickBack());
            _buttonAuthorization.onClick.AddListener(()=>OnClickAuthorization());
            _buttonLeaderboard.onClick.AddListener(()=>OnClickLeaderboard());
        }

        private void OnClickLeaderboard()
        {
            _leaderboardScreen.Activate();
            Deactivate();
        }

        private void OnClickAuthorization()
        {
            _authorizationScreen.Activate();
            Deactivate();
        }

        private void OnClickBack()
        {
            _panel.SetActive(true);
            _panelSettings.SetActive(false);
        }

        private void OnClickResume()
        {
            Deactivate();
        }

        public void Activate()
         {       
             _input.OffControls();
             Time.timeScale = 0;
             gameObject.SetActive(true); 
         }

        public void Deactivate()
        {
            _input.OnControls();
            Time.timeScale = 1;
            gameObject.SetActive(false);
        }


        private void OnClickSettings()
        {
            _panel.SetActive(false);
            _panelSettings.SetActive(true);
        }

        public void OnSelectedSoundButton()
        {
            print("SelectSoundButton");
        }
    }
}