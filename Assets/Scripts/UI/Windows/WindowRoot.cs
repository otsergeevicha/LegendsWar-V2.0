using Windows.Screens;
using Plugins.MonoCache;
using Services.Factory;
using Services.Inputs;
using Services.SaveLoad;
using Services.Wallet;
using Services.Windows;
using UI.Windows.Screens;
using UnityEngine;

namespace UI.Windows
{
    [RequireComponent(typeof(Canvas))]
    public class WindowRoot : MonoCache
    {
        [SerializeField] private VictoryScreen _victoryScreen;
        [SerializeField] private MenuScreen _menuScreen;
        [SerializeField] private LeaderboardScreen _leaderboardScreen;
        [SerializeField] private AuthorizationScreen _authorizationScreen;
        [SerializeField] private HudScreen _hudScreen;
        
        public void Construct(ISave save, IInputService input, IWallet wallet, IGameFactory gameFactory)
        {
             _hudScreen.Construct(save);
             _hudScreen.OnSelectedMenuButton += () => _menuScreen.Activate();
             //_hudScreen.OnSelectedSoundButton += () => _menuScreen.OnSelectedSoundButton();
             _menuScreen.Construct(save, input );
            // _authorizationScreen.Construct(save);
            // _leaderboardScreen.Construct(save);
            // _victoryScreen.Construct(save);
            //
            // _hudScreen.OnSelectedMenuButton += () => _menuScreen.OnActive();
            // _menuScreen.OnSelectedSoundButton += () => _authorizationScreen.OnActive();
            //
             SetParametrs();
        }

        public void SetParametrs()
        {
            _hudScreen.Activate();
            //_menuScreen.Deactivate();
            //_victoryScreen.Deactivate();
           // _authorizationScreen.Deactivate();
            //_leaderboardScreen.Deactivate();
        }

        private void OnWin() =>
            _victoryScreen.Activate();
    }
}