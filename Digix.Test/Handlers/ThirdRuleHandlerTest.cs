
using Digix.Domain.Entities;
using Digix.Domain.Handlers;

namespace Digix.Test.Handlers
{
    public class ThirdRuleHandlerTest
    {
        [Fact(DisplayName = "Check if family has one or more dependents")]
        public void CheckFamilyDependents()
        {
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
            var thirdRuleHandler = new ThirdRuleHandler();


            // Act
            thirdRuleHandler.Execute(familyAnalysis);

            // Assert
            Assert.True(familyAnalysis.Analysis.ThirdRule);
        }


        [Fact(DisplayName = "Check if family has more than two dependents")]
        public void CheckNotFamilyDependents()
        {
            var familyMemberOne = new Person(
              name: "Person one",
              cpf: "92961901006",
              birthDate: new DateTime(2010, 02, 24),
              income: 0
            );

            var familyMemberTwo = new Person(
                name: "Person two",
                cpf: "38471853060",
                birthDate: new DateTime(2006, 05, 20),
                income: 0
            );

            var familyMemberThree = new Person(
                name: "Person three",
                cpf: "25161537086",
                birthDate: new DateTime(2023,01,01),
                income: 0
            );

            var familyMemberFour = new Person(
                name: "Person four",
                cpf: "39024493064",
                birthDate: new DateTime(1985, 06, 10),
                income: 1500,
                isSpouse: true
            );

            var family = new Family();

            family.AddFamilyMember(familyMemberOne);
            family.AddFamilyMember(familyMemberTwo);
            family.AddFamilyMember(familyMemberThree);
            family.AddFamilyMember(familyMemberFour);

            var analysisRules = new AnalysisRules();
            var familyAnalysis = new FamilyAnalysis(family, analysisRules);
            var thirdRuleHandler = new ThirdRuleHandler();


            // Act
            thirdRuleHandler.Execute(familyAnalysis);

            // Assert
            Assert.False(familyAnalysis.Analysis.ThirdRule);
        }
    
    }
}
