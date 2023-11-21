using Digix.Domain.Entities;
using Digix.Domain.Handlers;

namespace Digix.Test.Handlers
{
    public class FirstRuleHandlerTest
    {
        [Fact(DisplayName = "Checks if family income is less than 900")]
        public void CheckFamilyIncome()
        {
            // Arrange
            var familyMemberOne = new Person(
             name: "Person one",
             cpf: "92961901006",
             birthDate: new DateTime(2010, 02, 24),
             income: 0
           );

            var familyMemberTwo = new Person(
              name: "Person two",
              cpf: "39024493064",
              birthDate: new DateTime(2002, 02, 24),
              income: 0
            );

            var familyMemberThree = new Person(
              name: "Person three",
              cpf: "39024493064",
              birthDate: new DateTime(1990, 06, 10),
              income: 900,
              isSpouse: true
            );

            var family = new Family();

            family.AddFamilyMember(familyMemberOne);
            family.AddFamilyMember(familyMemberTwo);
            family.AddFamilyMember(familyMemberThree);

            var analysisRules = new AnalysisRules();
            var familyAnalysis = new FamilyAnalysis(family, analysisRules);

            var firstRuleHandler = new FirstRuleHandler();

            // Act
            firstRuleHandler.Execute(familyAnalysis);

            // Assert
            Assert.True(familyAnalysis.Analysis.FirstRule);
        }


        [Fact(DisplayName = "Checks if family income is not less than 900")]
        public void CheckNotFamilyIncome()
        {
            // Arrange
            var familyMemberOne = new Person(
             name: "Person one",
             cpf: "92961901006",
             birthDate: new DateTime(2010, 02, 24),
             income: 0
           );

            var familyMemberTwo = new Person(
              name: "Person two",
              cpf: "39024493064",
              birthDate: new DateTime(2000, 02, 24),
              income: 100
            );

            var familyMemberThree = new Person(
              name: "Person three",
              cpf: "39024493064",
              birthDate: new DateTime(1985, 06, 10),
              income: 900,
              isSpouse: true
            );

            var family = new Family();

            family.AddFamilyMember(familyMemberOne);
            family.AddFamilyMember(familyMemberTwo);
            family.AddFamilyMember(familyMemberThree);

            var analysisRules = new AnalysisRules();
            var familyAnalysis = new FamilyAnalysis(family, analysisRules);

            var firstRuleHandler = new FirstRuleHandler();

            // Act
            firstRuleHandler.Execute(familyAnalysis);

            // Assert
            Assert.False(familyAnalysis.Analysis.FirstRule);
        }

    }
}
