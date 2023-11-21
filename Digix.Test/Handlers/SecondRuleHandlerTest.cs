

using Digix.Domain.Entities;
using Digix.Domain.Handlers;

namespace Digix.Test.Handlers
{
    public class SecondRuleHandlerTest
    {
        [Fact(DisplayName = "Checks if family income is more than 900 and less or equal than 1500")]
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
              cpf: "03287341014",
              birthDate: new DateTime(1997, 02, 24),
              income: 500
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

            var secondRuleHandler = new SecondRuleHandler();

            // Act
            secondRuleHandler.Execute(familyAnalysis);

            // Assert
            Assert.True(familyAnalysis.Analysis.SecondRule);
        }

        [Fact]
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
              cpf: "03287341014",
              birthDate: new DateTime(1997, 02, 24),
              income: 500
            );

            var familyMemberThree = new Person(
              name: "Person three",
              cpf: "39024493064",
              birthDate: new DateTime(1985, 06, 10),
              income: 1500,
              isSpouse: true
            );

            var family = new Family();

            family.AddFamilyMember(familyMemberOne);
            family.AddFamilyMember(familyMemberTwo);
            family.AddFamilyMember(familyMemberThree);

            var analysisRules = new AnalysisRules();
            var familyAnalysis = new FamilyAnalysis(family, analysisRules);

            var secondRuleHandler = new SecondRuleHandler();

            // Act
            secondRuleHandler.Execute(familyAnalysis);

            // Assert
            Assert.False(familyAnalysis.Analysis.SecondRule);
        }
    }
}
