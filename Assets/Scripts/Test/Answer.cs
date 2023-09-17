using System;
using System.Collections.Generic;
using Collection;

namespace Test
{
    [Serializable]
    public class Answer
    {
        public string Text;
        public List<AnswerWeight> Weights;

        [Serializable]
        public record AnswerWeight
        {
            public EnergyCat EnergyCat;
            public float WeightPoints;
        }
    }
}