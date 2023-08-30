using Plugins.MonoCache;
using Services.Windows;

namespace Windows.Screens
{
    public class HudScreen : MonoCache, IWindow
    {
        public void OnActive() => 
            gameObject.SetActive(true);

        public void InActive() => 
            gameObject.SetActive(false);
    }
}