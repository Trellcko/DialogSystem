using System.Collections;
using System.Linq;
using TMPro;
using Trell.DialogSystem.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Trell.DialogSystem.Visualization
{
    public class TextBox : MonoBehaviour, IVisualization
    {
        [SerializeField] private TextMeshProUGUI _textBox;
        [SerializeField] private Image _textBoxImage;
        [SerializeField] private Image _avatarImage;
        [SerializeField] AnimationTextDisplaying _animationTextDisplaying;

        [Space]
        [Header("Text Data")]
        [SerializeField] private TextBoxData[] _data;

        private Dialog _dialog;

        private void Start()
        {
            _dialog = new Dialog(_data.Select(x => x.Message).ToArray());
        }

        public void Enable()
        {
            _textBoxImage.enabled = true;
            ClearText();
        }

        public void Disable()
        {
            _textBoxImage.enabled = false;
        }

        /// <summary>
        /// if text Displaying immidiatly show him
        /// </summary>
        public void ShowNext()
        {
            if(_animationTextDisplaying.IsDisplaying)
            {
                _animationTextDisplaying.Stop();
                _textBox.SetText(_dialog.TheMessage);
                return;
            }
            _avatarImage.sprite = _data[_dialog.TheIndex].Avatar;
            _animationTextDisplaying.AnimateText(_dialog.GetNextMessage(), _textBox);
            
        }

        private void ClearText()
        {
            _textBox.SetText("");
        }
    }
}