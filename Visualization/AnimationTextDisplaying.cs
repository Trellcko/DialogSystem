using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Trell.DialogSystem.Visualization
{
    public class AnimationTextDisplaying : MonoBehaviour
    {
        [SerializeField] private float _animationSpeed = 0.1f;
        public bool IsDisplaying => _textDisplayingCorun != null;

        private Coroutine _textDisplayingCorun;

        public void AnimateText(string message, TextMeshProUGUI textBox)
        {
            _textDisplayingCorun = StartCoroutine(TextDisplayingCorun(message, textBox));

        }

        public void Stop()
        {
            StopCoroutine(_textDisplayingCorun);
            _textDisplayingCorun = null;
        }

        private IEnumerator TextDisplayingCorun(string text, TextMeshProUGUI textBox)
        {
            foreach (var symbol in text)
            {
                textBox.SetText(textBox.text + symbol);
                yield return new WaitForSeconds(_animationSpeed);
            }
        }
    }
}