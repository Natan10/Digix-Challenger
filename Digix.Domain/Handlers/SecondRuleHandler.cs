using Digix.Domain.Entities;

namespace Digix.Domain.Handlers
{
    public class SecondRuleHandler
    {
        public static readonly int Weight = 3;

        public SecondRuleHandler()
        {

        }

        public void Execute(FamilyAnalysis familyAnalysis)
        {
            var income = familyAnalysis.Family.FamilyIncome;
            if (income > 900 && income <= 1500)
            {
                familyAnalysis.Notifications.Add($"[SecondRule]: A família possui renda entre 900 e 1500 reais");
                familyAnalysis.Analysis.SecondRule = true;
            }
            else
            {
                familyAnalysis.Notifications.Add($"[SecondRule]: A família não possui renda entre 900 e 1500 reais");
                familyAnalysis.Analysis.SecondRule = false;
            }
        }
    }
}

