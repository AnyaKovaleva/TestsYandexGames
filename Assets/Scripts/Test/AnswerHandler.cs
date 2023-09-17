using System.Collections.Generic;
using System.Linq;
using Collection;

namespace Test
{
    public class AnswerHandler
    {
        private record EnergyCatScore
        {
            public EnergyCat EnergyCat;
            public float Score;

            public EnergyCatScore(EnergyCat energyCat, float score)
            {
                EnergyCat = energyCat;
                Score = score;
            }
        }

        private List<EnergyCatScore> _resultsScore = new List<EnergyCatScore>();

        public void ClearResults()
        {
            _resultsScore?.Clear();
            _resultsScore = new List<EnergyCatScore>();
        }
        
        public void Handle(Answer answer)
        {
            foreach (var weight in answer.Weights)
            {
                var index = _resultsScore.FindIndex(x => x.EnergyCat == weight.EnergyCat);

                if (index != -1)
                {
                    _resultsScore[index].Score += weight.WeightPoints;
                }
                else
                {
                    _resultsScore.Add(new EnergyCatScore(weight.EnergyCat, weight.WeightPoints));
                }

            }
        }

        public EnergyCat CalculateTestResults()
        {
            var maxScore = _resultsScore.Max(x => x.Score);
            return _resultsScore.Find(x => x.Score >= maxScore).EnergyCat;
        }
        
    }
}