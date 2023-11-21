using Digix.Domain.Entities;

namespace Digix.Domain.Handlers
{
    public class FirstRuleHandler
    {
        public static readonly int Weight = 5;

        public FirstRuleHandler()
        {

        }

        public void Execute(FamilyAnalysis familyAnalysis)
        {
            if (familyAnalysis.Family.FamilyIncome <= 900)
            {
                familyAnalysis.Notifications.Add($"[FirstRule]: A família possui renda menor que 900");
                familyAnalysis.Analysis.FirstRule = true;
            }
            else
            {
                familyAnalysis.Notifications.Add("[FirstRule]: A família não possui renda menor que 900");
                familyAnalysis.Analysis.FirstRule = false;
            }
        }

    }
}
