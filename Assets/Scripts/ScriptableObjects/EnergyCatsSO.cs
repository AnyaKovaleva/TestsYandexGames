using System.Collections.Generic;
using Collection;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu]
    public class EnergyCatsSO : ScriptableObject
    {
        public List<EnergyCat> EnergyCats;
    }
}