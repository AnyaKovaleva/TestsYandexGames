using System.Collections.Generic;
using Test;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu]
    public class QuestionsSO : ScriptableObject
    {
        public List<Question> Questions;
    }
}