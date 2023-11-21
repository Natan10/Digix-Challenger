using Digix.Domain.Handlers;

namespace Digix.Domain.Entities
{

    public class AnalysisRules
    {
        public int Id { get; set; }

        public Guid FamilyId { get; set; }

        // renda <= 900
        public bool FirstRule { get; set; }

        // renda > 900 e <= 1500
        public bool SecondRule { get; set; }

        // 1 ou 2 dependentes
        public bool ThirdRule { get; set; }

        // 3 ou mais dependentes
        public bool FourthRule { get; set; }


        public int GetScore()
        {
            var score = 0;

            if (FirstRule) {
                score += FirstRuleHandler.Weight;
            };

            if (SecondRule) {
                score += SecondRuleHandler.Weight;
             };
            if (ThirdRule) {
                score += ThirdRuleHandler.Weight;
            };
            if (FourthRule) {
                score += FourthRuleHandler.Weight;
            };

            return score;
        }
    }
}
