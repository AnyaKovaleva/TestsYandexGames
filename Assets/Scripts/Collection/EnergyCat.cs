using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Collection
{
    [CreateAssetMenu]
    [Serializable]
    public class EnergyCat : ScriptableObject
    {
        public string Name;
        public Sprite Image;
        [FormerlySerializedAs("Unlocked")] public bool IsUnlocked = false;
    }
}