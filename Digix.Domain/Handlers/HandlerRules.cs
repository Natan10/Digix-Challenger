using Digix.Domain.Entities;

namespace Digix.Domain.Handlers
{
    public class HandlerRules
    {
        private readonly FirstRuleHandler _firstRuleHandler;
        private readonly SecondRuleHandler _secondRuleHandler;
        private readonly ThirdRuleHandler _thirdRuleHandler;
        private readonly FourthRuleHandler _fourthRuleHandler;

        public HandlerRules(FirstRuleHandler firstRuleHandler, SecondRuleHandler secondRuleHandler, ThirdRuleHandler thirdRuleHandler, FourthRuleHandler fourthRuleHandler)
        {
            _firstRuleHandler = firstRuleHandler;
            _secondRuleHandler = secondRuleHandler;
            _thirdRuleHandler = thirdRuleHandler;
            _fourthRuleHandler = fourthRuleHandler;
        }


        public void ExecuteRules(FamilyAnalysis familyAnalysis)
        {
            _firstRuleHandler.Execute(familyAnalysis);
            _secondRuleHandler.Execute(familyAnalysis);
            _thirdRuleHandler.Execute(familyAnalysis);
            _fourthRuleHandler.Execute(familyAnalysis);
        }
    }
}
