using Plugins.MonoCache;
using Services.Windows;
using UnityEngine;

namespace Windows.Screens
{
    [RequireComponent(typeof(Canvas))]
    
    public class ExitScreen : MonoCache, IWindow
    {
        public void Activate()
        {
            throw new System.NotImplementedException();
        }

        public void Deactivate()
        {
            throw new System.NotImplementedException();
        }
    }
}