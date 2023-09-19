using System;
using System.Collections;
using Plugins.MonoCache;
using Services.SaveLoad;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Stats
{
    public abstract class Bar : MonoCache, IBar
    {
        [SerializeField] private Image _fill;
        
        public Slider Slider;
        public Gradient Gradient;
        
        private Coroutine _currentAnimationCoroutine;
        private float _maxValue = 100f;
        public float _currentValue;
        private float _animationDuration = 1f;
        private float _targetValue; 
        private bool _isAnimating;
        private bool _isAlive = true;
        
        public abstract void Construct(ISave save);
        
        private void OnValidate()
        {
            Slider = GetComponent<Slider>();
        }
        
         protected void SetValue(float value)
        {
            _currentValue = value;
            UpdateBar();
        }

         protected void SetMaxValue(float value)
         {
             _maxValue = value;
         }
         

        
        protected void UpdateBar()
        {
            float healthPercentage = _currentValue / _maxValue;
            _targetValue = healthPercentage;

            if (!_isAnimating & _isAlive)
            {
                _currentAnimationCoroutine = StartCoroutine(AnimateBar());
            }
            else
            {
                _targetValue = healthPercentage;
            }
        }
        
        private IEnumerator AnimateBar()
        {
            _isAlive = true;
            _isAnimating = true;
            
            float startValue = Slider.value;
            float startTime = Time.time;
            float endTime = startTime + _animationDuration;
            float percentageComplete;

            while (Time.time < endTime & _isAlive)
            {
                if (_currentValue == 0 & _isAlive)
                {
                    Slider.value = _currentValue;
                    _fill.color = Gradient.Evaluate(Slider.normalizedValue);
                    _isAlive = false;
                    StopCoroutine(_currentAnimationCoroutine);
                    break;
                }

                float elapsedTime = Time.time - startTime;
                percentageComplete = elapsedTime / _animationDuration;
                Slider.value = Mathf.Lerp(startValue, _targetValue, percentageComplete);
                _fill.color = Gradient.Evaluate(Slider.normalizedValue);
                yield return null;
            }

            Slider.value = _targetValue;
            _isAnimating = false;
            StopCoroutine(_currentAnimationCoroutine);
        }
    }
}