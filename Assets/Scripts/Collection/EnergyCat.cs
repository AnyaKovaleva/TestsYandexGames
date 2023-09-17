using System;
using UnityEngine;

namespace Collection
{
    [CreateAssetMenu]
    [Serializable]
    public class EnergyCat : ScriptableObject
    {
        public string Name;
        public Sprite Image;
    }
}