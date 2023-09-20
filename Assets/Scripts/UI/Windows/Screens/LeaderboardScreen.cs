using Plugins.MonoCache;
using Services.SaveLoad;
using Services.Windows;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Windows.Screens
{
    [RequireComponent(typeof(Canvas))]
    
    public class LeaderboardScreen : MonoCache, IWindow
    {
        [SerializeField] private LeaderboardData[] _datas;
        [SerializeField] private Button _buttonBack;
        
        private ISave _save;
        private AuthorizationScreen _authorizationScreen;
        private MenuScreen _menuScreen;

        public void Construct(ISave save, AuthorizationScreen authorizationScreen, MenuScreen menuScreen)
        {
            _menuScreen = menuScreen;
            _authorizationScreen = authorizationScreen;
            _save = save;
            _buttonBack.onClick.AddListener(SelectBack);
        }
        
        public void Activate()
         {
// #if !UNITY_WEBGL || !UNITY_EDITOR
//             if (PlayerAccount.IsAuthorized)
//             {
//                 Leaderboard.SetScore(Constants.Leaderboard, _save.AccessProgress().DataWallet.Read());
//                 GetLeaderboardEntries();
//                 return;
//             }
//
//             if (!PlayerAccount.IsAuthorized)
//                 _authorizationScreen.OnActive();
//
// #endif
             Time.timeScale = 0;
             gameObject.SetActive(true); 
        }
        
        public void Deactivate()
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);
        }

        public void GetLeaderboardEntries()
        {
            // Leaderboard.GetEntries(Constants.Leaderboard, (result) =>
            // {
            //     for (int i = 0; i < result.entries.Length; i++)
            //         _datas[i].UpdateData(result.entries[i].rank.ToString(), NameCorrector(result.entries[i].player.publicName),
            //             result.entries[i].score.ToString());
            // }, null, Constants.TopPlayersCount, Constants.CompletingPlayersCount);
            //
            // gameObject.SetActive(true);
        }
        
        public void SelectBack()
        {
            _menuScreen.Activate();
            Deactivate();
        }
        
        private string CheckName(string nameMember)
        {
            // if (string.IsNullOrEmpty(nameMember))
            //     nameMember = Constants.Anonymous;
            //
            // return nameMember;
            return null;
        }
    }
}