using Plugins.MonoCache;
using Services.Inputs;
using Services.Windows;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Windows.Screens
{
    [RequireComponent(typeof(Canvas))]
    
    public class AuthorizationScreen : MonoCache, IWindow
    {
        [SerializeField] private Button _buttonYes;
        [SerializeField] private Button _buttonNo;
        
        private LeaderboardScreen _leaderboardScreen;
        private MenuScreen _menuScreen;
        private IInputService _input;
        public void Construct(IInputService input, MenuScreen menuScreen, LeaderboardScreen leaderboardScreen)
        {
            _input = input;
            _leaderboardScreen = leaderboardScreen;
            _menuScreen = menuScreen;
            
            _buttonYes.onClick.AddListener(Yes);
            _buttonNo.onClick.AddListener(No);
        }

        public void Yes()
        {
            print("PlayerAccount.Authorize(OnSuccessCallback, OnErrorCallback);");
            CloseWindow();
            //PlayerAccount.Authorize(OnSuccessCallback, OnErrorCallback);
        }

        public void No() =>
            CloseWindow();

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
        
        private void OnSuccessCallback()
        {
            _leaderboardScreen.Activate();
            Deactivate();
        }

        private void OnErrorCallback(string error) =>
            CloseWindow();

        private void CloseWindow()
        {
            _menuScreen.Activate();
            Deactivate();
        }
    }
}