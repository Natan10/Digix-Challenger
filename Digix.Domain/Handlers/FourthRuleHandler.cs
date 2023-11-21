using Digix.Domain.Entities;

namespace Digix.Domain.Handlers
{
    public class FourthRuleHandler
    {
        public static readonly int Weight = 3;

        public void Execute(FamilyAnalysis familyAnalysis)
        {
            var dependents = familyAnalysis.Family.GetDependents().Count;

            if (dependents >= 3)
            {
                familyAnalysis.Notifications.Add("[FourthRule]: A família possui 3 ou mais dependentes");
                familyAnalysis.Analysis.FourthRule = true;
            }
            else
            {
                familyAnalysis.Notifications.Add("[FourthRule]: A família  não possui 3 ou mais dependentes");
                familyAnalysis.Analysis.FourthRule = false;
            }

        }
    }
}
