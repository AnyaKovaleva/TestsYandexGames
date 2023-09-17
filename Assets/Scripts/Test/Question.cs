using System;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    [Serializable]
    public class Question
    {
        [SerializeField] string _text;
        public string Text => _text;

        public List<Answer> Answers;
    }
}