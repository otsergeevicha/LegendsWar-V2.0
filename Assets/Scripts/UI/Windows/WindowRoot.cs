using Plugins.MonoCache;
using Services.Factory;
using Services.Inputs;
using Services.SaveLoad;
using Services.Wallet;
using UI.Windows.Screens;
using UnityEngine;

namespace UI.Windows
{
    [RequireComponent(typeof(Canvas))]
    public class WindowRoot : MonoCache
    {
        [SerializeField] private HudScreen _hudScreen;
        [SerializeField] private MenuScreen _menuScreen;
        [SerializeField] private VictoryScreen _victoryScreen;
        [SerializeField] private DeadScreen _deadScreen;
        [SerializeField] private LeaderboardScreen _leaderboardScreen;
        [SerializeField] private AuthorizationScreen _authorizationScreen;
        
        public void Construct(ISave save, IInputService input, IWallet wallet, IGameFactory gameFactory)
        {
             _menuScreen.Construct( input,_authorizationScreen ,_leaderboardScreen);
             _hudScreen.Construct(save);
             _hudScreen.OnSelectedMenuButton += () => _menuScreen.Activate();
             _hudScreen.OnSelectedSoundButton += () => _menuScreen.OnSelectedSoundButton();
             _victoryScreen.Construct(input);
             _deadScreen.Construct(input);
             _authorizationScreen.Construct(input,_menuScreen,_leaderboardScreen);
             _leaderboardScreen.Construct(save,_authorizationScreen,_menuScreen);
            
            
             SetParametrs();
        }

        public void SetParametrs()
        {
            _menuScreen.Deactivate();
            _victoryScreen.Deactivate();
            _deadScreen.Deactivate();
            _authorizationScreen.Deactivate();
            _leaderboardScreen.Deactivate();
            _hudScreen.Activate();
        }

        private void OnWin() =>
            _victoryScreen.Activate();
        public void OnExitApplication()
        {
            Application.Quit();
        }
    }
}