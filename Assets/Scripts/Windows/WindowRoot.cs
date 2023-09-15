using Plugins.MonoCache;
using Services.Factory;
using Services.Inputs;
using Services.SaveLoad;
using Services.Wallet;
using UnityEngine;

namespace Windows
{
    [RequireComponent(typeof(Canvas))]
    public class WindowRoot : MonoCache
    {
        public void Construct(ISave save, IInputService input, IWallet wallet, IGameFactory gameFactory)
        {
            throw new System.NotImplementedException();
        }
    }
}