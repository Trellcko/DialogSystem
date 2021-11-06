using UnityEngine;
using Trell.DialogSystem.Core;
using TMPro;
using UnityEngine.UI;
using System.Linq;

namespace Trell.DialogSystem.Visualization
{

    public class TextCloud : MonoBehaviour, IVisualization
    {
        [SerializeField] private TextMeshProUGUI _textBox;
        [SerializeField] private Image _cloud;
        [SerializeField] private Transform _attachTransform;

        [SerializeField] private AnimationTextDisplaying _animationTextDisplaying;

        [Space]
        [Header("Text Data")]
        [SerializeField] private TextCloudData[] _data;

        private Dialog _dialog;

        private void Start()
        {
            _dialog = new Dialog(_data.Select(x => x.Message).ToArray());
        }

        public void Disable()
        {
            _cloud.enabled = false;
            ClearText();
        }

        public void Enable()
        {
            _cloud.enabled = true;
        }

        public void ShowNext()
        {
            if (_animationTextDisplaying.IsDisplaying)
            {
                _animationTextDisplaying.Stop();
                _textBox.SetText(_dialog.TheMessage);
                return;
            }
            _attachTransform.position = _data[_dialog.TheIndex].Point.position;
            _animationTextDisplaying.AnimateText(_dialog.GetNextMessage(), _textBox);

        }
 
        private void ClearText()
        {
            _textBox.SetText("");
        }
    }
}