using Digix.Domain.Entities;

namespace Digix.Domain.Handlers
{
    public class ThirdRuleHandler
    {
        public static readonly int Weight = 3;

        public void Execute(FamilyAnalysis familyAnalysis)
        {
            var dependents = familyAnalysis.Family.GetDependents().Count;

            if (dependents >= 1 && dependents <= 2)
            {
                familyAnalysis.Notifications.Add("[ThirdRule]: A família possui 1 ou 2 dependentes");
                familyAnalysis.Analysis.ThirdRule = true;
            }
            else
            {

                familyAnalysis.Notifications.Add("[ThirdRule]: A família não possui 1 ou 2 dependentes");
                familyAnalysis.Analysis.ThirdRule = false;
            }

        }
    }
}
