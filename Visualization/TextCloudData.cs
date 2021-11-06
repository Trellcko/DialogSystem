using System;
using UnityEngine;

namespace Trell.DialogSystem.Visualization
{
    [Serializable]
    public class TextCloudData
    {
        [field: SerializeField] public Transform Point { get; private set; }
        [field: SerializeField] public string Message { get; private set; }
    }
}