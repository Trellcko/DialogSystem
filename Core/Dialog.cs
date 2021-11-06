using System;

namespace Trell.DialogSystem.Core
{
    public class Dialog
    {
        public Action Completed;

        private string[] _messages = new string[0];

        private int _theIndex = -1;

        public Dialog(string[] messages)
        {
            _messages = messages;
            Reset();
        }

        public int TheIndex => _theIndex;

        public string TheMessage
        {
            get
            {
                if (_theIndex > -1 && _theIndex < _messages.Length)
                {
                    return _messages[_theIndex];
                }
                return "";
            }
        }

        public void Reset()
        {
            _theIndex = -1;
        }

        /// <summary>
        /// if there no message left the index will be reset and call Completed
        /// </summary>
        public string GetNextMessage()
        {
            _theIndex++;
            string result = _messages[_theIndex];
            if (_theIndex + 1 == _messages.Length)
            {
                Completed?.Invoke();
                Reset();
            }
            return result;
        }
    }
}