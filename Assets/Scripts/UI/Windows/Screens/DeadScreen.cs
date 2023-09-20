using Plugins.MonoCache;
using Services.Inputs;
using Services.Windows;
using UnityEngine;

namespace UI.Windows.Screens
{
    [RequireComponent(typeof(Canvas))]
    
    public class DeadScreen : MonoCache, IWindow
    {

        public void Construct(IInputService input)
        {
            input.PushShoot(OnClick);
        }
        
        public void Activate()
        {       
            Time.timeScale = 0;
            gameObject.SetActive(true); 
        }

        public void Deactivate()
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);
        }

        private void OnClick()
        {
            Deactivate();
        }
    }
}