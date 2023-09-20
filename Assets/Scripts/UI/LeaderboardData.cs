using Plugins.MonoCache;
using TMPro;
using UnityEngine;

namespace UI
{
    public class LeaderboardData : MonoCache

    {
        [SerializeField] private TMP_Text _rank;
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _score;

        public void UpdateData(string rank, string name, string score)
        {
            _rank.text = rank;
            _name.text = name;
            _score.text = score;
        }
    }
}