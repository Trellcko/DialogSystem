using System;
using UnityEngine;

namespace Trell.DialogSystem.Visualization
{
    [Serializable]
    public class TextBoxData
    {
        [field: SerializeField] public Sprite Avatar { get; private set; }
        [field: SerializeField] public String Message { get; private set; }
    }
}